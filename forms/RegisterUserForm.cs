using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using final_programming_project.obj_str;
using final_programming_project.src;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            UpdateRegisterBtnState(null, null);
        }

        private void UpdateRegisterBtnState(object? sender, EventArgs? e)
        {
            if (ComboBoxRole.SelectedItem == null)
            {
                RegisterButton.Enabled = false;
                return;
            }
            var inputs = new[] { InputUsername, InputPassword, InputConfirmPassword };
            foreach (var box in inputs)
            {
                if (box.Text == "")
                {
                    RegisterButton.Enabled = false;
                    return;
                }
            }
            if (InputPassword.Text != InputConfirmPassword.Text)
            {
                RegisterButton.Enabled = false;
                return;
            }
            RegisterButton.Enabled = true;
        }

        private void Register()
        {
            RegisterResponse response = SQLManager.RegisterUser(InputUsername.Text, InputPassword.Text, null);
            if (response == RegisterResponse.ALREADY_EXISTS) 
                MessageBox.Show("Uživatel s tímto jménem již existuje!");
            else
            {
                MessageBox.Show("Uživatel byl zaregistrován!");
                Close();
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (RegisterButton.Enabled) Register();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && RegisterButton.Enabled) Register();
        }
    }
}
