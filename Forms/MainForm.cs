using final_programming_project.Objects;
using final_programming_project.Source;

namespace final_programming_project.Forms;

public partial class MainForm : Form
{
    public bool Logout { get; private set; }

    private readonly User user;
    private readonly List<Contract> contracts = new List<Contract>();

    public MainForm(User user)
    {
        InitializeComponent();
        this.user = user;
        if (!this.user.Role.Full_Perm)
        {
            ManageUsersButton.Hide();
            AddContractButton.Hide();
        }
        UsernameLabel.Text = $"Pøihlášen jako \"{user.Name}\"";
        UpdateListView(true);
    }

    private void UpdateListView(bool sql = false)
    {
        if (sql)
        {
            contracts.Clear();
            contracts.AddRange(SQLManager.SelectAll<Contract>(TableName.contracts));
        }
        ContractsListView.Items.Clear();
        foreach (Contract contract in contracts)
        {
            if (contract.Customer.ToLower().Contains(SearchInput.Text.ToLower()) ||
                contract.Description.ToLower().Contains(SearchInput.Text.ToLower()))
                ContractsListView.Items.Add(contract.ToListViewItem());
        }
    }

    private void LogoutButton_Click(object sender, EventArgs e)
    {
        Logout = true;
        Close();
    }

    private void ManageUsersButton_Click(object sender, EventArgs e)
    {
        new UserManagementForm().ShowDialog();
    }

    private void ContractsListView_DoubleClick(object sender, EventArgs e)
    {
        if (ContractsListView.SelectedItems.Count == 0) return;

        int id = int.Parse(ContractsListView.SelectedItems[0].Text);
        // FURTHER IMPLEMENTATION NEEDED
    }

    private void SearchInput_TextChanged(object sender, EventArgs e)
    {
        UpdateListView();
    }

    private void UpdateDataButton_Click(object sender, EventArgs e)
    {
        SearchInput.Text = string.Empty;
        UpdateListView(true);
    }

    private void AddContractButton_Click(object sender, EventArgs e)
    {
        new AddContractForm().ShowDialog();
        UpdateListView(true);
    }
}