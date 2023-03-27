using final_programming_project.Objects;
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
    public partial class ContractForm : Form
    {
        public Contract Contract { get; set; }

        public ContractForm(Contract contract)
        {
            InitializeComponent();
            Contract = contract;
        }
    }
}
