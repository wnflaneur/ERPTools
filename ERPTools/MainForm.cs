using ERPTools.UserForm;
using ExcelTools.Src;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPTools
{
    public partial class MainForm: Form
    {
        private SqlProcessor sql = new SqlProcessor();
        private SqlAccess sqlAccess = new SqlAccess();
        private SQLSelectTable sqlSelectTable;
        private Dictionary<string, Control> dictform = new Dictionary<string, Control>();
        public MainForm()
        {
            InitializeComponent();
            checkU8();
            sqlSelectTable = new SQLSelectTable(sql);
            this.IsMdiContainer = true;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            String home = ConfigurationManager.AppSettings["默认主页"];
            sql.SetStatus += new SetStatusEvnet(Btn_Enabled);
            SQLupdate();
            if (home != null)
            {
                MenuItem_Click(home, null);
                switch (home)
                {
                    case "BOM":
                        bOMToolStripMenuItem_Click(null, null);
                        break;
                    case "物料":
                        物料ToolStripMenuItem_Click(null, null);
                        break;
                    case "进度":
                        进度ToolStripMenuItem_Click(null, null);
                        break;
                    case "库存":
                        库存ToolStripMenuItem_Click(null, null);
                        break;
                    case "物料档案":
                        物料档案ToolStripMenuItem_Click(null, null);
                        break;
                    case "数据库校验":
                        数据库自检ToolStripMenuItem_Click(null, null);
                        break;
                }
            }
            UpdateTimeShow();

            this.Cursor = Cursors.Default;
        }



        private void Btn_Enabled(int num)
        {
            //this.Invoke(new Action(() =>
            //{
            //    //if (num <= 1)
            //    //{
            //    //    BOM_Btn.Enabled = true;
            //    //    Inv_Btn.Enabled = true;
            //    //    Position_Btn.Enabled = true;
            //    //    Pro_Btn.Enabled = true;
            //    //}
            //    //else if (num <= 2)
            //    //{
            //    //    BOM_Btn.Enabled = true;
            //    //    Inv_Btn.Enabled = true;
            //    //    Position_Btn.Enabled = true;
            //    //    Pro_Btn.Enabled = true;
            //    //}
            //    //else if (num <= 3)
            //    //{
            //    //    BOM_Btn.Enabled = true;
            //    //    Inv_Btn.Enabled = true;
            //    //    Position_Btn.Enabled = true;
            //    //    Pro_Btn.Enabled = true;
            //    //}

            //}));
        }

        private void SQLupdate()
        {
            string configPath = Application.StartupPath + "\\配置文件\\Config.xml";
            Param param = new Param();

            #region 读取数据，更新数据
            param = new Param();
            DataKeep.Serialize(configPath, false, ref param);
            string sqldata = "";
            foreach (Map map in param.Maps)
            {
                sqldata += map.Name + ",";
            }
            sqldata = sqldata.TrimEnd(',');

            sql.Init();
            #endregion
        }
        private void OpenForm(Control obj)
        {
            obj.Dock = System.Windows.Forms.DockStyle.Fill;
            obj.Location = new System.Drawing.Point(0, 0);
            Mainpanel.Controls.Add(obj);
        }

        private void CloseForm()
        {
            Mainpanel.Controls.Clear();
        }

        private void bOMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("BomForm"))
            {
                frm = new BomForm(sql);
                dictform.Add("BomForm",frm);
            }
            else {
                frm = dictform["BomForm"];
            }
            OpenForm(frm);

        }

        private void 物料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("MaterialCreatetForm"))
            {
                frm = new MaterialCreatetForm(sql);
                dictform.Add("MaterialCreatetForm", frm);
            }
            else
            {
                frm = dictform["MaterialCreatetForm"];
            }
            OpenForm(frm);
        }

        private void 进度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("ProgressForm"))
            {
                frm = new ProgressForm(sql);
                dictform.Add("ProgressForm", frm);
            }
            else
            {
                frm = dictform["ProgressForm"];
            }
            OpenForm(frm);
        }

        private void 库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("InvForm"))
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable data = sqlSelectTable.GetWarehouse();
                frm = new ChildrenForm(data);
                var client = frm as ChildrenForm;
                client.SetScrDataGrid();
                dictform.Add("InvForm", frm);
                this.Cursor = Cursors.Default;
            }
            else
            {
                frm = dictform["InvForm"];
            }
            OpenForm(frm);
        }

        private void 物料档案ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("TreeInvCCodeForm"))
            {
                frm = new TreeInvCCodeForm(sql);
                dictform.Add("TreeInvCCodeForm", frm);
            }
            else
            {
                frm = dictform["TreeInvCCodeForm"];
            }
            OpenForm(frm);
        }

        private void 数据库自检ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("DataTableForm"))
            {
                frm = new DataTableForm(sql);
                dictform.Add("DataTableForm", frm);
            }
            else
            {
                frm = dictform["DataTableForm"];
            }
            OpenForm(frm);
        }

        private void 本地数据库更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            数据库更新ToolStripMenuItem_Click(sender, e);
            this.Cursor = Cursors.Default;
        }



        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Console.WriteLine(e.ClickedItem);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            switch (sender.ToString()) 
            {
                case "BOM":
                    SetChecked(bOMToolStripMenuItem1);
                    break;
                case "物料":
                    SetChecked(物料ToolStripMenuItem1);
                    break;
                case "进度":
                    SetChecked(进度ToolStripMenuItem1);
                    break;
                case "库存":
                    SetChecked(库存ToolStripMenuItem1);
                    break;
                case "物料档案":
                    SetChecked(物料档案ToolStripMenuItem1);
                    break;
                case "数据库校验":
                    SetChecked(数据库校验ToolStripMenuItem1);
                    break;
            }   
        }
        private void SetChecked(ToolStripMenuItem item) 
        {
            bOMToolStripMenuItem1.Checked = false;
            物料ToolStripMenuItem1.Checked = false;
            进度ToolStripMenuItem1.Checked = false;
            库存ToolStripMenuItem1.Checked = false;
            物料档案ToolStripMenuItem1.Checked = false;
            数据库校验ToolStripMenuItem1.Checked = false;
            item.Checked = true;
            Console.WriteLine(item.Text);
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["默认主页"] == null)
            {
                config.AppSettings.Settings.Add("默认主页",item.Text);
            }
            else
            {
                config.AppSettings.Settings["默认主页"].Value = item.Text;
            }
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");

        }

        private void UpdateTimeShow()
        {
            DateTime dt = Convert.ToDateTime(sql.sqlUpdateTime);
            DateTime nowTime = DateTime.Now;
            DateTime start = Convert.ToDateTime(dt.ToShortDateString());
            DateTime end = Convert.ToDateTime(nowTime.ToShortDateString());

            TimeSpan sp = end.Subtract(start);
            if (sp.TotalDays > 3)
            {
                sqlUpdateTime_Text.ForeColor = Color.Red;
                sqlUpdateTime_Text.Text = "数据库更新时间：" + dt.ToString();
                toolStripLabel1.ForeColor = Color.Red;
                toolStripLabel1.Text = "数据库已经很长时间未更新，请连接内网更新数据";
            }
            else
            {
                sqlUpdateTime_Text.ForeColor = Color.Green;
                sqlUpdateTime_Text.Text = "数据库更新时间：" + dt.ToString();
                toolStripLabel1.Text = "";
            }
        }

        private void 数据库更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sql.SqlUpdate())
            {
                sql.GetTalbe();
                UpdateTimeShow();
                MessageBox.Show("数据更新成功");
            }
            else
            {
                MessageBox.Show("数据更新失败");
            }

        }

        private void 生产ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("MoMForm"))
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable data = sqlSelectTable.GetMom();
                frm = new ChildrenForm(data);
                var client = frm as ChildrenForm;
                client.SetScrDataGrid();
                client.CellDouble += new CellDoubleClickHandler((col,dr)=> {
                    this.Cursor = Cursors.WaitCursor;
                    if (dr[col] != null && !dr["项目编码"].Equals(""))
                    {
                        data = sqlSelectTable.GetMom_moallocate(dr["项目编码"].ToString());
                    }
                    DataShow children = new DataShow(data);
                    children.Show();
                    this.Cursor = Cursors.Default;
                });
                dictform.Add("MoMForm", frm);
                this.Cursor = Cursors.Default;
            }
            else
            {
                frm = dictform["MoMForm"];
            }
            OpenForm(frm);

        }

        private void 站点查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseForm();
            Control frm;
            if (!dictform.ContainsKey("TreeTaskForm"))
            {
                frm = new TreeTaskForm(sql);
                dictform.Add("TreeTaskForm", frm);
            }
            else
            {
                frm = dictform["TreeTaskForm"];
            }
            OpenForm(frm);
        }


        /// <summary>   
        /// 检测是否有安裝 U8,若没有安装U8,则站点查询不显示 
        /// </summary>   
        private void checkU8()
        {
            站点查询ToolStripMenuItem.Visible = false;
            RegistryKey regKey = Registry.CurrentUser;
            RegistryKey regSubKey = regKey.OpenSubKey(@"Software", false);
            foreach (string subKeyName in regSubKey.GetSubKeyNames())
            {
                Console.WriteLine(subKeyName);
                if (subKeyName.ToString().Contains("Yonyou"))
                {
                    站点查询ToolStripMenuItem.Visible = true;
                }
            }
        }
    }
}
