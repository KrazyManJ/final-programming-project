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
    public partial class AddContractForm : Form
    {
        public AddContractForm()
        {
            InitializeComponent();
        }

        public void UpdateButtonStatus(object sender, EventArgs e)
        {
            AddButton.Enabled = CustomerInput.Text != string.Empty && DescriptionInput.Text != string.Empty;
        }

        private void AddContract()
        {
            SQLManager.Add(TableName.contracts, new Contract(CustomerInput.Text, DescriptionInput.Text));
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContract();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && AddButton.Enabled) AddContract();
        }
    }
}
