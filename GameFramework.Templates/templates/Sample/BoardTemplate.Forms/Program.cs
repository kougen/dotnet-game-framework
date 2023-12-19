using BoardTemplate.Forms.Views.Main;
using BoardTemplate.Game;
using GameFramework.Application;
using Microsoft.Extensions.DependencyInjection;

namespace BoardTemplate.Forms;

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
            Gameplay.Application2D = Application;
            if (mainWindow is MainWindow window)
            {
                System.Windows.Forms.Application.Run(window);
            }
        }
    }
}
