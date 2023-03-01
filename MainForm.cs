namespace final_programming_project
{
    public partial class MainForm : Form
    {
        public bool Logout { get; private set; } = false;

        public MainForm(User user)
        {
            InitializeComponent();
            UsernameLabel.Text = user.Name+" - "+(user.Role.Full_Perm ? "Full Permission" : "User Permission");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout = true;
            Close();
        }
    }
}