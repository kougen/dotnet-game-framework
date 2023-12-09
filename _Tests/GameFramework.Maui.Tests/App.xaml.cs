using System.Diagnostics;
using GameFramework.Impl.Core;
using GameFramework.Objects.Static;
using GameFramework.UI.Maui.Core;
using Implementation.Module;

namespace GameFramework.Maui.Tests
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            
            var moveGestureRecognizer = new PointerGestureRecognizer();
            moveGestureRecognizer.PointerMoved += OnPointerMoved;
        }
        private void OnPointerMoved(object sender, PointerEventArgs e)
        {
            Debug.WriteLine("OnPointerMoved");
        }

        protected override IServiceProvider LoadModules(ServiceCollection collection)
        {
            var source = new CancellationTokenSource();
            var core = new CoreModule(collection, source);
            core.RegisterServices("gf-manual-tests");
            core.RegisterOtherServices(new GameFrameworkCore(collection, source));
            core.RegisterOtherServices(new MauiGameFramework(collection, source));

            return collection.BuildServiceProvider();
        }
    }
}
