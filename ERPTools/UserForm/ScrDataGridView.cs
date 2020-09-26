using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataGridViewAutoFilter;
using System.Reflection;
using System.Runtime.InteropServices;
using ExcelTools.Src;

namespace ERPTools.UserForm
{
    public delegate void CellDoubleClickHandler(int colindex, DataRow dataTable);
    public partial class ScrDataGridView : UserControl
    {
        public CellDoubleClickHandler CellDoubleClickEvent;
        private DataTable oldTable;
        private DataTable dataTable;
        private DataTable newdt;
        private Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        List<object> colHeaderList = new List<object>();

        public void SetBindingSource(DataTable data)
        {

            myDataGridViewRead1.DataSource = data;
            dataTable = data.Copy();
            Show();
        }

        public void SetDataGridView()
        {
            myDataGridViewRead1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        public DataTable DataSource
        {
            get => dataTable;
            set { dataTable = value; Show(); }
        }
        public void Show()
        {
            if (dataTable != null)
            {
                dict.Clear();
                oldTable = dataTable.Copy();
                newdt = dataTable.Copy();
                pagerControl1.PageIndex = 1;
                LoadData();
                myDataGridViewRead1.DataSource= newdt;
            }
        }
        public ScrDataGridView()
        {
            InitializeComponent();
            userScr1.SendToBack();
            pagerControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
        }
        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            userScr1.SendToBack();
            LoadData();
        }
        void LoadData()
        {
            int count = dataTable.Rows.Count;
            newdt.Clear();
            for (int i = 0; i < pagerControl1.PageSize; i++)
            {
                int index = i + (pagerControl1.PageIndex - 1) * pagerControl1.PageSize;
                if (index>=0&&index < count)
                {
                    newdt.Rows.Add(dataTable.Rows[index].ItemArray);
                }
                else
                {
                    break;
                }

            }
            pagerControl1.DrawControl(count);
            //// 调整列的大小以适应其内容。
        }

        private void 筛选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (colHeaderList.Count > 0)
            {
                int i = 0;
                foreach (DataGridViewColumn col in myDataGridViewRead1.Columns)
                {
                    col.HeaderCell = colHeaderList.ElementAt(i) as DataGridViewColumnHeaderCell;
                    i++;
                }
                colHeaderList.Clear();
            }
            else
            {
                //将"自动筛选"标题单元格添加到每一列。
                foreach (DataGridViewColumn col in myDataGridViewRead1.Columns)
                {
                    colHeaderList.Add(colHeaderList);
                    col.HeaderCell = new
                        DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell);
                }
            }
            this.Cursor = Cursors.Default;

            userScr1.SendToBack();
            //// 调整列的大小以适应其内容。
            myDataGridViewRead1.AutoResizeColumns();
        }

        public void UserScr(int colindex)
        {
            try
            {
                string name = myDataGridViewRead1.Columns[colindex].Name;
                Type strtype = oldTable.Columns[colindex].DataType;
                int dgvX = myDataGridViewRead1.Location.X;
                int dgvY = myDataGridViewRead1.Location.Y;
                int cellX = myDataGridViewRead1.GetCellDisplayRectangle(colindex, -1, false).X;
                int width = myDataGridViewRead1.GetCellDisplayRectangle(colindex, -1, false).Width;
                int cellY = myDataGridViewRead1.GetCellDisplayRectangle(colindex, -1, false).Y;
                int x = dgvX + cellX;
                x = x - userScr1.Width + width;
                int y = dgvY + cellY;
                if (x < 0)
                {
                    x = 0;
                }
                if (strtype != typeof(System.DateTime))
                {
                    DataTable data = Select(name);
                    HashSet<string> hashSet = new HashSet<string>();
                    foreach (DataRow row in data.Rows)
                    {
                        if (row[colindex] != DBNull.Value)
                        {
                            if (!row[colindex].ToString().Equals(""))
                                hashSet.Add(row[colindex].ToString());
                        }
                    }
                    if (dict.ContainsKey(name))
                    {
                        userScr1.OldList = dict[name];
                    }
                    else
                    {
                        userScr1.OldList = null;
                    }
                    userScr1.ColName = name;
                    userScr1.inColList = hashSet.ToList();
                    userScr1.Show(new Point(x, y));
                }
                else
                {
                    userScr1.ColName = name;
                    userScr1.Show(new Point(x, y), num: 1);

                }
            }
            catch
            {
                return;
            }

        }

        public void Select(string colName, string value)
        {
            if (dict.ContainsKey(colName))
            {
                dict.Remove(colName);
            }
            DataTable data = oldTable.Copy();
            foreach (var key in dict.Keys)
            {
                List<string> colList = dict[key];
                data = SelectDataTable(key, colList, data).Copy();
            }
            data = SelectDataTable(colName, value, data).Copy();
            dataTable = data.Copy();
            newdt = dataTable.Copy();
            pagerControl1.PageIndex = 1;
            LoadData();
            myDataGridViewRead1.DataSource = newdt;


        }

        public void Select(string colName, DateTime start, DateTime end)
        {
            if (dict.ContainsKey(colName))
            {
                dict.Remove(colName);
            }
            DataTable data = oldTable.Copy();
            foreach (var key in dict.Keys)
            {
                List<string> colList = dict[key];
                data = SelectDataTable(key, colList, data).Copy();
            }
            data = SelectDataTable(colName, start, end, data).Copy();
            dataTable = data.Copy();
            newdt = dataTable.Copy();
            pagerControl1.PageIndex = 1;
            LoadData();
            myDataGridViewRead1.DataSource = newdt;

        }


        public void Select(string colName, List<string> list)
        {
            if (dict.ContainsKey(colName))
            {
                dict[colName] = list;
            }
            else
            {
                dict.Add(colName, list);
            }
            DataTable data = oldTable.Copy();
            foreach (var key in dict.Keys)
            {
                List<string> colList = dict[key];
                data = SelectDataTable(key, colList, data).Copy();
            }
            dataTable = data.Copy();
            newdt = dataTable.Copy();
            pagerControl1.PageIndex = 1;
            LoadData();
            myDataGridViewRead1.DataSource = newdt;
        }

        public DataTable Select(string colName)
        {
            DataTable data = oldTable.Copy();
            foreach (var key in dict.Keys)
            {
                if (!key.Equals(colName))
                {
                    List<string> colList = dict[key];
                    if (colList != null)
                    {
                        data = SelectDataTable(key, colList, data).Copy();
                    }
                }
            }
            return data;
        }
        public void SelectAll(string colName)
        {
            DataTable data = Select(colName);
            dataTable = data.Copy();
            newdt = dataTable.Copy();
            pagerControl1.PageIndex = 1;
            LoadData();
            myDataGridViewRead1.DataSource = newdt;
        }

        public DataTable SelectDataTable(string colName, DateTime start, DateTime end, DataTable dataTable)
        {
            DataTable data = dataTable.Copy();
            DataTable newdata = dataTable.Copy();
            newdata.Clear();
            List<DataRow> rows = new List<DataRow>();
            string sql;
            sql = string.Format(" [{0}]  >= '{1}' and [{0}] <= '{2}' ", colName, start, end);
            rows.AddRange(data.Select(sql));
            if (rows != null && rows.Count() > 0)
            {
                foreach (var row in rows)
                {
                    newdata.Rows.Add(row.ItemArray);
                }
                data = newdata.Copy();
                newdata.Clear();
            }
            return data;

        }

        public DataTable SelectDataTable(string colName, List<string> list, DataTable dataTable)
        {
            DataTable data = dataTable.Copy();
            DataTable newdata = dataTable.Copy();
            newdata.Clear();
            List<string> colList = list;
            if (colList != null)
            {
                List<DataRow> rows = new List<DataRow>();
                string sql = "";
                int i = 0;
                int index = 0;
                foreach (var str in colList)
                {
                    if (i < 100)
                    {
                        if (str.Equals("空"))
                        {
                            sql += string.Format(" [{0}] is null  OR ", colName);
                        }
                        else
                        {
                            string Name = str;
                            Name = Name.Replace("\r", "");
                            Name = Name.Replace("\n", "");
                            Name = Name.Replace("[", "[[]");
                            Name = Name.Replace("*", "[*]");
                            Name = Name.Replace(".", "[.]");
                            Name = Name.Replace("%", "[%]");
                            sql += string.Format(" convert([{0}],'System.String')  like '{1}' OR ", colName, Name);
                        }
                    }
                    i++;
                    index++;
                    if (i == 100 || index == colList.Count)
                    {
                        sql = sql.Trim();
                        sql = sql.TrimEnd('R');
                        sql = sql.TrimEnd('O');
                        sql = sql.Trim();
                        rows.AddRange(data.Select(sql));
                        sql = "";
                        i = 0;
                    }
                }
                if (rows != null && rows.Count() > 0)
                {
                    foreach (var row in rows)
                    {
                        newdata.Rows.Add(row.ItemArray);
                    }
                    data = newdata.Copy();
                    newdata.Clear();
                }
            }
            return data;
        }

        public DataTable SelectDataTable(string colName, string value, DataTable dataTable, bool isContains = true)
        {
            DataTable data = dataTable.Copy();
            DataTable newdata = dataTable.Copy();
            newdata.Clear();
            List<DataRow> rows = new List<DataRow>();
            string sql;
            string Name = value;
            Name = Name.Replace("\r", "");
            Name = Name.Replace("\n", "");
            Name = Name.Replace("[", "[[]");
            Name = Name.Replace("*", "[*]");
            Name = Name.Replace(".", "[.]");
            Name = Name.Replace("%", "[%]");
            if (isContains)
            {
                sql = string.Format(" convert([{0}],'System.String')  like '%{1}%' ", colName, Name);
            }
            else
            {
                sql = string.Format(" convert([{0}],'System.String')  like '{1}' ", colName, Name);
            }
            rows.AddRange(data.Select(sql));
            if (rows != null && rows.Count() > 0)
            {
                foreach (var row in rows)
                {
                    newdata.Rows.Add(row.ItemArray);
                }
                data = newdata.Copy();
                newdata.Clear();
            }
            return data;

        }

        private void ScrDataGridView_Load(object sender, EventArgs e)
        {
            Type type = this.myDataGridViewRead1.GetType();
            PropertyInfo pi = type.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);

            pi.SetValue(this.myDataGridViewRead1, true, null);


            userScr1.Outevent += new OutHandler(Select);
            userScr1.OutLikeEvent += new OutLikeHandler(Select);
            userScr1.OutAllEvent += new OutAllHandler(SelectAll);
            userScr1.OutTimeEvent += new OutTimeHandler(Select);
            ColEvent.UserScrEvent += new UserScrHandler(UserScr);
        }




        private void myDataGridViewRead1_BindingContextChanged(object sender, EventArgs e)
        {
            // 仅在已设置数据源时继续。
            if (myDataGridViewRead1.DataSource == null)
            {
                return;
            }

        }

        private void myDataGridViewRead1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable data = (DataTable)myDataGridViewRead1.DataSource;
            DataRow dataRow = data.NewRow();
            dataRow = (myDataGridViewRead1.CurrentRow.DataBoundItem as DataRowView).Row;//微软提供的唯一的转换DataRow
            CellDoubleClickEvent(e.ColumnIndex, dataRow);
        }

        private void 显示全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dict.Clear();
            dataTable = oldTable.Copy();
            newdt = dataTable.Copy();
            pagerControl1.PageIndex = 1;
            LoadData();
            myDataGridViewRead1.DataSource = newdt;
            userScr1.SendToBack();
            this.Cursor = Cursors.Default;
        }

        private void myDataGridViewRead1_MouseClick_1(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            int startX = userScr1.Location.X;
            int startY = userScr1.Location.Y;
            int endX = startX + userScr1.Width;
            int endY = startY + userScr1.Height;
            if (x < startX || x > endX || y < startY || y > endY) 
            {
                userScr1.SendToBack();
            }
        }

        private void myDataGridViewRead1_Scroll(object sender, ScrollEventArgs e)
        {
            userScr1.SendToBack();
        }

        private void 导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localFilePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //设置文件类型
            //书写规则例如：txt files(*.txt)|*.txt
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|All files(*.*)|*.*";
            //设置默认文件名（可以不设置）
            saveFileDialog.FileName = "新建.xlsx";
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
    }
}
