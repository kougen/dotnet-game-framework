using System.Drawing;
using System.Text;
using GameFramework.Core.Position;
using GameFramework.Impl.Map.Source.Dummies;
using GameFramework.Objects.Interactable;
using GameFramework.Objects.Static;
using Infrastructure.Configuration;
using Infrastructure.Configuration.Factories;
using Infrastructure.IO;
using Microsoft.Extensions.DependencyInjection;
using ColorConverter = GameFramework.Tiles.ColorConverter;

namespace GameFramework.Impl.Map.Source
{
    public class JsonMapSource2D : AMapSource2D
    {
        public override bool Initialized { get; protected set; }
        public sealed override IEnumerable<IStaticObject2D> MapObjects { get; protected set; }
        public sealed override ICollection<IInteractableObject2D> Interactables { get; protected set; }

        protected IList<DummyInteractable> DummyInteractables;
        protected readonly IReader Reader;
        protected readonly IConfigurationQuery Query;
        protected string MapDataBase64;
        protected int[,] Data;

        public JsonMapSource2D(string filePath, IServiceProvider provider, int col, int row, Color? bgColor = null, ICollection<IInteractableObject2D>? interactables = null, bool bypass = false) : base(provider, bgColor ?? Color.Black)
        {
            var queryFactory = provider.GetRequiredService<IConfigurationQueryFactory>();
            Query = queryFactory.CreateConfigurationQuery(filePath);
            Reader = provider.GetRequiredService<IReader>();
            Initialized = Query.GetBoolAttribute("initialized") ?? false;
            if (Initialized && !bypass)
            {
                ColumnCount = Query.GetIntAttribute("col") ??  throw new InvalidOperationException("Draft config is missing a 'row;");
                RowCount = Query.GetIntAttribute("row") ??  throw new InvalidOperationException("Draft config is missing a 'col'");
                MapDataBase64 = Query.GetStringAttribute("data") ??  throw new InvalidOperationException("Draft config is missing the 'data'");
                DummyInteractables = Query.GetObject<List<DummyInteractable>>("interactables") ?? new List<DummyInteractable>();
                Interactables = DummyInteractables.Select(i => GetInteractableConverter()(i.ColorId, i.X, i.Y)).ToList();
                MapObjects = ConvertDataToObjects();
                Data = Get2DMap();
            }
            else
            {
                ColumnCount = col;
                RowCount = row;
                Data = GetDefaultMap();
                Interactables = interactables ?? new List<IInteractableObject2D>();
                DummyInteractables = Interactables.Select(i => new DummyInteractable(i)).ToList();
                filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
                Query = provider.GetRequiredService<IConfigurationQueryFactory>().CreateConfigurationQuery(filePath);
                Reader = provider.GetRequiredService<IReader>();
                MapDataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetRawData()));
                MapObjects = ConvertDataToObjects();
            }
        }

        public JsonMapSource2D(IServiceProvider provider, int col, int row, Color? bgColor = null,
            ICollection<IInteractableObject2D>? interactables = null, bool bypass = false) : this(
            Path.Join(".", "temp.json"), provider, col, row, bgColor, interactables, bypass)
        { }

        public JsonMapSource2D(string filePath, IServiceProvider provider, Color bgColor) : base(provider, bgColor)
        {
            var queryFactory = provider.GetRequiredService<IConfigurationQueryFactory>();
            filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            Query = queryFactory.CreateConfigurationQuery(filePath);
            Reader = provider.GetRequiredService<IReader>();
            ColumnCount = Query.GetIntAttribute("col") ??  throw new InvalidOperationException("Draft config is missing a 'row;");
            RowCount = Query.GetIntAttribute("row") ??  throw new InvalidOperationException("Draft config is missing a 'col'");
            MapDataBase64 = Query.GetStringAttribute("data") ??  throw new InvalidOperationException("Draft config is missing the 'data'");
            DummyInteractables = Query.GetObject<List<DummyInteractable>>("interactables") ?? new List<DummyInteractable>();
            Interactables = DummyInteractables.Select(i => GetInteractableConverter()(i.ColorId, i.X, i.Y)).ToList();
            MapObjects = ConvertDataToObjects();
            Data = Get2DMap();
        }
        
        public JsonMapSource2D(IServiceProvider provider, Color bgColor) : this(
            Path.Join(".", "temp.json"), provider, bgColor)
        { }
        
        public override void SaveLayout(IEnumerable<IStaticObject2D> updatedMapObjects, IEnumerable<IInteractableObject2D> updatedUnits)
        {
            Interactables = updatedUnits.ToList();
            MapObjects = updatedMapObjects;
            Query.SetAttribute("col", ColumnCount);
            Query.SetAttribute("row", RowCount);
            Data = Get2DMap();
            DummyInteractables = Interactables.Select(i => new DummyInteractable(i)).ToList();
            MapDataBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(GetRawData()));
            Query.SetObject("data", MapDataBase64);
            Query.SetObject("interactables", DummyInteractables);
            Query.SetAttribute("initialized", true);
        }

        protected IEnumerable<IStaticObject2D> ConvertDataToObjects()
        {
            return ConvertDataToObjects(GetConverter());
        }
        
        protected virtual IEnumerable<IStaticObject2D> ConvertDataToObjects(Func<int, IPosition2D, IStaticObject2D> converter)
        {
            var id = Guid.NewGuid();
            var tempPath = Path.Join(Path.GetTempPath(), $"{id}.txt");
            File.Create(tempPath).Close();
            File.WriteAllText(tempPath, Encoding.UTF8.GetString(Convert.FromBase64String(MapDataBase64)));
            using var stream = new StreamReader(tempPath);
            var mapLayout = Reader.ReadAllLines<int>(stream, int.TryParse, ' ').ToList();
            var list = new List<IStaticObject2D>();
            for (var i = 0; i < mapLayout.Count; i++)
            {
                var row = mapLayout[i].ToList();
                for (var j = 0; j < row.Count; j++)
                {
                    var value = row[j];
                    var position = PositionFactory.CreatePosition(j, i);
                    list.Add(converter(value, position));
                }
            }
            return list;
        }
        
        protected string GetRawData()
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    var tile = Data[i,j];
                    stringBuilder.Append($"{tile} ");
                }
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                stringBuilder.Append(Environment.NewLine);
            }
            return stringBuilder.ToString();
        }

        protected virtual int[,] Get2DMap()
        {
            var map = new int[RowCount, ColumnCount];
            var mapObjectList = MapObjects.ToList();
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    var position = PositionFactory.CreatePosition(j, i);
                    var tile = mapObjectList.FirstOrDefault(t => t.Position.X == position.X && t.Position.Y == position.Y);
                    if (tile is null)
                    {
                        continue;
                    }

                    map[i, j] = ColorConverter.ConvertColorToTileId(tile.TileColor);
                }
            }
            
            return map;
        }

        protected int[,] GetDefaultMap()
        {
            var map = new int[RowCount, ColumnCount];
            for (var i = 0; i < RowCount; i++)
            {
                for (var j = 0; j < ColumnCount; j++)
                {
                    map[i, j] = ColorConverter.ConvertColorToTileId(BgColor);
                }
            }
            
            return map;
        }
    }
}
