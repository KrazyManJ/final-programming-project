using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_programming_project
{
    public partial class LoginForm : Form
    {
        private bool Success = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        public void Login()
        {
            LoginResponse response = SQLManager.CheckLoginData(Input_Name.Text, Input_Password.Text);
            if (response == LoginResponse.SUCCESS)
            {
                Success = true;
                Close();
            }
            else if (response == LoginResponse.PASSWORD_INCORRECT) MessageBox.Show("Password is incorrect!");
            else if (response == LoginResponse.USERNAME_NOT_EXIST) MessageBox.Show("Username is not registered!");
        }

        public bool IsLoginSuccess() { return Success; }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            Login();
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
        }
    }
}
