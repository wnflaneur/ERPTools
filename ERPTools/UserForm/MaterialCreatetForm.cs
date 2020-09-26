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
using System.IO;

namespace ERPTools.UserForm
{
    public partial class MaterialCreatetForm : UserControl
    {
        private static bool closeFirst = true;

        string templatename;
        string configPath;
        string defaultPath;
        int startRow;
        int startCol;
        string templatePath;
        string colnumStylePath;
        Param param = new Param();
        Dictionary<string, string> dictparam;

        SqlProcessor sql;


        public MaterialCreatetForm()
        {
            InitializeComponent();
        }
        public MaterialCreatetForm(SqlProcessor sql) : this()
        {
            this.sql = sql;
            MaterialCreatetForm_Load();
        }

        private void MaterialCreatetForm_Load()
        {
            configPath = Application.StartupPath + "\\配置文件\\Config.xml";

            param = new Param();

            DataKeep.Serialize(configPath, false, ref param);

            dictparam = ToolsBox.ListTODict(param.Maps);

            templatePath = Application.StartupPath + "\\配置文件\\存货档案模板.xls";
            startRow = int.Parse(ConfigurationManager.AppSettings["StartRow"]);
            startCol = int.Parse(ConfigurationManager.AppSettings["StartCol"]);


            toolStripComboBox1.Items.Add("机加件");
            toolStripComboBox1.Items.Add("标准件");
            toolStripComboBox1.Text = toolStripComboBox1.Items[1].ToString();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

            string str = toolStripComboBox1.Text;
            if (str.Equals(toolStripComboBox1.Items[0].ToString()))
            {
                templatename = Application.StartupPath + "\\配置文件\\机加件模板.XLS";
                configPath = Application.StartupPath + "\\配置文件\\机加件关系映射.xml";
                defaultPath = Application.StartupPath + "\\配置文件\\机加件默认值.xml";
                colnumStylePath = Application.StartupPath + "\\配置文件\\机加件列宽设置.xml";

            }
            else if (str.Equals(toolStripComboBox1.Items[1].ToString()))
            {
                templatename = Application.StartupPath + "\\配置文件\\标准件模板.XLS";
                configPath = Application.StartupPath + "\\配置文件\\标准件关系映射.xml";
                defaultPath = Application.StartupPath + "\\配置文件\\标准件默认值.xml";
                colnumStylePath = Application.StartupPath + "\\配置文件\\标准件列宽设置.xml";
            }
            DataTable table;
            string name = Application.StartupPath + "\\Temporary\\" + toolStripComboBox1.Text + "临时文件.XLS";
            if (File.Exists(name))
            {
                this.Cursor = Cursors.WaitCursor;
                if (!ExcelOperation.ReadTemplate(startRow, startCol, name, out table))
                {
                    MessageBox.Show("文件打开失败");
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
                if (!ExcelOperation.ReadTemplate(startRow, startCol, templatename, out table))
                {
                    MessageBox.Show("文件打开失败");
                }
                this.Cursor = Cursors.Default;
            }
            myDataGridView1.DataSource = null;
            //ExcelOperation.RemoveEmpty(ref table);
            myDataGridView1.DataSource = table;
            EditColnumStyle();
        }

        private void 数据关联ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\Temporary\\" + configPath.Split('\\').Last();
            if (!File.Exists(strPath))
            {
                System.IO.File.Copy(configPath, strPath, false);
            }
            MapForm mapForm = new MapForm(strPath);
            mapForm.ShowDialog();
        }

        private void 数据默认设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\Temporary\\" + defaultPath.Split('\\').Last();
            if (!File.Exists(strPath))
            {
                System.IO.File.Copy(defaultPath, strPath, false);
            }
            MapForm mapForm = new MapForm(strPath);
            mapForm.ShowDialog();

        }

        private void 导入execelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string filename = openfile.FileName;
                DataTable table;

                this.Cursor = Cursors.WaitCursor;
                if (ExcelOperation.ReadTemplate(startRow, startCol, filename, out table))
                {
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

        private void 导出execlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localFilePath = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //设置文件类型
            //书写规则例如：txt files(*.txt)|*.txt
            saveFileDialog.Filter = "txt files(*.txt)|*.txt|xls files(*.xls)|*.xls|All files(*.*)|*.*";
            //设置默认文件名（可以不设置）
            saveFileDialog.FileName = "存货档案导入数据";
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

        private void ExportToExcel(string path)
        {



            DataTable table = (DataTable)myDataGridView1.DataSource;
            ExcelOperation.RemoveEmpty(ref table);
            DataSet ds;
            this.Cursor = Cursors.Default;
            ds = ExcelOperation.ReadExcel(templatePath);
            this.Cursor = Cursors.Default;
            string str = Application.StartupPath + "\\Temporary\\" + defaultPath.Split('\\').Last();
            if (!File.Exists(str))
            {
                System.IO.File.Copy(defaultPath, str, false);
            }
            Param defaultParam = new Param();
            DataKeep.Serialize(str, false, ref defaultParam);
            str = Application.StartupPath + "\\Temporary\\" + configPath.Split('\\').Last();
            if (!File.Exists(str))
            {
                System.IO.File.Copy(configPath, str, false);
            }
            Param param = new Param();
            DataKeep.Serialize(str, false, ref param);

            try
            {
                foreach (Map map in param.Maps)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (dt.Columns.Contains(map.Name))
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                DataRow row;
                                if (dt.Rows.Count > i)
                                {
                                    row = dt.Rows[i];
                                }
                                else
                                {
                                    row = dt.NewRow();
                                    dt.Rows.Add(row);
                                }
                                if (table.Columns.Contains(map.Value))
                                {
                                    row[map.Name] = table.Rows[i][map.Value].ToString();
                                }
                            }
                        }
                    }
                }
                foreach (Map map in defaultParam.Maps)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (dt.Columns.Contains(map.Name))
                        {
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                DataRow row;
                                if (dt.Rows.Count > i)
                                {
                                    row = dt.Rows[i];
                                }
                                else
                                {
                                    row = dt.NewRow();
                                    dt.Rows.Add(row);
                                }
                                if (row[map.Name].ToString() == "")
                                {
                                    row[map.Name] = map.Value;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "导出失败");
                return;
            }
            if (ExcelOperation.WriteExcel2(path, templatePath, ds))
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

        private void 物料编码生成ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string str = toolStripComboBox1.Text;
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            ExcelOperation.RemoveEmpty(ref dt);
            if (str.Equals(toolStripComboBox1.Items[0].ToString()))
            {
                MachineCodingBuilds();
            }
            else if (str.Equals(toolStripComboBox1.Items[1].ToString())) //标准件
            {
                StandardCodingBuilds();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 机加件编码生成 
        /// </summary>
        private void MachineCodingBuilds()
        {
            MachineNumberForm form = new MachineNumberForm();
            Dictionary<string, int> dict = sql.GetNumber_M();
            DataKeep.Serialize(configPath, false, ref param);
            if (form.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = (DataTable)myDataGridView1.DataSource;
                string CodingName = "";
                foreach (Map map in param.Maps)
                {
                    if (map.Name.Equals("存货编码"))
                    {
                        CodingName = map.Value;

                    }
                }
                string projectnumber = form.projectNumber.Trim();

                if (dt.Columns.Contains(CodingName))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int num;
                        if (dict.ContainsKey(projectnumber))
                        {
                            num = dict[projectnumber];
                        }
                        else
                        {
                            dict.Add(projectnumber, 0);
                            num = 0;
                        }
                        string numstr = string.Format("{0:D5}", num + 1);
                        try
                        {
                            string Classstr = projectnumber;
                            row[CodingName] = Classstr + "." + numstr;
                            dict[projectnumber] = num + 1;
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("表没有{0}列", CodingName));
                }
                dt.AcceptChanges();
            }
        }


        /// <summary>
        /// 标准件编码生成
        /// </summary>
        private void StandardCodingBuilds()
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            Dictionary<string, int> dict = sql.GetNumber();
            DataKeep.Serialize(configPath, false, ref param);
            string ClassName = "";
            string CodingName = "";
            string cInvName = "";
            string cInvStd = "";
            List<int> redlist = new List<int>();
            foreach (Map map in param.Maps)
            {
                Console.WriteLine(map.Name);
                if (map.Name.Equals("存货大类编码"))
                {
                    ClassName = map.Value;
                }
                else if (map.Name.Equals("存货编码"))
                {
                    CodingName = map.Value;
                }
                else if (map.Name.Equals("规格型号"))
                {
                    cInvStd= map.Value;
                }
                else if (map.Name.Equals("存货名称")) 
                {
                    cInvName= map.Value;
                }
            }
            Console.WriteLine(ClassName + "," + CodingName);
            if (dt.Columns.Contains(ClassName) && dt.Columns.Contains(CodingName)&& dt.Columns.Contains(cInvStd) && dt.Columns.Contains(cInvName))
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row[ClassName] != DBNull.Value)
                    {
                        string name = row[cInvName].ToString().Trim();
                        string std = row[cInvStd].ToString().Trim();
                        DataTable dtnew=sql.AccurateQuery_AND_Like(name, "cInvName", std, "cInvStd");
                        
                        if (dtnew == null || dtnew.Rows.Count > 0) 
                        {
                            redlist.Add(row.Table.Rows.IndexOf(row));
                            continue;
                        }
                        string value = row[ClassName].ToString().Trim();
                        int num;
                        if (dict.ContainsKey(value))
                        {
                            num = dict[value];
                        }
                        else
                        {
                            MessageBox.Show(value + "分类编码错误");
                            continue;
                        }
                        string numstr = string.Format("{0:D5}", num + 1);
                        try
                        {
                            string Classstr = value.Substring(0, 4) + "." + value.Substring(4, 2);
                            row[CodingName] = Classstr + "." + numstr;
                            dict[value] = num + 1;
                        }
                        catch (Exception e1)
                        {
                            MessageBox.Show(e1.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(string.Format("表没有{0}列或{1}列", ClassName, CodingName));
            }
            dt.AcceptChanges();
            LookForDuplicates();
            foreach (var i in redlist) 
            {
                myDataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            }
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

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = Application.StartupPath + "\\Temporary\\" + toolStripComboBox1.Text + "临时文件.XLS";
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            if (ExcelOperation.WriteExcel(name, templatename, dt, startRow, startCol))
                MessageBox.Show("文件保存成功");
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable table;
            this.Cursor = Cursors.WaitCursor;
            if (ExcelOperation.ReadTemplate(startRow, startCol, templatename, out table))
            {
                ExcelOperation.RemoveEmpty(ref table);
                myDataGridView1.DataSource = null;
                myDataGridView1.DataSource = table;
                EditColnumStyle();
                string fileName = Application.StartupPath + "\\Temporary\\" + toolStripComboBox1.Text + "临时文件.XLS";
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            else
            {
                MessageBox.Show("文件打开失败");
            }
            this.Cursor = Cursors.Default;
        }

        private void MaterialCreatetForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MaterialCreatetForm_DragDrop(object sender, DragEventArgs e)
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
                        ExcelOperation.RemoveEmpty(ref table);
                        myDataGridView1.DataSource = null;
                        myDataGridView1.DataSource = table;
                    }
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void MaterialCreatetForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void LookForDuplicates() 
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string Path = Application.StartupPath + "\\配置文件\\数据合并配置.xml";
            string strPath = Application.StartupPath + "\\Temporary\\数据合并配置.xml";
            if (!File.Exists(strPath))
            {
                File.Copy(Path, strPath, false);
            }
            Param param = new Param();
            DataKeep.Serialize(strPath, false, ref param);
            List<string> strList = new List<string>();
            List<string> strCol = new List<string>();
            DataTable removeTable = dt.Copy();
            removeTable.Clear();
            string cInvCCode = dictparam["cInvCCode"];
            foreach (DataColumn col in dt.Columns)
            {
                strCol.Add(col.ColumnName);
            }
            foreach (Map map in param.Maps)
            {
                strList.Add(map.Name);
            }
            var list = strCol.Except(strList);
            bool judge = true;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[i][cInvCCode] != DBNull.Value && dt.Rows[j][cInvCCode] != DBNull.Value && dt.Rows[i][cInvCCode].Equals(dt.Rows[j][cInvCCode]))
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
                                myDataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                                myDataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
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

        private void 合并ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            string Path = Application.StartupPath + "\\配置文件\\数据合并配置.xml";
            string strPath = Application.StartupPath + "\\Temporary\\数据合并配置.xml";
            if (!File.Exists(strPath))
            {
                System.IO.File.Copy(Path, strPath, false);
            }
            Param param = new Param();
            DataKeep.Serialize(strPath, false, ref param);
            List<string> strList = new List<string>();
            List<string> strCol = new List<string>();
            List<DataRow> removeList = new List<DataRow>();
            DataTable removeTable = dt.Copy();
            removeTable.Clear();
            string cInvCCode = dictparam["cInvCCode"];
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
                    if (dt.Rows[i][cInvCCode] != DBNull.Value && dt.Rows[j][cInvCCode] != DBNull.Value && dt.Rows[i][cInvCCode].Equals(dt.Rows[j][cInvCCode]))
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
                                removeTable.Rows.Add(dt.Rows[j].ItemArray);
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
            DataForm dataForm = new DataForm(sql, removeTable);
            dataForm.ShowDialog();
        }
    }
}
