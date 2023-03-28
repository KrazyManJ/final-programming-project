using final_programming_project.Objects;
using final_programming_project.Source;

namespace final_programming_project.Forms
{
    public partial class EmployeeManagementForm : Form
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeManagementForm()
        {
            InitializeComponent();
            UpdateListView(true);
        }

        private void UpdateListView(bool sql = false)
        {
            if (sql) employees = SQLManager.SelectAll<Employee>(TableName.employees);
            EmployeeListView.Items.Clear();
            foreach (Employee employee in employees)
            {
                if (
                    new List<string>() { employee.FirstName, employee.LastName, employee.Email, employee.PhoneNumber }
                    .Any(v => v.ToLower().Contains(SearchInput.Text.ToLower())))
                    EmployeeListView.Items.Add(employee.ToListViewItem());
            }
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            RemoveButton.Enabled = EmployeeListView.SelectedItems.Count == 1;
            EditButton.Enabled = EmployeeListView.SelectedItems.Count == 1;
        }

        private void EmployeeListView_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonState();

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddOrEditEmployeeForm().ShowDialog();
            UpdateListView(true);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            new AddOrEditEmployeeForm(employees[EmployeeListView.SelectedIndices[0]]).ShowDialog();
            UpdateListView(true);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Employee item = employees[EmployeeListView.SelectedIndices[0]];
            if (MSGBoxes.AskConfirm("Vymazání zaměstnance", $"Opravdu chcete vymazat zaměstnance s ID '{item.ID}'?"))
            {
                if (SQLManager.IsInWorkHours(WorkHoursIndexes.employee, item))
                {
                    MSGBoxes.Error("Zaměstance se nepodařilo vymazat, protože je spojen s tvorbou zápisů do zakázek.");
                    return;
                }
                SQLManager.RemoveById(TableName.employees, item.ID);
                UpdateListView(true);
            }                
        }

        private void UpdateDataButton_Click(object sender, EventArgs e) => UpdateListView(true);

        private void SearchInput_TextChanged(object sender, EventArgs e) => UpdateListView();
    }
}
