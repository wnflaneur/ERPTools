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
    public partial class DataShow : Form
    {
        public DataShow()
        {
            InitializeComponent();
        }
        public DataShow(DataTable dt) : this()
        {
            scrDataGridView1.SetBindingSource(dt);
            scrDataGridView1.CellDoubleClickEvent += new CellDoubleClickHandler(CellDoubleClick);
        }
        public void CellDoubleClick(int colindex, DataRow dr)
        {
        }

        public void SetScrDataGrid()
        {
            scrDataGridView1.SetDataGridView();
        }
    }
}
