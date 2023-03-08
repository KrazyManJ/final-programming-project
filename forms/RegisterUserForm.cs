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

namespace final_programming_project
{
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();

            foreach (Role role in SQLManager.RegisteredRoles())
            {
                roleComboBox.Items.Add(role.Name);
            }
        }
    }
}
