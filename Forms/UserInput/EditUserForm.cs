using final_programming_project.Objects;
using final_programming_project.Source;

namespace final_programming_project.Forms.UserInput;

public partial class EditUserForm : Form
{
    public EditUserForm(User user)
    {
        User = user;
        InitializeComponent();
        var roles = SQLManager.RegisteredRoles();
        for (var i = 0; i < roles.Count; i++) ComboBoxRole.Items.Add(roles[i].Name);
        InputUsername.Text = user.Name;
        ComboBoxRole.SelectedIndex = ComboBoxRole.FindStringExact(user.Role.Name);
        UpdateActionButtonState();
    }

    public User User { get; set; }

    private void UpdateActionButtonState()
    {
        if (ComboBoxRole.SelectedItem == null)
        {
            ActionButton.Enabled = false;
            return;
        }

        if (InputUsername.Text == "")
        {
            ActionButton.Enabled = false;
            return;
        }

        if (ChangePassCheck.Checked)
        {
            if (InputPassword.Text == "" || InputConfirmPassword.Text == "")
            {
                ActionButton.Enabled = false;
                return;
            }

            if (InputPassword.Text != InputConfirmPassword.Text)
            {
                ActionButton.Enabled = false;
                return;
            }
        }

        ActionButton.Enabled = true;
    }

    private void UnputChanged(object? sender, EventArgs? e)
    {
        UpdateActionButtonState();
    }

    private void EditUser()
    {
        SQLManager.EditUser(User.ID, InputUsername.Text, ComboBoxRole.Text,
            ChangePassCheck.Checked ? InputPassword.Text : null);
        Close();
    }

    private void ActionButtonClick(object sender, EventArgs e)
    {
        if (ActionButton.Enabled) EditUser();
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter && ActionButton.Enabled) EditUser();
    }

    private void ChangePassCheckChanged(object sender, EventArgs e)
    {
        InputConfirmPassword.Enabled = ChangePassCheck.Checked;
        InputPassword.Enabled = ChangePassCheck.Checked;
        UpdateActionButtonState();
    }
}