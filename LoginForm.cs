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
            // Fixed values just for testing
            if (Input_Name.Text == "admin" && Input_Password.Text == "root")
            {
                Success = true;
                Close();
            }
            else MessageBox.Show("Password is incorrect!");
            
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
