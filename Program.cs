namespace final_programming_project;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        bool login;
        do
        {
            login = false;
            var user = new LoginForm().Exec();
            if (user == null) continue;
            MainForm main = new(user);
            Application.Run(main);
            if (main.Logout) login = true;
        } while (login);
    }
}