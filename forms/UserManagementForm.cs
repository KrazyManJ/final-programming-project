﻿using System;
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

namespace final_programming_project;

public partial class UserManagementForm : Form
{
    public UserManagementForm()
    {
        InitializeComponent();
        UpdateUserView();
    }

    private void UpdateUserView()
    {
        userView.Items.Clear();
        foreach (User user in SQLManager.RegisteredUsers())
        {
            ListViewItem item = new();
            item.Text = user.ID.ToString();
            item.SubItems.Add(user.Name);
            item.SubItems.Add(user.Role.Name);
            userView.Items.Add(item);
        }
        userView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    private void regUserBtn_Click(object sender, EventArgs e)
    {
        new RegisterUserForm().ShowDialog();
        UpdateUserView();
    }
}
