using final_programming_project.obj_str;
using final_programming_project.src;

namespace final_programming_project
{
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();
            foreach (Role role in SQLManager.RegisteredRoles())
                ComboBoxRole.Items.Add(role.Name);
            ComboBoxRole.Text = "Zvol roli...";
            UpdateActionButtonState();
        }
        
        private void UpdateActionButtonState()
        {
            if (ComboBoxRole.SelectedItem == null)
            {
                ActionButton.Enabled = false;
                return;
            }
            var inputs = new[] { InputUsername, InputPassword, InputConfirmPassword };
            foreach (var box in inputs)
            {
                if (box.Text == "")
                {
                    ActionButton.Enabled = false;
                    return;
                }
            }
            if (InputPassword.Text != InputConfirmPassword.Text)
            {
                ActionButton.Enabled = false;
                return;
            }
            ActionButton.Enabled = true;
        }

        private void UnputChanged(object? sender, EventArgs? e)
        {
            UpdateActionButtonState();
        }

        private void Register() {
            RegisterResponse response = SQLManager.RegisterUser(InputUsername.Text, InputPassword.Text, null);
            if (response == RegisterResponse.ALREADY_EXISTS)
                MessageBox.Show("Uživatel s tímto jménem již existuje!");
            else
            {
                MessageBox.Show("Uživatel byl zaregistrován!");
                Close();
            }
        }

        private void ActionButtonClick(object sender, EventArgs e)
        {
            if (ActionButton.Enabled) Register();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActionButton.Enabled) Register();
        }
    }
}
