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
    public partial class DataForm : Form
    {
        private SqlProcessor sql;
        private SQLSelectTable sqlSelectTable;
        private Param param = new Param();
        private string configPath = Application.StartupPath + "\\配置文件\\Config.xml";
        public DataRow _row = null;
        private DataTable table = new DataTable();
        private Dictionary<string, string> olddict = new Dictionary<string, string>();
        private int status = 0;
        public int Status { get => status; set => status = value; }


        public DataForm()
        {
            InitializeComponent();

        }
        public DataForm(SqlProcessor sql, DataTable dt) : this()
        {
            this.sql = sql;
            this.sqlSelectTable = new SQLSelectTable(sql);
            table = dt.Copy();
            scrDataGridView1.SetBindingSource(table);
        }
        public DataForm(SqlProcessor sql, DataTable data, DataTable dataTable) : this()
        {
            this.sql = sql;
            this.sqlSelectTable = new SQLSelectTable(sql);
            myDataGridView2.DataSource = dataTable;
            DataKeep.Serialize(configPath, false, ref param);
            foreach (Map map in param.Maps)
            {
                table.Columns.Add(map.Value);
            }
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    DataRow dr = table.NewRow();
                    foreach (Map map in param.Maps)
                    {
                        dr[map.Value] = row[map.Name];
                    }
                    table.Rows.Add(dr);
                }
                scrDataGridView1.SetBindingSource(table);
            }

        }
        public DataForm(SqlProcessor sql, string queryStr, string wayQuery, string options, double similarity) : this()
        {
            this.sql = sql;
            this.sqlSelectTable = new SQLSelectTable(sql);
            DataKeep.Serialize(configPath, false, ref param);
            foreach (Map map in param.Maps)
            {
                table.Columns.Add(map.Value);
            }
            DataTable data = DataShow(queryStr, wayQuery, options, similarity);
            if (data != null)
            {
                foreach (DataRow row in data.Rows)
                {
                    DataRow dr = table.NewRow();
                    foreach (Map map in param.Maps)
                    {
                        dr[map.Value] = row[map.Name];
                    }
                    table.Rows.Add(dr);
                }
            }
            myDataGridView2.Visible = false;
            tableLayoutPanel1.Controls.Remove(myDataGridView2);
            tableLayoutPanel1.SetRow(scrDataGridView1, 0);
            tableLayoutPanel1.SetRowSpan(scrDataGridView1, 2);
            tableLayoutPanel1.Refresh();
            scrDataGridView1.SetBindingSource(table);

        }
        public DataTable DataShow(string queryStr, string wayQuery, string options, double similarity)
        {
            foreach (Map map in param.Maps)
            {
                if (map.Value.Equals(options))
                {
                    options = map.Name;
                }
            }
            if (wayQuery.Equals("精确查询"))
            {
                DataTable data = sql.AccurateQuery(queryStr, options);
                if (data != null && data.Rows.Count > 0)
                {
                    return data;
                }
            }
            else if (wayQuery.Equals("相似度模糊查询"))
            {

                DataTable data = ToolsBox.SimilarityQuery(sql.dataTable, options, queryStr, similarity);
                if (data != null && data.Rows.Count > 0)
                {
                    return data;
                }
            }
            else if (wayQuery.Equals("包含关系查询"))
            {
                DataTable data = sql.ContainsQuery(queryStr, options);
                if (data != null && data.Rows.Count > 0)
                {
                    return data;
                }
            }
            return null;
        }

        private void CellDoubleClick(int colintdex, DataRow dr)
        {

            _row = dr;
            Status = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Status == 0)
            {
                Status = 2;
            }
        }

        private void DataForm_Load(object sender, EventArgs e)
        {
            scrDataGridView1.SetDataGridView();
            scrDataGridView1.CellDoubleClickEvent += new CellDoubleClickHandler(CellDoubleClick);
        }
    }
}
