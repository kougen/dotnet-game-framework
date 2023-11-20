using GameFramework.Application;
using GameFramework.UI.Forms.Core;

namespace GameFramework.ManualTests.Forms;

static class Program
{
    public static IApplication2D Application { get; } = new TestProgramCore();
    
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.ConfigurationService.Dimension = 50;
        System.Windows.Forms.Application.Run(new Form1());
    }
}
