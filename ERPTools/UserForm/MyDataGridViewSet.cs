using ExcelTools.Src;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPTools.UserForm
{
    public partial class MyDataGridViewSet : DataGridView
    {
        public Stack<DataTable> dtStack = new Stack<DataTable>();
        public MyDataGridViewSet()
        {
            InitializeComponent();
            ToolsBox.DataGridViewPrettify_Set(this);
            var ft = new Font(this.ColumnHeadersDefaultCellStyle.Font.FontFamily, this.ColumnHeadersDefaultCellStyle.Font.Size + 1);
            //this.ColumnHeadersDefaultCellStyle.Font = ft;
            this.DefaultCellStyle.Font = ft;
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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


        #region 粘贴数据
        private void Copy()
        {
            try
            {
                IDataObject idataObject = Clipboard.GetDataObject();
                string da = Clipboard.GetText();
                string[] s = idataObject.GetFormats();
                Console.WriteLine(da.Length);
                //foreach (var sl in s) 
                //{
                //    Console.WriteLine(da);
                //}

                DataTable dt = (DataTable)this.DataSource;
                Copy(da, dt, this.CurrentCell.RowIndex, this.CurrentCell.ColumnIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return;
        }

        private void Copy(string data1, DataTable table, int rowStart, int columnStart)
        {
            string clipboardText = Clipboard.GetText(); //获取剪贴板中的内容

            if (data1.Trim().Length < 1) { return; }
            try
            {
                int colnum = 0;
                int rownum = 0;
                for (int i = 0; i < clipboardText.Length; i++)
                {
                    if (clipboardText.Substring(i, 1).Equals("\t"))
                    {
                        colnum++;
                    }
                    if (clipboardText.Substring(i, 1).Equals("\r"))
                    {
                        rownum++;
                    }
                }
                //粘贴板上的数据来源于EXCEL时，每行末尾都有\n，来源于DataGridView是，最后一行末尾没有\n
                if (clipboardText.Substring(clipboardText.Length - 1, 1) == "\n")
                {
                    rownum--;
                }
                colnum = colnum / (rownum + 1);
                object[,] data; //定义object类型的二维数组
                data = new object[rownum + 1, colnum + 1];  //根据剪贴板的行列数实例化数组
                string rowStr = "";
                //对数组各元素赋值
                for (int i = 0; i <= rownum; i++)
                {
                    for (int j = 0; j <= colnum; j++)
                    {
                        //一行中的其它列
                        if (j != colnum)
                        {
                            rowStr = clipboardText.Substring(0, clipboardText.IndexOf("\t"));
                            clipboardText = clipboardText.Substring(clipboardText.IndexOf("\t") + 1);
                        }
                        //一行中的最后一列
                        if (j == colnum && clipboardText.IndexOf("\r") != -1)
                        {
                            rowStr = clipboardText.Substring(0, clipboardText.IndexOf("\r"));
                        }
                        //最后一行的最后一列
                        if (j == colnum && clipboardText.IndexOf("\r") == -1)
                        {
                            rowStr = clipboardText.Substring(0);
                        }
                        data[i, j] = rowStr;
                    }
                    //截取下一行及以后的数据
                    clipboardText = clipboardText.Substring(clipboardText.IndexOf("\n") + 1);
                }
                clipboardText = Clipboard.GetText();

                for (int i = 0; i <= rownum; i++)
                {
                    DataRow row;
                    #region 如果datagridview中行数不够，就自动增加行
                    if ((i + rowStart) > table.Rows.Count - 1)
                    {
                        //添加新行　　　　　　　　　　　　
                        row = table.NewRow();
                        table.Rows.Add(row);
                    }
                    else
                    {
                        row = table.Rows[rowStart + i];
                    }


                    #endregion
                    row.BeginEdit();
                    for (int j = 0; j <= colnum; j++)//将值赋值过去---如果datagridview中没有自动增加列
                    {
                        //#region 需要判断单元格是不是只读的，是只读的就不用不赋值
                        //bool iszd = this.dataGridView1.Rows[i + rowStart].Cells[j + columnStart].ReadOnly;
                        //if (iszd == true)
                        //{
                        //    continue;
                        //}
                        //#endregion

                        string sjz = "";
                        try
                        {
                            sjz = data[i, j].ToString();
                        }
                        catch { sjz = ""; }
                        if (sjz.Trim().Length < 1) { continue; }//直接复制
                        row[j + columnStart] = sjz;
                    }
                    row.EndEdit();
                }
                table.AcceptChanges();
                this.DataSource = table;
                this.Refresh();

            }
            catch { }
        }
        #endregion



        #region 删除数据
        private void Delete()
        {
            DataTable dt1 = (DataTable)this.DataSource;
            dtStack.Push(dt1.Copy());
            IEnumerator enumerator = this.SelectedCells.GetEnumerator();
            DataTable dt = (DataTable)this.DataSource;
            HashSet<int> hs = new HashSet<int>();
            while (enumerator.MoveNext())
            {
                var cell = enumerator.Current as DataGridViewCell;
                var indexRow = cell.RowIndex;

                hs.Add(indexRow);
            }
            for (int i = 0; i < hs.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        dt.Rows.RemoveAt(hs.ElementAt(i));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            dt.AcceptChanges();
        }
        #endregion

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            if (e.ClickedItem == 添加一行ToolStripMenuItem)
            {
                Add();
            }
            else if (e.ClickedItem == 删除ToolStripMenuItem1)
            {
                Delete();
            }
            else if (e.ClickedItem == 清空所选内容ToolStripMenuItem)
            {
                Clear();
            }
            else if (e.ClickedItem == 清空整列toolStripMenuItem)
            {
                ClearCol();
            }
            else if (e.ClickedItem == 清空整行toolStripMenuItem1)
            {
                ClearRow();
            }
        }
        private void ClearCol()
        {
            DataTable dt = (DataTable)this.DataSource;
            dtStack.Push(dt.Copy());
            IEnumerator enumerator = this.SelectedCells.GetEnumerator();
            HashSet<int> hashSet = new HashSet<int>();
            while (enumerator.MoveNext())
            {
                var cell = enumerator.Current as DataGridViewCell;
                var indexCol = cell.ColumnIndex;
                var indexRow = cell.RowIndex;
                hashSet.Add(indexCol);
            }
            foreach (int index in hashSet)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[index] = "";
                }
            }
            dt.AcceptChanges();
        }
        private void ClearRow()
        {
            DataTable dt = (DataTable)this.DataSource;
            dtStack.Push(dt.Copy());
            IEnumerator enumerator = this.SelectedCells.GetEnumerator();
            HashSet<int> hashSet = new HashSet<int>();
            while (enumerator.MoveNext())
            {
                var cell = enumerator.Current as DataGridViewCell;
                var indexCol = cell.ColumnIndex;
                var indexRow = cell.RowIndex;
                hashSet.Add(indexRow);
            }
            foreach (int index in hashSet)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    dt.Rows[index][col.ColumnName] = "";
                }
            }
            dt.AcceptChanges();

        }
        private void Add()
        {
            DataRow dr = ((DataTable)this.DataSource).NewRow();
            int index = this.CurrentCell.RowIndex;
            DataTable dt = (DataTable)this.DataSource;
            dt.Rows.InsertAt(dr, index);
        }

        private void Clear()
        {
            DataTable dt = (DataTable)this.DataSource;
            dtStack.Push(dt.Copy());
            IEnumerator enumerator = this.SelectedCells.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var cell = enumerator.Current as DataGridViewCell;
                var indexCol = cell.ColumnIndex;
                var indexRow = cell.RowIndex;
                cell.Value = "";
            }
            dt.AcceptChanges();
        }


        private void MyDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.V)
            {
                DataTable dt = (DataTable)this.DataSource;
                dtStack.Push(dt.Copy());
                Copy();
            }
            else if (e.Modifiers.CompareTo(Keys.Control) == 0 && e.KeyCode == Keys.Z)
            {
                if (dtStack.Count > 0)
                {
                    DataTable dt = dtStack.Pop();
                    this.DataSource = null;
                    this.DataSource = dt;
                    this.Refresh();
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                this.CurrentCell.Value = "";
            }
        }

        private void MyDataGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DataTable dt = (DataTable)this.DataSource;
            dtStack.Push(dt.Copy());
        }

        private void MyDataGridView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            ((IEditableObject)this.CurrentRow.DataBoundItem).EndEdit();
        }
    }
}
