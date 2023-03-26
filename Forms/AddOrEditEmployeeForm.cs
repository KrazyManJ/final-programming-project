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
    public partial class AddOrEditEmployeeForm : Form
    {
        public Employee? Employee { get; set; } = null;

        public AddOrEditEmployeeForm()
        {
            InitializeComponent();
            Text = "Přidat zaměstnance";
            ActionButton.Text = "Přidat";
        }
        public AddOrEditEmployeeForm(Employee employee)
        {
            InitializeComponent();
            Text = "Upravit zaměstnance";
            ActionButton.Text = "Potvrdit";
            Employee = employee;

            FirstNameInput.Text = employee.FirstName;
            LastNameInput.Text = Employee.LastName;
            BirthDatePicker.Value = employee.BirthDate;
            EmailInput.Text = Employee.Email;
            PhoneNumberInput.Text = Employee.PhoneNumber;
        }

        public void UpdateActionButton()
        {
            ActionButton.Enabled = FirstNameInput.Text != string.Empty
                && LastNameInput.Text != string.Empty
                && EmailInput.Text != string.Empty
                && PhoneNumberInput.Text != string.Empty;
        }

        private void AnyTextBoxChanged(object sender, EventArgs e) => UpdateActionButton();

        private void ActionButton_Click(object sender, EventArgs e)
        {

            Employee employee = new Employee(
                        FirstNameInput.Text,
                        LastNameInput.Text,
                        BirthDatePicker.Value,
                        EmailInput.Text,
                        PhoneNumberInput.Text
                );
            if (Employee == null)
            {
                //ADD
                SQLManager.Insert(TableName.employees,employee);
            }
            else
            {
                //EDIT
                SQLManager.Update(TableName.employees, Employee.ID, employee);
            }
            Close();
        }
    }
}
