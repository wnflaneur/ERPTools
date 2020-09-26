using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelTools.Src;

namespace ERPTools.UserForm
{
    public partial class DataTableForm : UserControl
    {
        DataTable dataTable;
        DataTable newdt;
        private SqlProcessor sqlProcessor;
        public DataTableForm()
        {
            InitializeComponent();
            scrDataGridView1.SetDataGridView();
            scrDataGridView1.CellDoubleClickEvent += new CellDoubleClickHandler(CellDoubleClick);
        }
        private void CellDoubleClick(int colindex, DataRow dr) 
        { }
        public DataTableForm(DataTable dt) : this()
        {
            if (dt != null)
            {
                this.dataTable = dt.Copy();
                scrDataGridView1.SetBindingSource(dataTable);
            }
        }
        public DataTableForm(SqlProcessor sqlProcessor) : this()
        {
            this.sqlProcessor = sqlProcessor;
        }


        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localFilePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //设置文件类型
            //书写规则例如：txt files(*.txt)|*.txt
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|All files(*.*)|*.*";
            //设置默认文件名（可以不设置）
            saveFileDialog.FileName = "进度表.xlsx";
            //主设置默认文件extension（可以不设置）
            saveFileDialog.DefaultExt = "xml";
            //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
            saveFileDialog.AddExtension = true;
            //设置默认文件类型显示顺序（可以不设置）
            saveFileDialog.FilterIndex = 2;

            //保存对话框是否记忆上次打开的目录
            saveFileDialog.RestoreDirectory = true;

            // Show save file dialog box
            DialogResult result = saveFileDialog.ShowDialog();
            //点了保存按钮进入
            if (result == DialogResult.OK)
            {
                //获得文件路径
                localFilePath = saveFileDialog.FileName.ToString();
                this.Cursor = Cursors.WaitCursor;
                if (!ExcelOperation.ExportDataTable(dataTable, localFilePath))
                {
                    MessageBox.Show("文件保存失败");
                }
                else
                {
                    if (DialogResult.Cancel == MessageBox.Show("文件导出成功是否需要打开文件?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(localFilePath);
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void 规格名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable data = sqlProcessor.SqlSelfTestNameAndSTD();
            if (data != null)
            {
                dataTable = data;
                scrDataGridView1.SetBindingSource(dataTable);
            }
            this.Cursor = Cursors.Default;
        }

        private void 规格去除特殊字符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable data = sqlProcessor.SQLSelfTestTable_A_Z0_9();
            if (data != null)
            {
                dataTable = data;
                scrDataGridView1.SetBindingSource(dataTable);
            }
            this.Cursor = Cursors.Default;
        }

        private void 规格包含ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable data = sqlProcessor.SQLSelfTestTable_Contains();
            if (data != null)
            {
                dataTable = data;
                scrDataGridView1.SetBindingSource(dataTable);
            }
            this.Cursor = Cursors.Default;
        }

        private void 规格ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable data = sqlProcessor.SQLSelfTestTable();
            if (data != null)
            {
                dataTable = data;
                scrDataGridView1.SetBindingSource(dataTable);
            }
            this.Cursor = Cursors.Default;
        }

        private void 规格名称规格去除特殊字符ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable data = sqlProcessor.SQLSelfTestTable_A_Z0_9NameAndStd();
            if (data != null)
            {
                dataTable = data;
                scrDataGridView1.SetBindingSource(dataTable);
            }
            this.Cursor = Cursors.Default;
        }

        private void 规格包含下划线ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable data = sqlProcessor.SQLSelfTestTable__();
            if (data != null)
            {
                dataTable = data;
                scrDataGridView1.SetBindingSource(dataTable);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
