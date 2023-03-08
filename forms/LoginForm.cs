using final_programming_project.obj_str;
using final_programming_project.src;

namespace final_programming_project;

public partial class LoginForm : Form
{
    private User? user;

    public LoginForm()
    {
        InitializeComponent();
        UpdateLoginBtnState(null, null);
    }

    public void UpdateLoginBtnState(object? sender, EventArgs? e)
    {
        var inputs = new[] { InputName, InputPassword };
        foreach (var box in inputs)
        {
            if (box.Text == "")
            {
                LoginButton.Enabled = false;
                return;
            }
        }
        LoginButton.Enabled = true;
    }

    public void Login()
    {
        LoginButton.Enabled = false;
        var response = SQLManager.CheckLoginData(InputName.Text, InputPassword.Text);
        if (response.Status == LoginStatus.SUCCESS)
        {
            user = response.User;
            Close();
            return;
        }

        if (response.Status == LoginStatus.PASSWORD_INCORRECT) MessageBox.Show("Password is incorrect!");
        else if (response.Status == LoginStatus.USERNAME_NOT_EXIST) MessageBox.Show("Username is not registered!");
        LoginButton.Enabled = true;
    }

    public User? Exec()
    {
        Application.Run(this);
        return user;
    }

    private void LoginButtonClick(object sender, EventArgs e)
    {
        if (LoginButton.Enabled) Login();
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && LoginButton.Enabled) Login();
    }
}