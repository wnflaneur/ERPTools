using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ERPTools.UserForm
{
    public delegate void OutHandler(string colName, List<string> outlist);
    public delegate void OutLikeHandler(string colName, string value);
    public delegate void OutAllHandler(string colName);
    public delegate void OutTimeHandler(string colName, DateTime start, DateTime end);
    public partial class UserScr : UserControl
    {

        public OutHandler Outevent;
        public OutLikeHandler OutLikeEvent;
        public OutAllHandler OutAllEvent;
        public OutTimeHandler OutTimeEvent;
        private List<string> boxlist = new List<string>();
        private int num = 0;
        public string ColName
        {
            get => ColName_Lab.Text;
            set => ColName_Lab.Text = value;
        }
        private List<string> oldList;

        public List<string> OldList { set => oldList = value; }

        private List<string> colList;
        public List<string> inColList
        {
            set => colList = value;
        }
        private List<string> outcolList;
        public UserScr()
        {
            InitializeComponent();
            Col_ListBox.CheckOnClick = true;
        }
        public void Show(Point point, int num = 0)
        {
            this.num = num;
            if (num == 0)
            {
                Col_TextBox.Enabled = true;
                flowLayoutPanel1.Visible = false;
                Col_ListBox.Visible = true;
                Col_TextBox.Text = "";
                this.Location = point;
                Col_ListBox.Items.Clear();
                Col_ListBox.Items.Add("全选");
                Col_ListBox.Items.Add("空");
                Col_ListBox.Items.AddRange(colList.ToArray());
                string[] list = new string[Col_ListBox.Items.Count];
                Col_ListBox.Items.CopyTo(list, 0);
                boxlist.Clear();
                boxlist.AddRange(list);
                if (oldList != null)
                {
                    foreach (var str in oldList)
                    {
                        for (int i = 1; i < Col_ListBox.Items.Count; i++)
                        {
                            var box = Col_ListBox.Items[i];
                            if (box.Equals(str))
                            {
                                Col_ListBox.SetItemCheckState(i, CheckState.Checked);
                            }

                        }
                    }
                }
            }
            else if (num == 1)
            {
                Col_TextBox.Enabled = false;
                flowLayoutPanel1.Visible = true;
                Col_ListBox.Visible = false;
                this.Location = point;

                startdateTime.Value = DateTime.Now.AddDays(-30);
            }

            this.BringToFront();
        }

        private void OK_Btn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.SendToBack();
            if (num == 0)
            {
                outcolList = new List<string>();
                foreach (string outstr in Col_ListBox.CheckedItems)
                {
                    if (outstr.Equals("全选"))
                    {
                        OutAllEvent(ColName_Lab.Text);
                        break;
                    }
                    else
                    {
                        outcolList.Add(outstr);
                    }
                }
                if (outcolList.Count == 0 && !Col_TextBox.Text.Equals(""))
                {
                    OutLikeEvent(ColName_Lab.Text, Col_TextBox.Text);
                }
                else
                {
                    Outevent(ColName_Lab.Text, outcolList);
                }
            }
            else if (num == 1)
            {
                OutTimeEvent(ColName, startdateTime.Value, enddateTime.Value);
            }
            this.Cursor = Cursors.Default;

        }

        private bool checkBoxAll = false;
        private void Col_ListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = e.Index;
            var box = Col_ListBox.Items[index];
            if (box.Equals("全选") && e.CurrentValue == CheckState.Checked)
            {
                if (checkBoxAll)
                {
                    for (int i = 1; i < Col_ListBox.Items.Count; i++)
                    {
                        Col_ListBox.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
            else if (box.Equals("全选") && e.CurrentValue != CheckState.Checked)
            {
                for (int i = 1; i < Col_ListBox.Items.Count; i++)
                {
                    Col_ListBox.SetItemCheckState(i, CheckState.Checked);
                    checkBoxAll = true;
                }
            }
            if (index != 0 && e.CurrentValue == CheckState.Checked)
            {
                checkBoxAll = false;
                Col_ListBox.SetItemCheckState(0, CheckState.Unchecked);
            }
        }

        private void Col_TextBox_TextChanged(object sender, EventArgs e)
        {
            Col_ListBox.Items.Clear();
            if (!Col_TextBox.Text.Equals(""))
            {
                foreach (string box in boxlist)
                {
                    if (box.IndexOf(Col_TextBox.Text) > -1)
                    {
                        Col_ListBox.Items.Add(box);
                    }
                }
            }
            else
            {
                Col_ListBox.Items.AddRange(boxlist.ToArray());
            }
        }

        private void UserScr_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
