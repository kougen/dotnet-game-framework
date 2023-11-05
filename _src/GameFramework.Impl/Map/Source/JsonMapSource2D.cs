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
        private readonly IPositionFactory _positionFactory;
        private readonly string _mapDataBase64;
        private readonly IMapObject2DConverter _tileConverter;

        public sealed override IEnumerable<IMapObject2D> MapObjects { get; protected set; }
        public sealed override ICollection<IUnit2D> Units { get; protected set; }
        
        protected readonly IConfigurationQuery Query;
        private readonly IDataParser _dataParser;


        protected JsonMapSource2D(IServiceProvider provider, string filePath, int[,] data, ICollection<IUnit2D> units, int col, int row)
        {
            Units = units ?? throw new ArgumentNullException(nameof(units));

            filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            Query = provider.GetRequiredService<IConfigurationQueryFactory>().CreateConfigurationQuery(filePath);
            _positionFactory = provider.GetRequiredService<IPositionFactory>();
            _dataParser = provider.GetRequiredService<IDataParser>();
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
            Query = queryFactory.CreateConfigurationQuery(filePath);
            _positionFactory = provider.GetRequiredService<IPositionFactory>();
            _dataParser = provider.GetRequiredService<IDataParser>();
            _tileConverter = provider.GetRequiredService<IMapObject2DConverter>();
            ColumnCount = Query.GetIntAttribute("row") ??  throw new InvalidOperationException("Draft config is missing a 'row;");
            RowCount = Query.GetIntAttribute("col") ??  throw new InvalidOperationException("Draft config is missing a 'col'");
            _mapDataBase64 = Query.GetStringAttribute("data") ??  throw new InvalidOperationException("Draft config is missing the 'data'");
            
            Units = Query.GetObject<List<IUnit2D>>("units") ?? new List<IUnit2D>();
            MapObjects = ConvertDataToObjects();
        }
        
        public override void SaveLayout(IEnumerable<IMapObject2D> updatedMapObjects, IEnumerable<IUnit2D> updatedUnits)
        {
            Units = updatedUnits.ToList();
            MapObjects = updatedMapObjects;
            Query.SetObject("units", Units);
        }
        
        private IEnumerable<IMapObject2D> ConvertDataToObjects()
        {
            var mapLayout = 
                _dataParser.MultiTryParse<int>(Encoding.UTF8.GetString(Convert.FromBase64String(_mapDataBase64)), int.TryParse, out _, ' ').ToList();

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
