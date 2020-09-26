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
    public partial class CInvCCodeForm : Form
    {
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
        public CInvCCodeForm()
        {
            InitializeComponent();
        }
        public CInvCCodeForm(DataTable dt) : this()
        {
            dataTable = dt;
        }

        private void cInvCCodeForm_Load(object sender, EventArgs e)
        {
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
                    Console.Write("cInvCCode " + node.cInvCCode + " ");
                }
                if (!cInvStatus.ContainsKey(dr["cInvCCode"].ToString()))
                {
                    cInvStatus.Add(dr["cInvCCode"].ToString(), Convert.ToBoolean(dr["bInvCEnd"].ToString()));
                }
                Console.WriteLine(dr["cInvCCode"].ToString() + " " + i);
                node.treeNode = new TreeNode();
                node.cInvCCode = dr["cInvCCode"].ToString();
                node.treeNode.Text = dr["cInvCCode"].ToString() + " " + dr["cInvCName"].ToString();
                node.bInvCEnd = Convert.ToBoolean(dr["bInvCEnd"].ToString());
            }
            TreeNode treeNode1 = new TreeNode();
            treeNode1.Text = "全部";
            treeView1.Nodes.Add(treeNode1);
            SetTree(tree, treeNode1);
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

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string str = e.Node.Text.ToString().Split(' ')[0];
            bool bl = false;
            if (cInvStatus.ContainsKey(str))
            {
                bl = cInvStatus[str];
            }
            if (bl)
            {
                this.DialogResult = DialogResult.OK;
                CInvCCode = str;
            }

        }
    }
}
