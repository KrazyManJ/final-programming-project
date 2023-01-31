namespace final_programming_project
{
    public partial class MainForm : Form
    {
        public MainForm(User user)
        {
            InitializeComponent();
            UsernameLabel.Text = user.Name;
        }
    }
}