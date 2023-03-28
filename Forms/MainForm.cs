using final_programming_project.Objects;
using final_programming_project.Source;

namespace final_programming_project.Forms;

public partial class MainForm : Form
{
    public bool Logout { get; private set; }

    private readonly User user;
    private List<Contract> contracts = new List<Contract>();

    public MainForm(User user)
    {
        InitializeComponent();
        this.user = user;
        if (!this.user.Role.Full_Perm)
        {
            ManageUsersButton.Hide();
            AddContractButton.Hide();
            EmployeeMngButton.Hide();
            WorkTypeMngButton.Hide();
            RemoveContractButton.Hide();
        }
        UsernameLabel.Text = $"Pøihlášen jako \"{user.Name}\"";
        UpdateListView(true);
    }

    private void UpdateListView(bool sql = false)
    {
        if (sql) contracts = SQLManager.SelectAll<Contract>(TableName.contracts);
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

    private void ManageUsersButton_Click(object sender, EventArgs e) => new UserManagementForm().ShowDialog();

    private void ContractsListView_DoubleClick(object sender, EventArgs e)
    {
        if (ContractsListView.SelectedItems.Count == 0) return;

        new ContractForm(user, contracts[ContractsListView.SelectedIndices[0]]).ShowDialog();
    }

    private void SearchInput_TextChanged(object sender, EventArgs e) => UpdateListView();


    private void UpdateDataButton_Click(object sender, EventArgs e)
    {
        SearchInput.Text = string.Empty;
        UpdateListView(true);
    }

    private void AddContractButton_Click(object sender, EventArgs e)
    {
        new AddOrEditNameDescriptionForm<Contract>("Pøidat zakázku", TableName.contracts).ShowDialog();
        UpdateListView(true);
    }

    private void EmployeeMngButton_Click(object sender, EventArgs e) => new EmployeeManagementForm().ShowDialog();

    private void WorkTypeMngButton_Click(object sender, EventArgs e) => new WorkTypeManagementForm().ShowDialog();

    private void ContractsListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        RemoveContractButton.Enabled = ContractsListView.SelectedItems.Count == 1;
    }

    private void RemoveContractButton_Click(object sender, EventArgs e)
    {
        Contract contract = contracts[ContractsListView.SelectedIndices[0]];
        string FIRST_LINE = $"Jste si opravdu jisti, že chcete vymazat zakázku s ID \"{contract.ID}\"?";
        string SECOND_LINE = $"Smazáním této zakázky také smažete všechny její záznamy!";
        if (MSGBoxes.AskConfirm("Vymazání zakázky", $"{FIRST_LINE}\n\n{SECOND_LINE}"))
        {
            SQLManager.RemoveContract(contract);
            UpdateListView(true);
        }
    }
}