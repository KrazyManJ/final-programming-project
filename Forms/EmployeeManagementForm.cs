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
        public EmployeeManagementForm()
        {
            InitializeComponent();
            UpdateListView();
        }

        private void UpdateListView()
        {
            EmployeeListView.Items.Clear();
            foreach (Employee employee in SQLManager.SelectAll<Employee>(TableName.employees)) EmployeeListView.Items.Add(employee.ToListViewItem());
        }
    }
}
