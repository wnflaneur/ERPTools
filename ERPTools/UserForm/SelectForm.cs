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
    public partial class SelectForm : Form
    {
        private string cItem = null;
        public string CItem { get { return cItem; } set { if (value.Equals("")) cItem = null; else cItem = value; } }
        private string resermand = null;
        public string Resermand { get { return resermand; } set { if (value.Equals("")) resermand = null; else resermand = value; } }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public SelectForm()
        {
            InitializeComponent();
        }

        private void SelectForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            startDateTime.Value = DateTime.Now.AddDays(-30);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CItem = textBox1.Text;
            Resermand = textBox2.Text;
            StartDateTime = startDateTime.Value;
            EndDateTime = endDateTime.Value;
            this.DialogResult = DialogResult.OK;

        }
    }
}
