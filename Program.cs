using final_programming_project.Forms;
using final_programming_project.Objects;
using final_programming_project.Source;

namespace final_programming_project;

internal static class Program
{
    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();

        if (SQLManager.SelectAll<User>(TableName.users).Count == 0)
        {
            SQLManager.RegisterUser("admin", "root", "admin");
            SQLManager.RegisterUser("guest", "123", null);
        }
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