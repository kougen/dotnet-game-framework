using GameFramework.Application;
using GameFramework.Forms.Views.Main;
using Microsoft.Extensions.DependencyInjection;

namespace GameFramework.Forms
{
    static class Program
    {
        public static IApplication2D Application { get; } = new ProgramCore();
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var scope = Application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                
                var mainWindow = provider.GetRequiredService<IMainWindow>();

                if (mainWindow is MainWindow window)
                {
                    System.Windows.Forms.Application.Run(window);
                }
            }
        }
    }
}
