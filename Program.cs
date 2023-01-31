namespace final_programming_project
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            LoginForm form = new();
            //SQLManager.RegisterUser("admin", "root");
            Application.Run(form);
            if (form.IsLoginSuccess()) Application.Run(new MainForm());
        }
    }
}