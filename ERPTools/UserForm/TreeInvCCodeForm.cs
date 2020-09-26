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

namespace ERPTools.UserForm
{
    public partial class TreeInvCCodeForm : UserControl
    {

        SqlProcessor sql;
        string configPath;
        Param param = new Param();
        Dictionary<string, string> dictParam = new Dictionary<string, string>();
        DataTable dt;
        List<DataRow> rowlist = new List<DataRow>();
        public TreeInvCCodeForm()
        {
            InitializeComponent();
        }

        public TreeInvCCodeForm(SqlProcessor sql) : this()
        {
            dataTable = sql.InventoryClassTable;
            this.sql = sql;
            scrDataGridView1.CellDoubleClickEvent += new CellDoubleClickHandler(CellDoubleClick);
            scrDataGridView1.SetDataGridView();
            TreeInvCCode_Load();
        }
        public void CellDoubleClick(int colindex, DataRow dr)
        {
        }

        private void TreeInvCCode_Load()
        {
            configPath = Application.StartupPath + "\\配置文件\\Config.xml";
            DataKeep.Serialize(configPath, false, ref param);
            foreach (Map map in param.Maps)
            {
                if (!dictParam.ContainsKey(map.Name))
                {
                    dictParam.Add(map.Name, map.Value);
                }
            }

            dt = new DataTable();
            foreach (DataColumn col in sql.dataTable.Columns)
            {
                if (dictParam.ContainsKey(col.ColumnName))
                {
                    string value = dictParam[col.ColumnName];
                    dt.Columns.Add(value);
                }
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();
            treeView1.LabelEdit = true;
            foreach (DataRow dr in dataTable.Rows)
            {
                MyTreeNode node = tree;
                int i = 0;
                foreach (var bat in Encoding.ASCII.GetBytes(dr["cInvCCode"].ToString()))
                {
                    if (node.node.ContainsKey(bat))
                    {
                        node = node.node[bat];
                    }
                    else
                    {
                        MyTreeNode treeNode = new MyTreeNode();
                        treeNode.num = bat;
                        node.node.Add(bat, treeNode);
                        node = treeNode;
                    }
                }
                if (!cInvStatus.ContainsKey(dr["cInvCCode"].ToString()))
                {
                    cInvStatus.Add(dr["cInvCCode"].ToString(), Convert.ToBoolean(dr["bInvCEnd"].ToString()));
                }
                node.treeNode = new TreeNode();
                node.cInvCCode = dr["cInvCCode"].ToString();
                node.treeNode.Text = dr["cInvCCode"].ToString() + " " + dr["cInvCName"].ToString();
                node.bInvCEnd = Convert.ToBoolean(dr["bInvCEnd"].ToString());
            }
            TreeNode treeNode1 = new TreeNode();
            treeNode1.Text = "全部";
            treeView1.Nodes.Add(treeNode1);
            SetTree(tree, treeNode1);
            foreach (TreeNode node in treeView1.Nodes) 
            {
                node.Expand();
                foreach (TreeNode twonode in node.Nodes)
                {
                    twonode.Expand();
                }
            }

        }
      
        
        
        private void SetTree(MyTreeNode myTree, TreeNode treeNode)
        {
            if (myTree.bInvCEnd == true)
            {
                return;
            }
            Dictionary<byte, MyTreeNode> nodedict = myTree.node.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
            foreach (var by in nodedict.Keys)
            {
                MyTreeNode myTreeNode = nodedict[by];
                TreeNode node = myTreeNode.treeNode;
                if (node != null)
                {
                    treeNode.Nodes.Add(node);
                    SetTree(myTreeNode, node);
                }
                else
                {
                    SetTree(myTreeNode, treeNode);
                }
            }
        }
        class MyTreeNode
        {
            public byte num;
            public bool bInvCEnd;
            public TreeNode treeNode;
            public string cInvCCode;
            public Dictionary<byte, MyTreeNode> node = new Dictionary<byte, MyTreeNode>();
        }
        DataTable dataTable;
        private static MyTreeNode tree = new MyTreeNode();

        public string CInvCCode { get; set; }

        private Dictionary<string, bool> cInvStatus = new Dictionary<string, bool>();

        public int m_MouseClicks = 0;


        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dt.Clear();
            rowlist.Clear();
            List<string> liststr = new List<string>();
            string str = e.Node.Text.Split(' ')[0];
            liststr.Add(str);
            GetTree(e.Node, ref liststr);
            DataTable data = sql.AccurateQuery_Like_List(liststr.ToArray(), "cInvCCode");
            foreach (DataRow row in data.Rows) 
            {
                DataRow dr = dt.NewRow();
                foreach (var key in dictParam.Keys) 
                {
                    dr[dictParam[key]] = row[key];
                }
                dt.Rows.Add(dr);
            }
            scrDataGridView1.SetBindingSource(dt);
            this.Cursor = Cursors.Default;
           
        }
        private void GetTree(TreeNode tree, ref List<string> list)
        {
            List<string> liststr = new List<string>();
            IEnumerator enumerator = tree.Nodes.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var node = enumerator.Current as TreeNode;
                GetTree(node, ref list);
            }
            list.Add(tree.Text.Split(' ')[0]);
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
    }
}
