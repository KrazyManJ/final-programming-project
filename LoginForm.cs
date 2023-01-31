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
        private User? user = null;

        public User User => user;

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
            else if (Input_Password.Text == "")
            {
                MessageBox.Show("Password parameter missing!");
                return;
            }
            LoginResponse response = SQLManager.CheckLoginData(Input_Name.Text, Input_Password.Text);
            if (response.Status == LoginStatus.SUCCESS)
            {
                user = response.User;
                Close();
            }
            else if (response.Status == LoginStatus.PASSWORD_INCORRECT) MessageBox.Show("Password is incorrect!");
            else if (response.Status == LoginStatus.USERNAME_NOT_EXIST) MessageBox.Show("Username is not registered!");
        }

        public User? GetLoggedUser()
        {
            return this.user;
        }

        public bool IsLoginSuccess() { return this.user != null; }

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
