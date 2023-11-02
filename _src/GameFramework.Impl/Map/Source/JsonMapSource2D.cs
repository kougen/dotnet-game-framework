using System.Text;
using GameFramework.Core.Factories;
using GameFramework.Entities;
using GameFramework.Map.MapObject;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;
using Infrastructure.IO;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Impl.Map.Source
{
    public class JsonMapSource2D<T> : AMapSource2D where T : struct, Enum
    {
        private readonly IConfigurationQuery _query;
        private readonly IReader _reader;
        private readonly IPositionFactory _positionFactory;
        private readonly string _mapDataBase64;
        private readonly IMapObject2DConverter _tileConverter;

        public sealed override IEnumerable<IMapObject2D> MapObjects { get; protected set; }
        public sealed override ICollection<IUnit2D> Units { get; protected set; }

        protected JsonMapSource2D(IServiceProvider provider, string filePath, int[,] data, ICollection<IUnit2D> units, int col, int row)
        {
            Units = units ?? throw new ArgumentNullException(nameof(units));

            filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _query = provider.GetRequiredService<IConfigurationQueryFactory>().CreateConfigurationQuery(filePath);
            _positionFactory = provider.GetRequiredService<IPositionFactory>();
            _reader = provider.GetRequiredService<IReader>();
            _tileConverter = provider.GetRequiredService<IMapObject2DConverter>();
            ColumnCount = col;
            RowCount = row;
            _mapDataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetRawData(data)));
            MapObjects = ConvertDataToObjects();
        }

        protected JsonMapSource2D(IServiceProvider provider, string filePath)
        {
            var queryFactory = provider.GetRequiredService<IConfigurationQueryFactory>();
            filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _query = queryFactory.CreateConfigurationQuery(filePath);
            _positionFactory = provider.GetRequiredService<IPositionFactory>();
            _reader = provider.GetRequiredService<IReader>();
            _tileConverter = provider.GetRequiredService<IMapObject2DConverter>();
            ColumnCount = _query.GetIntAttribute("row") ??  throw new InvalidOperationException("Draft config is missing a 'row;");
            RowCount = _query.GetIntAttribute("col") ??  throw new InvalidOperationException("Draft config is missing a 'col'");
            _mapDataBase64 = _query.GetStringAttribute("data") ??  throw new InvalidOperationException("Draft config is missing the 'data'");
            
            Units = _query.GetObject<List<IUnit2D>>("units") ?? new List<IUnit2D>();
            MapObjects = ConvertDataToObjects();
        }
        
        public override void SaveLayout(IEnumerable<IMapObject2D> updatedMapObjects, IEnumerable<IUnit2D> updatedUnits)
        {
            Units = updatedUnits.ToList();
            MapObjects = updatedMapObjects;
            _query.SetObject("units", Units);
        }
        
        private IEnumerable<IMapObject2D> ConvertDataToObjects()
        {
            var id = Guid.NewGuid();
            var tempPath = Path.Join(Path.GetTempPath(), $"{id}.txt");
            File.Create(tempPath).Close();
            File.WriteAllText(tempPath, Encoding.UTF8.GetString(Convert.FromBase64String(_mapDataBase64)));
            using var stream = new StreamReader(tempPath);
            var mapLayout = _reader.ReadAllLines<int>(stream, int.TryParse, ' ').ToList();
            var list = new List<IMapObject2D>();
            for (var i = 0; i < mapLayout.Count; i++)
            {
                var row = mapLayout[i].ToList();
                for (var j = 0; j < row.Count; j++)
                {
                    var value = row[j];
                    var position = _positionFactory.CreatePosition(j, i);
                    if (!Enum.TryParse(value.ToString(), out T type))
                    {
                        continue;
                    }
                    list.Add(_tileConverter.FromEnum(type, position));
                }
            }
            return list;
        }
        
        private string GetRawData(int[,] data)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    var tile = data[i,j];
                    stringBuilder.Append($"{tile} ");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append("\r\n");
            }
            return stringBuilder.ToString();
        }
    }

    public class JsonMapSource2D : JsonMapSource2D<TileType>
    {
        public JsonMapSource2D(IServiceProvider provider, string filePath, int[,] data, ICollection<IUnit2D> units, int col, int row) : base(provider, filePath, data, units, col, row)
        { }
        
        public JsonMapSource2D(IServiceProvider provider, string filePath) : base(provider, filePath)
        { }
    }
}
