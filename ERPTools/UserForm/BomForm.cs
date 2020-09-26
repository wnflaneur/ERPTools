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
using System.Configuration;
using System.Threading;
using System.IO;
using System.Collections;

namespace ERPTools.UserForm
{
    public partial class BomForm : UserControl
    {

        private static bool closeFirst = true;

        private SqlProcessor sqlProcessor;
        private Param param;
        private Param formulaParaml;
        int startRow;
        int startCol;
        string configPath;
        string templateFilePath;
        string temporaryFilePath;
        string useFilePath;
        string colnumStylePath;
        string formulaPath;
        string[] names;
        string[] models;
        string[] newnames;
        string[] newmodels;
        Dictionary<string, string> dictparam;


        private bool ctrl = false; //Ctrl键


        public MenuStrip MenuStrip { get { return this.menuStrip1; } }

        public BomForm()
        {
            InitializeComponent();
        }
        public BomForm(SqlProcessor sql) : this()
        {
            sqlProcessor = sql;
            Form1_Load();
        }

        private void Form1_Load()
        {
            startRow = int.Parse(ConfigurationManager.AppSettings["StartRow"]);
            startCol = int.Parse(ConfigurationManager.AppSettings["StartCol"]);
            configPath = Application.StartupPath + "\\配置文件\\Config.xml";
            templateFilePath = Application.StartupPath + "\\配置文件\\template.XLS";
            temporaryFilePath = Application.StartupPath + "\\Temporary\\" + "BOM临时文件.XLS";
            formulaPath = Application.StartupPath + "\\配置文件\\formula.xml";


            colnumStylePath = Application.StartupPath + "\\配置文件\\template列宽设置.xml";
            Thread thread = new Thread(() =>
            {
                names = sqlProcessor.GetName("");
                models = sqlProcessor.GetModel("");
            });
            thread.Start();
            InitDataGridView();
        }

        /// <summary>
        /// DataGridView页面初始化，加载界面
        /// </summary>
        private void InitDataGridView()
        {
            param = new Param();

            DataKeep.Serialize(configPath, false, ref param);
            formulaParaml = new Param();
            DataKeep.Serialize(formulaPath, false, ref formulaParaml);
            dictparam = ToolsBox.ListTODict(param.Maps);

            foreach (Map map in param.Maps)
            {
                toolStripComboBox2.Items.Add(map.Value);
            }

            toolStripComboBox2.Text = toolStripComboBox2.Items[0].ToString();

            DataTable table;
            if (File.Exists(temporaryFilePath))
            {
                useFilePath = temporaryFilePath;
            }
            else
            {
                useFilePath = templateFilePath;
            }
            this.Cursor = Cursors.WaitCursor;
            if (!ExcelOperation.ReadTemplate(startRow, startCol, useFilePath, out table))
            {
                MessageBox.Show("文件保存失败");
            }
            this.Cursor = Cursors.Default;
            ExcelOperation.RemoveEmpty(ref table);

            myDataGridView1.DataSource = null;
            myDataGridView1.DataSource = table;

            EditColnumStyle();


        }



        #region 事件响应
        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataForm form2 = new DataForm(sqlProcessor, toolStripTextBox1.Text, toolStripComboBox1.Text, toolStripComboBox2.Text, 0.65);
            if (form2.ShowDialog() == DialogResult.OK)
            {
                DataRow row = form2._row;
                DataTable dt = (DataTable)myDataGridView1.DataSource;
                DataRow dr = dt.NewRow();
                foreach (Map map in param.Maps)
                {
                    if (map.Value != "")
                    {
                        try
                        {
                            if (dr.Table.Columns.Contains(map.Value))
                            {
                                dr[map.Value] = row[map.Value].ToString();
                            }
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }
                    }
                }
                dt.Rows.Add(dr);
                ExcelOperation.RemoveEmpty(ref dt);
            }
            this.Cursor = Cursors.Default;

        }

        private void 导出excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localFilePath = "", fileNameExt = "", newFileName = "", FilePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //设置文件类型
            //书写规则例如：txt files(*.txt)|*.txt
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|All files(*.*)|*.*";
            //设置默认文件名（可以不设置）
            saveFileDialog.FileName = "标准件";
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
                ExportToExcel(localFilePath);
            }
        }


        private void 查找最新版ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VersionForm form = new VersionForm();
            //form.ShowDialog();
        }

        private void myDataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetData();
            }
            else if (e.Modifiers.CompareTo(Keys.Control) == 0)
            {
                ctrl = true;
            }
        }
        private void myDataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            ctrl = false;
        }
        private void myDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;

            if (e.RowIndex < dt.Rows.Count && e.RowIndex > -1)
            {
                string str = dt.Rows[e.RowIndex][e.ColumnIndex].ToString();
                string cInvCCode = dictparam["cInvCCode"];
                string colnumName = dt.Columns[e.ColumnIndex].ColumnName;
                if (colnumName.Equals(cInvCCode))
                {
                    CInvCCodeForm cInvCCodeForm = new CInvCCodeForm(sqlProcessor.InventoryClassTable);
                    if (cInvCCodeForm.ShowDialog() == DialogResult.OK)
                    {
                        myDataGridView1.dtStack.Push(dt.Copy());
                        dt.Rows[e.RowIndex][e.ColumnIndex] = cInvCCodeForm.CInvCCode;
                    }
                }
                else if (!str.Equals(""))
                {
                    SetData();
                }
            }
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                DataTable table;
                this.Cursor = Cursors.WaitCursor;
                if (ExcelOperation.ReadTemplate(startRow, startCol, openfile.FileName, out table))
                {
                    useFilePath = openfile.FileName;
                    ExcelOperation.RemoveEmpty(ref table);
                    myDataGridView1.DataSource = null;
                    myDataGridView1.DataSource = table;
                }
                else
                {
                    MessageBox.Show("文件导入失败");
                }
                this.Cursor = Cursors.Default;
            }
        }


        private void myDataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string colName = dt.Columns[myDataGridView1.CurrentCell.ColumnIndex].ColumnName;
            int indexrow = myDataGridView1.CurrentCell.RowIndex;
            string name = "";
            string model = "";
            string str = "";
            string text = (e.Control as TextBox).Text;
            foreach (Map map in param.Maps)
            {
                if (map.Value == colName)
                {
                    str = map.Name;
                }
                if (map.Name.Equals("cInvName"))
                {
                    if (dt.Rows.Count > indexrow)
                    {
                        name = dt.Rows[indexrow][map.Value].ToString();
                    }
                }
                else if (map.Name.Equals("cInvStd"))
                {
                    if (dt.Rows.Count > indexrow)
                    {
                        model = dt.Rows[indexrow][map.Value].ToString();
                    }
                }
            }
            DataGridViewTextBoxEditingControl editingControl = e.Control as DataGridViewTextBoxEditingControl;

            editingControl.AutoCompleteCustomSource.Clear();
            if (str.Equals("cInvName"))
            {

                if (!model.Equals(""))
                {
                    sqlProcessor.GetNameAndModel(text, model, out newnames, out newmodels);
                    if (newnames != null)
                    {
                        editingControl.AutoCompleteCustomSource.AddRange(newnames);
                    }
                }
                else
                {
                    if (names != null)
                    {
                        editingControl.AutoCompleteCustomSource.AddRange(names);
                    }
                }
            }
            else if (str.Equals("cInvStd"))
            {
                if (!name.Equals(""))
                {
                    newmodels = sqlProcessor.GetModel(name);
                    if (newmodels != null)
                    {
                        editingControl.AutoCompleteCustomSource.AddRange(newmodels);
                    }
                }
                else
                {
                    if (models != null)
                    {
                        editingControl.AutoCompleteCustomSource.AddRange(models);
                    }
                }
            }
            editingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            editingControl.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Application.StartupPath + "\\Temporary\\" + "BOM临时文件.XLS";
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            if (ExcelOperation.WriteExcel(name, useFilePath, dt, startRow, startCol))
                MessageBox.Show("文件保存成功");
        }


        /// <summary>
        /// 编辑列宽
        /// </summary>
        private void EditColnumStyle()
        {
            Param paramStyle = new Param();
            DataKeep.Serialize(colnumStylePath, false, ref paramStyle);
            foreach (Map map in paramStyle.Maps)
            {
                var name = map.Name;
                float value = float.Parse(map.Value);
                if (myDataGridView1.Columns[name] != null)
                {
                    myDataGridView1.Columns[name].FillWeight = value;
                }
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable table;
            this.Cursor = Cursors.WaitCursor;
            if (!ExcelOperation.ReadTemplate(startRow, startCol, templateFilePath, out table))
            {
                MessageBox.Show("文件打开失败");
            }
            else
            {
                useFilePath = templateFilePath;
                myDataGridView1.DataSource = null;
                myDataGridView1.DataSource = table;
                EditColnumStyle();
                if (File.Exists(temporaryFilePath))
                {
                    File.Delete(temporaryFilePath);
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void BomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeFirst)
            {
                closeFirst = false;
                if (DialogResult.Cancel == MessageBox.Show("文件是否需要保存?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                }
                else
                {
                    保存ToolStripMenuItem_Click(null, null);
                }
            }
        }

        private void BomForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void BomForm_DragDrop(object sender, DragEventArgs e)
        {

            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            int i;
            for (i = 0; i < s.Length; i++)
            {
                string str = s[i];
                if (File.Exists(str))
                {
                    DataTable table;
                    this.Cursor = Cursors.WaitCursor;
                    if (!ExcelOperation.ReadTemplate(startRow, startCol, str, out table))
                    {
                        MessageBox.Show("文件导入失败");
                    }
                    else
                    {
                        useFilePath = str;
                        ExcelOperation.RemoveEmpty(ref table);
                        myDataGridView1.DataSource = null;
                        myDataGridView1.DataSource = table;
                    }
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void 切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BomForm_FormClosing(null, null);
            //this.Hide();
            //new MaterialCreatetForm(sqlProcessor).ShowDialog();
            //this.Close();
        }

        private void 相同行合并ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string Path = Application.StartupPath + "\\配置文件\\数据合并配置.xml";
            string strPath = Application.StartupPath + "\\Temporary\\数据合并配置.xml";
            string cInvCode = dictparam["cInvCode"];
            if (!File.Exists(strPath))
            {
                File.Copy(Path, strPath, false);
            }
            Param param = new Param();
            DataKeep.Serialize(strPath, false, ref param);
            List<string> strList = new List<string>();
            List<string> strCol = new List<string>();
            foreach (DataColumn col in dt.Columns)
            {
                strCol.Add(col.ColumnName);
            }
            foreach (Map map in param.Maps)
            {
                strList.Add(map.Name);
            }
            var list = strCol.Except(strList);
            foreach (var s in list)
            {
                Console.WriteLine(s);
            }
            bool judge = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[i][cInvCode] != DBNull.Value && dt.Rows[j][cInvCode] != DBNull.Value && dt.Rows[i][cInvCode].Equals(dt.Rows[j][cInvCode]))
                    {
                        judge = true;
                        foreach (var value in list)
                        {
                            if (!dt.Rows[i][value].ToString().Trim().Equals(dt.Rows[j][value].ToString().Trim()))
                            {
                                judge = false;
                                break;
                            }
                        }
                        if (judge)
                        {
                            try
                            {
                                foreach (var value in strList)
                                {
                                    if (dt.Rows[i][value].ToString().Equals(""))
                                    {
                                        dt.Rows[i][value] = '0';
                                    }
                                    if (dt.Rows[j][value].ToString().Equals(""))
                                    {
                                        dt.Rows[j][value] = '0';
                                    }
                                    dt.Rows[i][value] = int.Parse(dt.Rows[i][value].ToString()) + int.Parse(dt.Rows[j][value].ToString());
                                }
                                dt.Rows.RemoveAt(j);
                                j--;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }

        }

        private void 数据合并配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Path = Application.StartupPath + "\\配置文件\\数据合并配置.xml";
            string strPath = Application.StartupPath + "\\Temporary\\数据合并配置.xml";
            if (!File.Exists(strPath))
            {
                System.IO.File.Copy(Path, strPath, false);
            }
            MapForm mapForm = new MapForm(strPath);
            mapForm.ShowDialog();
        }

        private void 公式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\Temporary\\" + formulaPath.Split('\\').Last();
            if (!File.Exists(strPath))
            {
                System.IO.File.Copy(formulaPath, strPath, false);
            }
            MapForm mapForm = new MapForm(strPath);
            mapForm.ShowDialog();
            DataKeep.Serialize(strPath, false, ref formulaParaml);
        }

        private void myDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string colnumName = dt.Columns[myDataGridView1.CurrentCell.ColumnIndex].ColumnName;
            int indexrow = myDataGridView1.CurrentCell.RowIndex;
            if (indexrow < dt.Rows.Count)
            {
                DataRow row = dt.Rows[indexrow];
                if (dt.Columns.Contains("单机数量") && dt.Columns.Contains("设备数量") && dt.Columns.Contains("总数量"))
                {
                    if (colnumName.Equals("单机数量"))
                    {
                        if (dt.Columns.Contains("总数量"))
                        {
                            try
                            {
                                if (row["单机数量"] != DBNull.Value && row["设备数量"] != DBNull.Value)
                                    row["总数量"] = int.Parse(row["单机数量"].ToString()) * int.Parse(row["设备数量"].ToString());
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                    }
                    else if (colnumName.Equals("设备数量"))
                    {
                        if (dt.Columns.Contains("总数量"))
                        {
                            try
                            {
                                if (row["单机数量"] != DBNull.Value && row["设备数量"] != DBNull.Value)
                                    row["总数量"] = int.Parse(row["单机数量"].ToString()) * int.Parse(row["设备数量"].ToString());
                            }
                            catch (Exception ex) { Console.WriteLine(ex.Message); }
                        }
                    }
                }
            }
        }

        private void 名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.StartPosition = FormStartPosition.CenterParent;
            progressBarForm.Show();

            DataTable dt = (DataTable)myDataGridView1.DataSource;
            int count = dt.Rows.Count;
            progressBarForm.Count = count;

            Thread thread = new Thread(() => { Matches_Name(progressBarForm); });
            thread.Start();
        }

        private void 规格图号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.StartPosition = FormStartPosition.CenterParent;
            progressBarForm.Show();

            DataTable dt = (DataTable)myDataGridView1.DataSource;
            int count = dt.Rows.Count;
            progressBarForm.Count = count;

            Thread thread = new Thread(() => { Matches_Model(progressBarForm); });
            thread.Start();
        }

        private void 名称和规格图号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.StartPosition = FormStartPosition.CenterParent;
            progressBarForm.Show();

            DataTable dt = (DataTable)myDataGridView1.DataSource;
            int count = dt.Rows.Count;
            progressBarForm.Count = count;

            Thread thread = new Thread(() => { Matches_NameAndModel(progressBarForm); });
            thread.Start();
        }



        private void 去除特殊字符匹配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.StartPosition = FormStartPosition.CenterParent;
            progressBarForm.Show();

            DataTable dt = (DataTable)myDataGridView1.DataSource;
            int count = dt.Rows.Count;
            progressBarForm.Count = count;

            Thread thread = new Thread(() => { Matches_Model_A_Z_0_9(progressBarForm); });
            thread.Start();
        }

        private void 数据匹配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgressBarForm progressBarForm = new ProgressBarForm();
            progressBarForm.StartPosition = FormStartPosition.CenterParent;
            progressBarForm.Show();

            DataTable dt = (DataTable)myDataGridView1.DataSource;
            int count = dt.Rows.Count;
            progressBarForm.Count = count;

            Thread thread = new Thread(() => { Matches(progressBarForm); });
            thread.Start();
        }

        private void 保存格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Param param = new Param();
            List<Map> maps = new List<Map>();
            for (int i = 0; i < myDataGridView1.Columns.Count; i++)
            {
                Map map = new Map();
                map.Name = myDataGridView1.Columns[i].Name;
                map.Value = myDataGridView1.Columns[i].FillWeight.ToString();
                maps.Add(map);
            }
            param.Maps = maps.ToArray();
            DataKeep.Serialize(colnumStylePath, true, ref param);
            MessageBox.Show("表格格式保存成功");
        }




        #endregion

        #region 方法

        #region 查询数据库修改数据
        /// <summary>
        /// 批量修改
        /// </summary>
        private void SetData()
        {
            IEnumerator enumerator = myDataGridView1.SelectedCells.GetEnumerator();
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            DataTable dtData = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            List<DataRow> rowlist = new List<DataRow>();
            List<int> indexlist = new List<int>();
            string cInvStd = dictparam["cInvStd"];
            string cInvName = dictparam["cInvName"];
            while (enumerator.MoveNext())
            {
                var cell = enumerator.Current as DataGridViewCell;
                var indexCol = cell.ColumnIndex;
                var indexRow = cell.RowIndex;
                string name = myDataGridView1.Columns[indexCol].HeaderText;
                if (name.Equals(cInvStd))
                {
                    string value = cell.Value.ToString();
                    DataTable data = sqlProcessor.AccurateQuery(value, "cInvStd");
                    if (data.Rows.Count > 0)
                    {
                        if (data.Rows.Count == 1)
                        {
                            rowlist.Add(data.Rows[0]);
                            indexlist.Add(indexRow);
                        }
                        else if (data.Rows.Count > 1)
                        {
                            dtData.Clear();
                            dtData.Rows.Add(dt.Rows[indexRow].ItemArray);
                            DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                            if (form2.ShowDialog() == DialogResult.OK)
                            {
                                DataRow row = form2._row;
                                rowlist.Add(row);
                                indexlist.Add(indexRow);
                            }

                        }
                    }
                }
                else if (name.Equals(cInvName))
                {
                    string value = cell.Value.ToString();
                    DataTable data = sqlProcessor.AccurateQuery(value, "cInvName");
                    if (data.Rows.Count > 0)
                    {
                        if (data.Rows.Count == 1)
                        {
                            rowlist.Add(data.Rows[0]);
                            indexlist.Add(indexRow);
                        }
                        else if (data.Rows.Count > 1)
                        {
                            dtData.Clear();
                            dtData.Rows.Add(dt.Rows[indexRow].ItemArray);
                            DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                            if (form2.ShowDialog() == DialogResult.OK)
                            {
                                DataRow row = form2._row;
                                rowlist.Add(row);
                                indexlist.Add(indexRow);
                            }

                        }
                    }
                }
            }
            for (int i = 0; i < rowlist.Count; i++)
            {
                DataRow dr = dt.Rows[indexlist.ElementAt(i)];
                DataRow row = rowlist.ElementAt(i);
                dr.BeginEdit();
                foreach (var map in param.Maps)
                {
                    if (dr.Table.Columns.Contains(map.Value) && row.Table.Columns.Contains(map.Name))
                    {
                        dr[map.Value] = row[map.Name].ToString();
                    }
                    else if (dr.Table.Columns.Contains(map.Value) && row.Table.Columns.Contains(map.Value))
                    {
                        dr[map.Value] = row[map.Value].ToString();
                    }
                }
                dr.EndEdit();
            }
            dt.AcceptChanges();

        }
        #endregion

        #region 导出数据
        private void ExportToExcel(string path)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            if (ExcelOperation.WriteExcel(path, useFilePath, dt, startRow, startCol))
            {
                if (DialogResult.Cancel == MessageBox.Show("文件导出成功是否需要打开文件?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                }
                else
                {
                    System.Diagnostics.Process.Start(path);
                }

            }
            else
            {
                MessageBox.Show("文件导出失败");
            }
        }
        #endregion




        private void Matches_NameAndModel(ProgressBarForm progressBarForm)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string cInvStd = dictparam["cInvStd"];
            string cInvName = dictparam["cInvName"];
            List<DataRow> rowlist = new List<DataRow>();
            List<int> indexlist = new List<int>();
            DataTable dtData = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            try
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    if (progressBarForm.Stop == true)
                    {
                        return;
                    }
                    progressBarForm.Value = index + 1;
                    //progressBarForm.AddProgress(index);
                    //Console.WriteLine(index);
                    DataRow row = dt.Rows[index];
                    string str1 = row[cInvName].ToString().Trim();
                    string str2 = row[cInvStd].ToString().Trim();

                    DataRow newRow = null;
                    if (str1 != "" || str2 != "")
                    {
                        DataTable data = sqlProcessor.AccurateQuery_AND_Like(str1, "cInvName", str2, "cInvStd");
                        if (data.Rows.Count > 0)
                        {
                            if (data.Rows.Count == 1)
                            {
                                newRow = data.Rows[0];
                                rowlist.Add(data.Rows[0]);
                                indexlist.Add(index);
                            }
                            else if (data.Rows.Count > 1)
                            {
                                dtData.Clear();
                                dtData.Rows.Add(dt.Rows[index].ItemArray);

                                DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                                if (form2.ShowDialog() == DialogResult.OK)
                                {
                                    DataRow rowf = form2._row;
                                    newRow = rowf;
                                    rowlist.Add(rowf);
                                    indexlist.Add(index);
                                }

                            }
                        }
                    }
                    row.BeginEdit();
                    //progressBarForm.AddProgress(40);
                    if (newRow != null)
                    {
                        foreach (var map in param.Maps)
                        {
                            if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Name))
                            {
                                row[map.Value] = newRow[map.Name].ToString();
                            }
                            else if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Value))
                            {
                                row[map.Value] = newRow[map.Value].ToString();
                            }
                        }
                    }
                    row.EndEdit();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

            dt.AcceptChanges();
        }

        private void Matches(ProgressBarForm progressBarForm)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string cInvStd = dictparam["cInvStd"];
            string cInvName = dictparam["cInvName"];
            List<DataRow> rowlist = new List<DataRow>();
            List<int> indexlist = new List<int>();
            DataTable dtData = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            try
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    if (progressBarForm.Stop == true)
                    {
                        return;
                    }
                    progressBarForm.Value = index + 1;
                    //progressBarForm.AddProgress(index);
                    //Console.WriteLine(index);
                    DataRow row = dt.Rows[index];
                    string str1 = row[cInvName].ToString().Trim();
                    string str2 = row[cInvStd].ToString().Trim();

                    DataRow newRow = null;
                    if (str1 != "" || str2 != "")
                    {
                        DataTable data = sqlProcessor.AccurateQuery_AND_Like(str1, "cInvName", str2, "cInvStd");
                        if (data != null)
                        {
                            if (data.Rows.Count == 0)
                            {
                                data = sqlProcessor.AccurateQuery_AND(str1, "cInvName", str2, "cInvStd");
                                if (data != null)
                                {
                                    if (data.Rows.Count == 0)
                                    {
                                        data = sqlProcessor.AccurateQuery_OR(str1, "cInvName", str2, "cInvStd");
                                        if (data != null)
                                        {
                                            if (data.Rows.Count > 0)
                                            {
                                                dtData.Clear();
                                                dtData.Rows.Add(dt.Rows[index].ItemArray);

                                                DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                                                if (form2.ShowDialog() == DialogResult.OK)
                                                {
                                                    DataRow rowf = form2._row;
                                                    newRow = rowf;
                                                    rowlist.Add(rowf);
                                                    indexlist.Add(index);
                                                }

                                            }
                                        }
                                    }
                                    else
                                    {
                                        dtData.Clear();
                                        dtData.Rows.Add(dt.Rows[index].ItemArray);

                                        DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                                        if (form2.ShowDialog() == DialogResult.OK)
                                        {
                                            DataRow rowf = form2._row;
                                            newRow = rowf;
                                            rowlist.Add(rowf);
                                            indexlist.Add(index);
                                        }


                                    }
                                }
                            }
                            else if (data.Rows.Count == 1)
                            {
                                newRow = data.Rows[0];
                                rowlist.Add(data.Rows[0]);
                                indexlist.Add(index);
                            }
                        }
                    }
                    row.BeginEdit();
                    //progressBarForm.AddProgress(40);
                    if (newRow != null)
                    {
                        foreach (var map in param.Maps)
                        {
                            if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Name))
                            {
                                row[map.Value] = newRow[map.Name].ToString();
                            }
                            else if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Value))
                            {
                                row[map.Value] = newRow[map.Value].ToString();
                            }
                        }
                    }
                    row.EndEdit();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            dt.AcceptChanges();
        }

        private void Matches_Name(ProgressBarForm progressBarForm)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string cInvName = dictparam["cInvName"];
            List<DataRow> rowlist = new List<DataRow>();
            List<int> indexlist = new List<int>();
            DataTable dtData = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            try
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    if (progressBarForm.Stop == true)
                    {
                        return;
                    }
                    progressBarForm.Value = index + 1;
                    DataRow row = dt.Rows[index];
                    string str1 = row[cInvName].ToString().Trim();

                    DataRow newRow = null;
                    if (!str1.Equals(""))
                    {
                        DataTable data = sqlProcessor.AccurateQuery_Like(str1, "cInvName");
                        if (data != null)
                        {
                            if (data != null)
                            {
                                if (data.Rows.Count == 1)
                                {
                                    newRow = data.Rows[0];
                                    rowlist.Add(data.Rows[0]);
                                    indexlist.Add(index);
                                }
                                else if (data.Rows.Count > 1)
                                {
                                    dtData.Clear();
                                    dtData.Rows.Add(dt.Rows[index].ItemArray);

                                    DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                                    if (form2.ShowDialog() == DialogResult.OK)
                                    {
                                        DataRow rowf = form2._row;
                                        newRow = rowf;
                                        rowlist.Add(rowf);
                                        indexlist.Add(index);
                                    }
                                }
                            }
                        }
                    }
                    row.BeginEdit();
                    //progressBarForm.AddProgress(40);
                    if (newRow != null)
                    {
                        foreach (var map in param.Maps)
                        {
                            if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Name))
                            {
                                row[map.Value] = newRow[map.Name].ToString();
                            }
                            else if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Value))
                            {
                                row[map.Value] = newRow[map.Value].ToString();
                            }
                        }
                    }
                    row.EndEdit();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            dt.AcceptChanges();
        }
        private void Matches_Model(ProgressBarForm progressBarForm)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string cInvStd = dictparam["cInvStd"];
            List<DataRow> rowlist = new List<DataRow>();
            List<int> indexlist = new List<int>();
            DataTable dtData = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            try
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    if (progressBarForm.Stop == true)
                    {
                        return;
                    }
                    progressBarForm.Value = index + 1;
                    DataRow row = dt.Rows[index];
                    string str1 = row[cInvStd].ToString().Trim();

                    DataRow newRow = null;
                    if (!str1.Equals(""))
                    {
                        Console.WriteLine();
                        DataTable data = sqlProcessor.AccurateQuery_Like(str1, "cInvStd");
                        Console.WriteLine(data.Rows.Count);
                        if (data.Rows.Count > 0)
                        {
                            if (data.Rows.Count == 1)
                            {
                                newRow = data.Rows[0];
                                rowlist.Add(data.Rows[0]);
                                indexlist.Add(index);
                            }
                            else if (data.Rows.Count > 1)
                            {
                                dtData.Clear();
                                dtData.Rows.Add(dt.Rows[index].ItemArray);

                                DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                                if (form2.ShowDialog() == DialogResult.OK)
                                {
                                    DataRow rowf = form2._row;
                                    newRow = rowf;
                                    rowlist.Add(rowf);
                                    indexlist.Add(index);
                                }
                            }
                        }
                    }
                    row.BeginEdit();
                    //progressBarForm.AddProgress(40);
                    if (newRow != null)
                    {
                        foreach (var map in param.Maps)
                        {
                            if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Name))
                            {
                                row[map.Value] = newRow[map.Name].ToString();
                            }
                            else if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Value))
                            {
                                row[map.Value] = newRow[map.Value].ToString();
                            }
                        }
                    }
                    row.EndEdit();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            dt.AcceptChanges();
        }

        private void Matches_Model_A_Z_0_9(ProgressBarForm progressBarForm)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string cInvStd = dictparam["cInvStd"];
            List<DataRow> rowlist = new List<DataRow>();
            List<int> indexlist = new List<int>();
            DataTable dtData = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                dtData.Columns.Add(col.ColumnName);
            }
            try
            {
                for (int index = 0; index < dt.Rows.Count; index++)
                {
                    if (progressBarForm.Stop == true)
                    {
                        return;
                    }
                    progressBarForm.Value = index + 1;
                    DataRow row = dt.Rows[index];
                    string str1 = row[cInvStd].ToString().Trim();

                    DataRow newRow = null;
                    if (!str1.Equals(""))
                    {
                        DataTable data = sqlProcessor.AccurateQuery_A_Z_0_9(str1, "cInvStd");
                        if (data != null)
                        {
                            if (data != null)
                            {
                                if (data.Rows.Count == 1)
                                {
                                    newRow = data.Rows[0];
                                    rowlist.Add(data.Rows[0]);
                                    indexlist.Add(index);
                                }
                                else if (data.Rows.Count > 1)
                                {
                                    dtData.Clear();
                                    dtData.Rows.Add(dt.Rows[index].ItemArray);

                                    DataForm form2 = new DataForm(sqlProcessor, data, dtData);
                                    if (form2.ShowDialog() == DialogResult.OK)
                                    {
                                        DataRow rowf = form2._row;
                                        newRow = rowf;
                                        rowlist.Add(rowf);
                                        indexlist.Add(index);
                                    }
                                }
                            }
                        }
                    }
                    row.BeginEdit();
                    //progressBarForm.AddProgress(40);
                    if (newRow != null)
                    {
                        foreach (var map in param.Maps)
                        {
                            if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Name))
                            {
                                row[map.Value] = newRow[map.Name].ToString();
                            }
                            else if (row.Table.Columns.Contains(map.Value) && newRow.Table.Columns.Contains(map.Value))
                            {
                                row[map.Value] = newRow[map.Value].ToString();
                            }
                        }
                    }
                    row.EndEdit();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            dt.AcceptChanges();
        }

        #endregion

        private void 数据关联ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\Temporary\\" + configPath.Split('\\').Last();
            if (!File.Exists(strPath))
            {
                System.IO.File.Copy(configPath, strPath, false);
            }
            MapForm mapForm = new MapForm(strPath);
            mapForm.ShowDialog();
        }

    }
}
