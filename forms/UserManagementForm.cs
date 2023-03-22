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
            ListViewItem item = new()
            {
                Text = user.ID.ToString()
            };
            item.SubItems.Add(user.Name);
            item.SubItems.Add(user.Role.Name);
            userView.Items.Add(item);
        }
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        EditBtn.Enabled = userView.SelectedIndices.Count == 1;
        RemoveBtn.Enabled = userView.SelectedIndices.Count == 1;
    }

    private void regUserBtn_Click(object sender, EventArgs e)
    {
        new RegisterUserForm().ShowDialog();
        UpdateUserView();
    }

    private void UserSelectionChanged(object? sender, EventArgs? e)
    {
        UpdateButtons();
    }

    private void RemoveBtn_Click(object sender, EventArgs e)
    {
        if (userView.SelectedIndices.Count == 0) return;
        ListViewItem item = userView.SelectedItems[0];
        DialogResult response = MessageBox.Show(
            "Opravdu chcete vymazat uživatele s ID '" + item.Text + "'?",
            "Vymazání uživatele",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );
        if (response == DialogResult.Yes)
        {
            SQLManager.RemoveUserByID(int.Parse(item.Text));
            UpdateUserView();
        }
    }

    private void EditBtn_Click(object sender, EventArgs e)
    {
        if (userView.SelectedIndices.Count == 0) return;
        ListViewItem item = userView.SelectedItems[0];
        Role role = SQLManager.GetRoleByName(item.SubItems[2].Text);
        new EditUserForm(new User(int.Parse(item.Text), item.SubItems[1].Text, role)).ShowDialog();
        UpdateUserView();
    }
}
