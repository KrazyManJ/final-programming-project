using final_programming_project.Forms.UserInput;
using final_programming_project.Objects;
using final_programming_project.Source;

namespace final_programming_project.Forms;

public partial class UserManagementForm : Form
{
    private List<User> users = new();

    public UserManagementForm()
    {
        InitializeComponent();
        UpdateUserView(true);
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
        foreach (var user in users)
            if ((user.Role.Name == ComboBoxRole.Text || ComboBoxRole.SelectedIndex == 0) &&
                user.Name.Contains(SearchInput.Text))
                UserListView.Items.Add(user.ToListViewItem());
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
        var item = UserListView.SelectedItems[0];
        var response = MessageBox.Show(
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
        var item = UserListView.SelectedItems[0];
        var role = SQLManager.GetRoleByName(item.SubItems[2].Text);
        new EditUserForm(new User(int.Parse(item.Text), item.SubItems[1].Text, role)).ShowDialog();
        UpdateUserView(true);
    }

    private void UpdateDataButton_Click(object sender, EventArgs e)
    {
        UpdateUserView(true);
    }

    private void FilterInputChanged(object sender, EventArgs e)
    {
        UpdateUserView();
    }
}