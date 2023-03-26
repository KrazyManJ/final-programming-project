using final_programming_project.Objects;
using final_programming_project.Source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_programming_project.Forms
{
    public partial class WorkTypeManagementForm : Form
    {
        private List<WorkType> worktypes = new List<WorkType>();

        public WorkTypeManagementForm()
        {
            InitializeComponent();
            UpdateListView(true);
        }

        private void UpdateListView(bool sql = false)
        {
            if (sql) worktypes = SQLManager.SelectAll<WorkType>(TableName.worktypes);
            WorkTypeListView.Items.Clear();
            foreach (WorkType worktype in worktypes)
            {
                if (
                    new List<string>() { worktype.Name, worktype.Description }
                    .Any(v => v.ToLower().Contains(SearchInput.Text.ToLower()))
                )
                    WorkTypeListView.Items.Add(worktype.ToListViewItem());
            }
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            RemoveButton.Enabled = WorkTypeListView.SelectedItems.Count == 1;
            EditButton.Enabled = WorkTypeListView.SelectedItems.Count == 1;
        }

        private void EmployeeListView_SelectedIndexChanged(object sender, EventArgs e) => UpdateButtonState();

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddOrEditNameDescriptionForm<WorkType>("Přidat činnost", TableName.worktypes).ShowDialog();
            UpdateListView(true);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            new AddOrEditNameDescriptionForm<WorkType>("Upravit činnost",TableName.worktypes, worktypes[WorkTypeListView.SelectedIndices[0]]).ShowDialog();
            UpdateListView(true);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            SQLManager.RemoveById(TableName.employees, worktypes[WorkTypeListView.SelectedIndices[0]].ID);
            UpdateListView(true);
        }

        private void UpdateDataButton_Click(object sender, EventArgs e) => UpdateListView(true);

        private void SearchInput_TextChanged(object sender, EventArgs e) => UpdateListView();
    }
}
