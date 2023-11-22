using System.Collections.ObjectModel;
using GameFramework.Objects;
using GameFramework.Objects.Static;
using GameFramework.Visuals.Handlers;

namespace GameFramework.Visuals.Views
{
    public interface IMapView2D
    {
        public ObservableCollection<IStaticObject2D> MapObjects { get; set; }
        public ObservableCollection<IDisposableStaticObjectView> DisposableObjectViews { get; set; }
        void Attach(IMouseHandler mouseHandler);
    }
}
