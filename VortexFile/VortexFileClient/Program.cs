using VortexFileClient.Forms;

namespace VortexFileClient;

static class Program
{
    public static MainForm MainForm = new MainForm();
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(MainForm);
    }    
}