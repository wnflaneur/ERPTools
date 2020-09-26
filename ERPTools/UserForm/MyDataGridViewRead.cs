using ExcelTools.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPTools.UserForm
{
    public partial class MyDataGridViewRead : DataGridView
    {
        public Stack<DataTable> dtStack = new Stack<DataTable>();
        public MyDataGridViewRead()
        {
            InitializeComponent();
            ToolsBox.DataGridViewPrettify(this);
            var ft = new Font(this.ColumnHeadersDefaultCellStyle.Font.FontFamily, this.ColumnHeadersDefaultCellStyle.Font.Size);
            //this.ColumnHeadersDefaultCellStyle.Font = ft;
            this.DefaultCellStyle.Font = ft;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
        }

        private void MyDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
            e.RowBounds.Location.Y,
            this.RowHeadersWidth - 4,
            e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   this.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   this.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void MyDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.C) 
            {
                string text = this.CurrentCell.Value.ToString();
                Clipboard.SetDataObject(text, true);
            }
        }
    }
}
