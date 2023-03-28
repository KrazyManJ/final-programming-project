using final_programming_project.Objects;
using final_programming_project.Source;

namespace final_programming_project.Forms
{
    public partial class ContractForm : Form
    {
        public Contract Contract { get; set; }
        public User LoggedUser { get; set; }

        public List<WorkHours> WorkHoursList { get; private set; } = new List<WorkHours>();

        public ContractForm(User loggedUser, Contract contract)
        {
            LoggedUser = loggedUser;
            Contract = contract;
            InitializeComponent();
            UpdateTitleAndDescription();
            UpdateWorkHoursListView(true);
            if (!loggedUser.Role.Full_Perm)
            {
                EditContractInfoButton.Hide();
            }
        }

        public void UpdateWorkHoursListView(bool sql = false)
        {
            if (sql) WorkHoursList = SQLManager.GetWorkHours(Contract);
            WorkHoursListView.Items.Clear();
            foreach (WorkHours workHours in WorkHoursList) WorkHoursListView.Items.Add(workHours.ToListViewItem());
        }

        public void UpdateTitleAndDescription()
        {
            TitleLabel.Text = Contract.Name;
            DescriptionLabel.Text = Contract.Description;
        }

        private void EditContractInfoButton_Click(object sender, EventArgs e)
        {
            var form = new AddOrEditNameDescriptionForm<Contract>("Upravit zakázku", TableName.contracts, Contract);
            form.ShowDialog();
            if (form.Value != null)
            {
                Contract = form.Value;
                UpdateTitleAndDescription();
            }
        }

        private void UpdateDataButton_Click(object sender, EventArgs e) => UpdateWorkHoursListView(true);
    }
}
