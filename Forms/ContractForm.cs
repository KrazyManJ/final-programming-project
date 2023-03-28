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
            TitleLabel.Text = contract.Name;
            DescriptionLabel.Text = contract.Description;
            UpdateWorkHoursListView(true);
        }

        public void UpdateWorkHoursListView(bool sql = false)
        {
            if (sql) WorkHoursList = SQLManager.GetWorkHours(Contract);
            WorkHoursListView.Items.Clear();
            foreach (WorkHours workHours in WorkHoursList) WorkHoursListView.Items.Add(workHours.ToListViewItem());
        }
    }
}
