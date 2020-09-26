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
    public delegate DataTable Fun_Delegate(Dictionary<string, string> dict);
    public partial class ChildrenForm : UserControl
    {
        public ChildrenForm()
        {
            InitializeComponent();
        }
        public ChildrenForm(DataTable dt) : this()
        {
            scrDataGridView1.SetBindingSource(dt);
            scrDataGridView1.CellDoubleClickEvent += new CellDoubleClickHandler(CellDoubleClick);
        }
        public CellDoubleClickHandler CellDouble;
        public void CellDoubleClick(int colindex, DataRow dr)
        {
            if (CellDouble != null) 
            {
                CellDouble(colindex,dr);
            }
        }

        public void SetScrDataGrid()
        {
            scrDataGridView1.SetDataGridView();
        }
    }
}
