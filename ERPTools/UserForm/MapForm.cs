using ExcelTools.Src;
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
    public partial class MapForm : Form
    {
        Param param = new Param();
        string configPath = null;
        public MapForm(string configPath)
        {
            this.configPath = configPath;
            DataKeep.Serialize(configPath, false, ref param);

            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");
            if (param.Maps != null)
            {
                foreach (Map map in param.Maps)
                {
                    DataRow row = dt.NewRow();
                    row["Key"] = map.Name;
                    row["Value"] = map.Value;
                    dt.Rows.Add(row);
                }
            }
            dt.AcceptChanges();
            myDataGridView1.DataSource = dt;

        }


        #region 事件
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Param param = new Param();
            List<Map> maps = new List<Map>();
            DataTable dt = (DataTable)myDataGridView1.DataSource;
            foreach (DataRow row in dt.Rows)
            {
                Map map = new Map();

                string name = row["Key"].ToString();
                string value = row["Value"].ToString();
                if (name != "" && value != "")
                {
                    map.Name = name;
                    map.Value = value;
                    maps.Add(map);
                }
            }
            param.Maps = maps.ToArray();
            DataKeep.Serialize(configPath, true, ref param);
            MessageBox.Show("配置已成功保存");
        }

        private void 恢复默认ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strPath = Application.StartupPath + "\\配置文件\\" + configPath.Split('\\').Last();
            System.IO.File.Copy(strPath, configPath, true);
            myDataGridView1.DataSource = null;
            DataKeep.Serialize(configPath, false, ref param);
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");
            foreach (Map map in param.Maps)
            {
                DataRow row = dt.NewRow();
                row["Key"] = map.Name;
                row["Value"] = map.Value;
                dt.Rows.Add(row);
            }
            dt.AcceptChanges();
            myDataGridView1.DataSource = dt;
        }

        private void 还原ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataKeep.Serialize(configPath, false, ref param);
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Value");
            foreach (Map map in param.Maps)
            {
                DataRow row = dt.NewRow();
                row["Key"] = map.Name;
                row["Value"] = map.Value;
                dt.Rows.Add(row);
            }
            dt.AcceptChanges();
            myDataGridView1.DataSource = dt;
        }
        #endregion
    }
}
