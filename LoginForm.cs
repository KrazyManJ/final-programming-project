namespace final_programming_project;

public partial class LoginForm : Form
{
    private User? user;

    public LoginForm()
    {
        InitializeComponent();
    }

    public void Login()
    {
        if (Input_Name.Text == "")
        {
            MessageBox.Show("Username parameter missing!");
            return;
        }

        if (Input_Password.Text == "")
        {
            MessageBox.Show("Password parameter missing!");
            return;
        }

        LoginButton.Enabled = false;
        var response = SQLManager.CheckLoginData(Input_Name.Text, Input_Password.Text);
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