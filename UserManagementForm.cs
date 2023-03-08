using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_programming_project;

public partial class UserManagementForm : Form
{
    public UserManagementForm()
    {
        InitializeComponent();
        foreach (User user in SQLManager.RegisteredUsers())
        {
            ListViewItem item = new()
            {
                Text = user.ID.ToString()
            };
            item.SubItems.Add(user.Name);
            item.SubItems.Add(user.Role.Name);
            userView.Items.Add(item);
        }
        userView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }
}
