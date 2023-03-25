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
            foreach (Employee employee in employees) EmployeeListView.Items.Add(employee.ToListViewItem());
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
            new AddOrEditEmployee().ShowDialog();
            UpdateListView(true);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            new AddOrEditEmployee(employees[EmployeeListView.SelectedIndices[0]]).ShowDialog();
            UpdateListView(true);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            SQLManager.RemoveById(TableName.employees, employees[EmployeeListView.SelectedIndices[0]].ID);
            UpdateListView(true);
        }
    }
}
