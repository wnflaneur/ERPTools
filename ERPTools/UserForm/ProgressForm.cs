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
    public partial class ProgressForm : UserControl
    {
        private string cItem;
        private string resermand;
        private string startDateTime;
        private string endDateTime;
        private SQLSelectTable sqlSelectTable;
        private DataTable olddt;
        private DataTable dataTable;
        private DataTable dataAll;
        private Dictionary<string, string> olddict = new Dictionary<string, string>();
        public ProgressForm()
        {
            InitializeComponent();
         }

        public ProgressForm(SqlProcessor sqlProcessor) : this()
        {
            sqlSelectTable = new SQLSelectTable(sqlProcessor);
            DataTable data = sqlSelectTable.GetMainTable();
            scrDataGridView1.CellDoubleClickEvent += new CellDoubleClickHandler(CellDoubleClick);
            scrDataGridView1.SetBindingSource(data);
        }

        public ProgressForm(string str) : this()
        {
            查询ToolStripMenuItem_Click(null, null);
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectForm selectForm = new SelectForm();
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                cItem = selectForm.CItem;
                resermand = selectForm.Resermand;
                startDateTime = selectForm.StartDateTime.ToString();
                endDateTime = selectForm.EndDateTime.ToString();
                olddict.Clear();
                olddict.Add("项目编码", cItem);
                olddict.Add("请购人", resermand);
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = sqlSelectTable.GetMainTable(cItemCode: cItem, resermand: resermand, starttime: startDateTime, endtime: endDateTime);
                this.Cursor = Cursors.Default;
                if (dt.Rows.Count > 0)
                {
                    dataTable = dt.Copy();
                    olddt = dt.Copy();
                    dataAll = dt.Copy();
                    scrDataGridView1.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("没有查询到信息");
                }
            }
        }
        private void CellDoubleClick(int colindex, DataRow dr)
        {
            string col = dataTable.Columns[colindex].ColumnName;
            string value = dr[colindex].ToString();
            string cItem="";
            string cInv="";
            if (!dr["项目编码"].ToString().Equals(""))
                cItem = dr["项目编码"].ToString();
            if(!dr["物料编码"].ToString().Equals(""))
                cInv= dr["物料编码"].ToString();
            string resermand;
            if (!dr["请购人"].ToString().Equals(""))
                resermand = dr["请购人"].ToString();


            if (!value.Equals(""))
            {
                DataShow children;
                DataTable data;
                switch (col)
                {
                    case "ECN单号":
                        data = sqlSelectTable.GetECN(ecnid: value);
                        children = new DataShow(data);
                        children.Show();
                        break;
                    case "BOM单号":
                        data = sqlSelectTable.GetBOM(bomID: value);
                        children = new DataShow(data);
                        children.Show();
                        break;
                    case "请购单号":
                        data = sqlSelectTable.GetPU_AppVouchs(cCode: value);
                        children = new DataShow(data);
                        children.Show();
                        break;
                    case "采购订单号":
                        data = sqlSelectTable.GetPO_Podetails(cPOID: value);
                        children = new DataShow(data);
                        children.Show();
                        break;
                    case "采购入库单号":
                        data = sqlSelectTable.GetRdrecords01(id: value);
                        children = new DataShow(data);
                        children.Show();
                        break;
                    case "材料出库单号":
                        data = sqlSelectTable.GetRdrecords11(cItemCode: cItem,cInvCode:cInv);
                        children = new DataShow(data);
                        children.Show();
                        break;
                    default:
                        break;
                }
            }
        }

        private void 未订货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("采购订单号", "");
            dataTable = ToolsBox.GetDataTableisNull(dataAll, dict);
            Console.WriteLine(dataTable.Rows.Count);
            scrDataGridView1.DataSource = dataTable;
        }

        private void 未入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("采购订单号", "");
            dataTable = ToolsBox.GetDataTableisNotNull(dataAll, dict);
            dict.Clear();
            dict.Add("采购入库单号", "");
            dataTable = ToolsBox.GetDataTableisNull(dataTable, dict);
            Console.WriteLine(dataTable.Rows.Count);
            scrDataGridView1.DataSource = dataTable;
        }

        private void 未出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("采购订单号", "");
            dict.Add("采购入库单号", "");
            dataTable = ToolsBox.GetDataTableisNotNull(dataAll, dict);
            dict.Clear();
            dict.Add("材料出库单号", "");
            dataTable = ToolsBox.GetDataTableisNull(dataTable, dict);
            Console.WriteLine(dataTable.Rows.Count);
            scrDataGridView1.DataSource = dataTable;
        }

        private void 已出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("材料出库单号", "");
            dataTable = ToolsBox.GetDataTableisNotNull(dataAll, dict);
            Console.WriteLine(dataTable.Rows.Count);
            scrDataGridView1.DataSource = dataTable;
        }

        private void 全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scrDataGridView1.DataSource = dataAll;
        }
    }
}
