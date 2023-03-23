using final_programming_project.obj_str;
using final_programming_project.src;
using final_programming_project.utils;

namespace final_programming_project;

public partial class UserManagementForm : Form
{
    private List<User> users = new List<User>();

    public UserManagementForm()
    {
        InitializeComponent();
        UpdateUserView(true);
        UserListView.ListViewItemSorter = lvwColumnSorter;

    }

    private void UpdateUserView(bool loadData = false)
    {
        if (loadData)
        {
            users = SQLManager.RegisteredUsers();
            ComboBoxRole.Items.Clear();
            ComboBoxRole.Items.Add("Všechny");
            foreach (var role in SQLManager.RegisteredRoles()) ComboBoxRole.Items.Add(role.Name);
            ComboBoxRole.SelectedIndex = 0;
        }
        UserListView.Items.Clear();
        foreach (User user in users)
        {
            if ((user.Role.Name == ComboBoxRole.Text || ComboBoxRole.SelectedIndex == 0) && user.Name.Contains(SearchInput.Text))
                UserListView.Items.Add(user.ToListViewItem());
        }
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
        UpdateUserView(true);
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
            UpdateUserView(true);
        }
    }

    private void EditBtn_Click(object sender, EventArgs e)
    {
        if (UserListView.SelectedIndices.Count == 0) return;
        ListViewItem item = UserListView.SelectedItems[0];
        Role role = SQLManager.GetRoleByName(item.SubItems[2].Text);
        new EditUserForm(new User(int.Parse(item.Text), item.SubItems[1].Text, role)).ShowDialog();
        UpdateUserView(true);
    }

    private ListViewColumnSorter lvwColumnSorter = new ListViewColumnSorter();

    private void ColumnClick(object sender, ColumnClickEventArgs e)
    {
        string ARROWUP = "↑";
        string ARROWDOWN = "↓";
        foreach (ColumnHeader col in UserListView.Columns)
        {
            if (col.Text.EndsWith(ARROWUP) || col.Text.EndsWith(ARROWDOWN)) col.Text = col.Text[..^2];
        }
        if (e.Column == lvwColumnSorter.SortColumn)
        {
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
                h.Text += " " + ARROWDOWN;
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

    private void UpdateDataButton_Click(object sender, EventArgs e)
    {
        UpdateUserView(true);
    }

    private void ComboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateUserView();
    }

    private void SearchInput_TextChanged(object sender, EventArgs e)
    {
        UpdateUserView();
    }
}
