using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPTools.UserForm
{
    public partial class ColnumForm : UserControl
    {
        //public static int Width { get => 340; }
        //public static int Height { get => 45; }
        public string ColText { get => colName_Label.Text; set => colName_Label.Text = value; }
        public string ColValue { get => colValue_comboBox.Text; set => colValue_comboBox.Text = value; }
        public void AddColValue(string[] strs)
        {
            strs = strs.OrderBy(p => p).ToArray();
            colValue_comboBox.Items.AddRange(strs);
            this.colValue_comboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            colValue_comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        public ColnumForm()
        {
            InitializeComponent();

        }
    }
}
