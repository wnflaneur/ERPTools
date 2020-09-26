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
    public partial class ProgressBarForm : Form
    {
        public int Value { get; set; }
        private bool stop = false;
        public bool Stop { get { return stop; } set { stop = value; } }

        private int count = 1;
        public int Count { get { return count; } set { if (value <= 0) { count = 1; } else { count = value; } } }
        private delegate void DelSetPro(int pro);//设置进度条进度的委托方法 
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        private void ProgressBarForm_Load(object sender, EventArgs e)
        {
        }
        public void AddProgress(int num)
        {
            //if (this.IsHandleCreated)
            //{
            //    this.Invoke(new Action(() =>
            //    {
            //        progressBar1.Value = Convert.ToInt32(num);

            //    }));
            //}
            //else 
            //{
            progressBar1.Value = Convert.ToInt32(num);
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            countLabel.Text = Count.ToString();
            indexLabel.Text = Value.ToString();
            int val = Value * 100 / Count;
            progressBar1.Value = Convert.ToInt32(val);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Count == Value)
            {
                this.Close();
            }
            else if (Value < Count)
            {
                if (DialogResult.Cancel == MessageBox.Show("BOM还有部分未匹配是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                }
                else
                {
                    Stop = true;
                    this.Close();
                }
            }
        }
    }
}
