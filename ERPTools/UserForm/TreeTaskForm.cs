using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ExcelTools.Src;
using System.Data.Entity.Validation;

namespace ERPTools.UserForm
{
    public partial class TreeTaskForm : UserControl
    {

        SqlProcessor sql;
        string configPath;
        Param param = new Param();
        Dictionary<string, string> dictParam = new Dictionary<string, string>();
        DataTable dt;
        List<DataRow> rowlist = new List<DataRow>();
        public TreeTaskForm()
        {
            InitializeComponent();
        }

        public TreeTaskForm(SqlProcessor sql) : this()
        {
            this.sql = sql;
            scrDataGridView1.CellDoubleClickEvent += new CellDoubleClickHandler(CellDoubleClick);
            scrDataGridView1.SetDataGridView();
            TreeTaskForm_Load();
        }
        public void CellDoubleClick(int colindex, DataRow dr)
        {
        }

        private bool status=false;
        private void TreeTaskForm_Load()
        {

            treeView1.LabelEdit = true;
            DataTable dataTable= sql.SelectDb("select * from METR_Task_Class", "METR_Task_Class");
            DataTable dataClient= sql.SelectDb("select * from METR_Task_Client", "METR_Task_Client");
            treeView1.LabelEdit = true;
            DataTable table=  sql.SelectDb("select * from METR_ERP_TaskLog ", "METR_ERP_TaskLog");
            Dictionary<string, Dictionary<string, HashSet<string>>> dict = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            foreach (DataRow row in table.Rows) 
            {
                if (dict.ContainsKey(row[0].ToString()))
                {
                    Dictionary<string, HashSet<string>> client = dict[row[0].ToString()];
                    if (client.ContainsKey(row[1].ToString()))
                    {
                        HashSet<string> str = client[row[1].ToString()];
                        str.Add(row[3].ToString());
                    }
                    else
                    {
                        HashSet<string> str = new HashSet<string>();
                        str.Add(row[3].ToString());
                        client.Add(row[1].ToString(), str);
                    }
                }
                else 
                {
                    Dictionary<string, HashSet<string>> client = new Dictionary<string, HashSet<string>>();
                    HashSet<string> str = new HashSet<string>();
                    str.Add(row[3].ToString());
                    client.Add(row[1].ToString(),str);
                    dict.Add(row[0].ToString(),client);
                }
            }
            if (dict.Keys.Count > 0)
            {
                status = true;
                foreach (var key in dict.Keys)
                {
                    TreeNode node = new TreeNode();
                    node.Text = "账套 " + key;
                    node.Name = key;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        TreeNode nodeclass = new TreeNode();
                        nodeclass.Name = row[1].ToString();
                        int count = 0;
                        if (dict[key].ContainsKey(row[1].ToString()))
                        {
                            count = dict[key][row[1].ToString()].Count;
                        }
                        nodeclass.Text = row[1].ToString() + string.Format(" [{0}/{1}]", count, row[2]);
                        node.Nodes.Add(nodeclass);
                        DataRow[] datas = dataClient.Select(string.Format("classID = {0}", row[0]));
                        Console.WriteLine(datas.Length);
                        foreach (DataRow dr in datas)
                        {
                            TreeNode nodeclient = new TreeNode();
                            nodeclient.Name = dr[1].ToString();
                            int countclient = 0;
                            DataRow[] rows = table.Select(string.Format("账套 like '{0}' and 模块 like '{1}'", key, dr[1].ToString()));
                            if (rows != null)
                            {
                                countclient = rows.Length;
                            }
                            nodeclient.Text = dr[1].ToString() + string.Format(" [{0}]", countclient);
                            nodeclass.Nodes.Add(nodeclient);
                        }
                    }
                    treeView1.Nodes.Add(node);
                }
            }
            else
            {
                status = false;
                TreeNode node = new TreeNode();
                node.Text = "暂无人使用站点";
                treeView1.Nodes.Add(node);
            }
            treeView1.ExpandAll();
        }
      
        
        
        public int m_MouseClicks = 0;


        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string str = e.Node.Text.Split(' ')[0];
            if (e.Node.Text.Contains("账套"))
            {

                dt = sql.SelectDb(string.Format("select * from METR_ERP_TaskLog where 账套 like '{0}'", e.Node.Text.Split(' ')[1]), "Task_View");
            }
            else
            {
                string key = "";
                if (e.Node.Parent.Text.Contains("账套"))
                {
                    key = e.Node.Parent.Text.Split(' ')[1];
                }
                else if (e.Node.Parent.Parent.Text.Contains("账套"))
                {
                    key = e.Node.Parent.Parent.Text.Split(' ')[1];
                }
                dt = sql.SelectDb(string.Format("select * from METR_ERP_TaskLog where  账套 like  '{0}'  and (站点名 like '{1}' OR 模块 like '{1}')", key, str), "Task_View");
            }
            scrDataGridView1.SetBindingSource(dt);
            this.Cursor = Cursors.Default;
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            this.m_MouseClicks = e.Clicks;
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (this.m_MouseClicks > 1)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (this.m_MouseClicks > 1)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Update();
        }

        public void Update() 
        {
            treeView1.LabelEdit = true;
            DataTable dataTable = sql.SelectDb("select * from METR_Task_Class", "METR_Task_Class");
            DataTable dataClient = sql.SelectDb("select * from METR_Task_Client", "METR_Task_Client");
            treeView1.LabelEdit = true;
            DataTable table = sql.SelectDb("select * from METR_ERP_TaskLog ", "METR_ERP_TaskLog");
            Dictionary<string, Dictionary<string, HashSet<string>>> dict = new Dictionary<string, Dictionary<string, HashSet<string>>>();
            foreach (DataRow row in table.Rows)
            {
                if (dict.ContainsKey(row[0].ToString()))
                {
                    Dictionary<string, HashSet<string>> client = dict[row[0].ToString()];
                    if (client.ContainsKey(row[1].ToString()))
                    {
                        HashSet<string> str = client[row[1].ToString()];
                        str.Add(row[3].ToString());
                    }
                    else
                    {
                        HashSet<string> str = new HashSet<string>();
                        str.Add(row[3].ToString());
                        client.Add(row[1].ToString(), str);
                    }
                }
                else
                {
                    Dictionary<string, HashSet<string>> client = new Dictionary<string, HashSet<string>>();
                    HashSet<string> str = new HashSet<string>();
                    str.Add(row[3].ToString());
                    client.Add(row[1].ToString(), str);
                    dict.Add(row[0].ToString(), client);
                }
            }
            if (dict.Keys.Count > 0)
            {
                if (!status) 
                {
                    treeView1.Nodes.Clear();
                    status = true;
                }
                foreach (var key in dict.Keys)
                {
                    TreeNode node;
                    if (!treeView1.Nodes.ContainsKey(key))
                    {
                        node = new TreeNode();
                        node.Name = key;
                        node.Text = "账套 " + key;
                        treeView1.Nodes.Add(node);
                    }
                    else 
                    {
                        node = treeView1.Nodes[key];
                    }
                    foreach (DataRow row in dataTable.Rows)
                    {
                        TreeNode nodeclass = new TreeNode();
                        if (!node.Nodes.ContainsKey(row[1].ToString()))
                        {
                            nodeclass = new TreeNode();
                            nodeclass.Name = row[1].ToString();
                            node.Nodes.Add(nodeclass);
                        }
                        else
                        {
                            nodeclass = node.Nodes[row[1].ToString()];
                        }
                        int count = 0;
                        if (dict[key].ContainsKey(row[1].ToString()))
                        {
                            count = dict[key][row[1].ToString()].Count;
                        }
                        nodeclass.Text = row[1].ToString() + string.Format(" [{0}/{1}]", count, row[2]);
                        DataRow[] datas = dataClient.Select(string.Format("classID = {0}", row[0]));
                        Console.WriteLine(datas.Length);
                        foreach (DataRow dr in datas)
                        {
                            TreeNode nodeclient = new TreeNode();
                            if (!nodeclass.Nodes.ContainsKey(dr[1].ToString()))
                            {
                                nodeclient = new TreeNode();
                                nodeclient.Name = dr[1].ToString();
                                nodeclass.Nodes.Add(nodeclient);
                            }
                            else
                            {
                                nodeclient = nodeclass.Nodes[dr[1].ToString()];
                            }
                            int countclient = 0;
                            DataRow[] rows = table.Select(string.Format("账套 like '{0}' and 模块 like '{1}'", key, dr[1].ToString()));
                            if (rows != null)
                            {
                                countclient = rows.Length;
                            }
                            nodeclient.Text = dr[1].ToString() + string.Format(" [{0}]", countclient);
                        }
                    }
                }
            }
            else
            {
                status = false;
                TreeNode node = new TreeNode();
                node.Text = "暂无人使用站点";
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add(node);
            }
        }
    }
}
