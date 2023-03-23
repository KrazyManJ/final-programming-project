using System;
using System.Collections;
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
using final_programming_project.utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_programming_project;

public partial class UserManagementForm : Form
{
    public UserManagementForm()
    {
        InitializeComponent();
        UpdateUserView();
        this.UserListView.ListViewItemSorter = lvwColumnSorter;
    }

    private void UpdateUserView()
    {
        UserListView.Items.Clear();
        foreach (User user in SQLManager.RegisteredUsers()) UserListView.Items.Add(user.ToListViewItem());
        UpdateButtons();
    }

    private void UpdateButtons()
    {
        EditBtn.Enabled = UserListView.SelectedIndices.Count == 1;
        RemoveBtn.Enabled = UserListView.SelectedIndices.Count == 1;
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
        if (UserListView.SelectedIndices.Count == 0) return;
        ListViewItem item = UserListView.SelectedItems[0];
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
        if (UserListView.SelectedIndices.Count == 0) return;
        ListViewItem item = UserListView.SelectedItems[0];
        Role role = SQLManager.GetRoleByName(item.SubItems[2].Text);
        new EditUserForm(new User(int.Parse(item.Text), item.SubItems[1].Text, role)).ShowDialog();
        UpdateUserView();
    }


    

    private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();

    private void userView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        string ARROWUP = "↑";
        string ARROWDOWN = "↓";
        foreach (ColumnHeader col in UserListView.Columns)
        {
            if (col.Text.EndsWith(ARROWUP) || col.Text.EndsWith(ARROWDOWN)) col.Text = col.Text[..^2];
        }
        if (e.Column == lvwColumnSorter.SortColumn)
        {
            // Reverse the current sort direction for this column.
            if (lvwColumnSorter.Order == SortOrder.Ascending)
            {
                lvwColumnSorter.Order = SortOrder.Descending;
                ColumnHeader h = UserListView.Columns[e.Column];
                h.Text += " " + ARROWUP;
            }
            else
            {
                lvwColumnSorter.Order = SortOrder.Ascending;
                ColumnHeader h = UserListView.Columns[e.Column];
                h.Text += " "+ARROWDOWN;
            }
        }
        else
        {
            lvwColumnSorter.SortColumn = e.Column;
            lvwColumnSorter.Order = SortOrder.Ascending;
            ColumnHeader h = UserListView.Columns[e.Column];
            h.Text += " " + ARROWDOWN;
        }
        UserListView.Sort();
    }
}
