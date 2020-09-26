using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPTools.UserForm
{
    public partial class MachineNumberForm : Form
    {
        public string projectNumber;
        public int number = 0;
        public MachineNumberForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            projectNumber = projectNumber_Text.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
