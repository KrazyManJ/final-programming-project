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
                EditWorkHoursButton.Hide();
            }
        }

        public void UpdateWorkHoursListView(bool sql = false)
        {
            if (sql) WorkHoursList = SQLManager.GetWorkHours(Contract);
            WorkHoursListView.Items.Clear();
            foreach (WorkHours workHours in WorkHoursList) WorkHoursListView.Items.Add(workHours.ToListViewItem());
            UpdateButtonState();
        }

        public void UpdateTitleAndDescription()
        {
            TitleLabel.Text = Contract.Name;
            DescriptionLabel.Text = Contract.Description;
        }

        public void UpdateButtonState()
        {
            EditWorkHoursButton.Enabled = WorkHoursListView.SelectedIndices.Count == 1;
            if (WorkHoursListView.SelectedIndices.Count == 1)
            {
                WorkHours workHours = WorkHoursList[WorkHoursListView.SelectedIndices[0]];
                if (LoggedUser.Role.Full_Perm)
                {
                    RemoveWorkHoursButton.Enabled = true;
                }
                else
                {
                    RemoveWorkHoursButton.Enabled = workHours.InsertUser.ID == LoggedUser.ID && workHours.InsertDate.Date == DateTime.Now.Date;
                }
            }
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

        private void AddWorkHoursButton_Click(object sender, EventArgs e)
        {
            new AddOrEditWorkHoursForms(Contract, LoggedUser).ShowDialog();
            UpdateWorkHoursListView(true);
        }

        private void EditWorkHoursButton_Click(object sender, EventArgs e)
        {
            new AddOrEditWorkHoursForms(Contract, LoggedUser, WorkHoursList[WorkHoursListView.SelectedIndices[0]]).ShowDialog();
            UpdateWorkHoursListView(true);
        }

        private void WorkHoursListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonState();
        }

        private void RemoveWorkHoursButton_Click(object sender, EventArgs e)
        {
            WorkHours workHours = WorkHoursList[WorkHoursListView.SelectedIndices[0]];
            if (MSGBoxes.AskConfirm("Odstranění záznamu", $"Opravdu chcete odstranit záznam s ID \"{workHours.ID}\""))
            {
                SQLManager.RemoveById(TableName.workhours, workHours.ID);
                UpdateButtonState();
            }
        }
    }
}
