namespace final_programming_project;

public partial class MainForm : Form
{
    private readonly User user;

    public MainForm(User user)
    {
        InitializeComponent();
        this.user = user;
        if (!this.user.Role.Full_Perm) mngUsersBtn.Hide();
        UsernameLabel.Text = user.Name + " - " + (user.Role.Full_Perm ? "Full Permission" : "User Permission");
    }

    public bool Logout { get; private set; }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        Logout = true;
        Close();
    }

    private void mngUsersBtn_Click(object sender, EventArgs e)
    {
        new UserManagementForm().ShowDialog();
    }
}