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
    public partial class AddOrEditWorkHoursForms : Form
    {
        public WorkHours? WorkHours { get; private set; }
        public Contract Contract { get; }
        public User User { get; }

        private List<Employee> employees = SQLManager.SelectAll<Employee>(TableName.employees).OrderBy(v => v.FirstName).ToList();
        private List<WorkType> workTypes = SQLManager.SelectAll<WorkType>(TableName.worktypes).OrderBy(v => v.Name).ToList();

        public AddOrEditWorkHoursForms(Contract contract, User user)
        {
            InitializeComponent();
            InitComboBoxes();
            Contract = contract;
            User = user;
            Text = "Přidat Odpracované Hodiny";
            ActionButton.Text = "Přidat";
        }

        public AddOrEditWorkHoursForms(Contract contract, User user, WorkHours workHours)
        {
            InitializeComponent();
            InitComboBoxes();
            Contract = contract;
            User = user;
            WorkHours = workHours;
            Text = "Upravit Odpracované Hodiny";
            ActionButton.Text = "Upravit";


            EmployeeComboBox.SelectedIndex = employees.FindIndex(v => v.ID == workHours.Employee.ID);
            WorkTypeComboBox.SelectedIndex = workTypes.FindIndex(v => v.ID == workHours.WorkType.ID);
            HoursNumeric.Value = WorkHours.Hours;
        }

        private void InitComboBoxes()
        {
            EmployeeComboBox.Items.Clear();
            foreach (Employee employee in employees)
            {
                EmployeeComboBox.Items.Add($"{employee.FirstName} {employee.LastName} (ID: {employee.ID})");
            }
            WorkTypeComboBox.Items.Clear();
            foreach (WorkType workType in workTypes)
            {
                WorkTypeComboBox.Items.Add($"{workType.Name} ({workType.Description})");
            }
        }

        private void ComboBoxValueUpdate(object sender, EventArgs e)
        {
            ActionButton.Enabled = EmployeeComboBox.SelectedItem != null && WorkTypeComboBox.SelectedItem != null;
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            Employee employee = employees[EmployeeComboBox.SelectedIndex];
            WorkType worktype = workTypes[WorkTypeComboBox.SelectedIndex];
            if (WorkHours == null)
            {
                SQLManager.Insert(TableName.workhours, new WorkHours(employee, Contract, worktype, (int)HoursNumeric.Value, User));
            }
            else
            {
                SQLManager.Update(TableName.workhours, WorkHours.ID, new WorkHours(employee, Contract, worktype, (int)HoursNumeric.Value, User));
            }
            Close();
        }
    }
}
