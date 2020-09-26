namespace ERPTools.UserForm
{
    partial class UserScr
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ColName_Lab = new System.Windows.Forms.Label();
            this.Col_TextBox = new System.Windows.Forms.TextBox();
            this.OK_Btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.startdateTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.enddateTime = new System.Windows.Forms.DateTimePicker();
            this.Col_ListBox = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ColName_Lab
            // 
            this.ColName_Lab.AutoSize = true;
            this.ColName_Lab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ColName_Lab.Location = new System.Drawing.Point(3, 0);
            this.ColName_Lab.Name = "ColName_Lab";
            this.ColName_Lab.Size = new System.Drawing.Size(178, 40);
            this.ColName_Lab.TabIndex = 0;
            this.ColName_Lab.Text = "列名";
            this.ColName_Lab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Col_TextBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Col_TextBox, 2);
            this.Col_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Col_TextBox.Location = new System.Drawing.Point(3, 43);
            this.Col_TextBox.Name = "Col_TextBox";
            this.Col_TextBox.Size = new System.Drawing.Size(264, 25);
            this.Col_TextBox.TabIndex = 1;
            this.Col_TextBox.TextChanged += new System.EventHandler(this.Col_TextBox_TextChanged);
            // 
            // OK_Btn
            // 
            this.OK_Btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OK_Btn.Location = new System.Drawing.Point(187, 3);
            this.OK_Btn.Name = "OK_Btn";
            this.OK_Btn.Size = new System.Drawing.Size(80, 34);
            this.OK_Btn.TabIndex = 3;
            this.OK_Btn.Text = "确定";
            this.OK_Btn.UseVisualStyleBackColor = true;
            this.OK_Btn.Click += new System.EventHandler(this.OK_Btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.Controls.Add(this.ColName_Lab, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Col_TextBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OK_Btn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStripContainer1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.62712F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.37288F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 423F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(270, 493);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // toolStripContainer1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStripContainer1, 2);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.flowLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.Col_ListBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(264, 393);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 72);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(264, 418);
            this.toolStripContainer1.TabIndex = 4;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.startdateTime);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.enddateTime);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(264, 393);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始时间";
            // 
            // startdateTime
            // 
            this.startdateTime.Location = new System.Drawing.Point(3, 18);
            this.startdateTime.Name = "startdateTime";
            this.startdateTime.Size = new System.Drawing.Size(200, 25);
            this.startdateTime.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "截止时间";
            // 
            // enddateTime
            // 
            this.enddateTime.Location = new System.Drawing.Point(3, 64);
            this.enddateTime.Name = "enddateTime";
            this.enddateTime.Size = new System.Drawing.Size(200, 25);
            this.enddateTime.TabIndex = 3;
            // 
            // Col_ListBox
            // 
            this.Col_ListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Col_ListBox.FormattingEnabled = true;
            this.Col_ListBox.Items.AddRange(new object[] {
            "全选"});
            this.Col_ListBox.Location = new System.Drawing.Point(0, 0);
            this.Col_ListBox.Name = "Col_ListBox";
            this.Col_ListBox.Size = new System.Drawing.Size(264, 393);
            this.Col_ListBox.TabIndex = 3;
            this.Col_ListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Col_ListBox_ItemCheck);
            // 
            // UserScr
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "UserScr";
            this.Size = new System.Drawing.Size(279, 498);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserScr_Paint);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ColName_Lab;
        private System.Windows.Forms.TextBox Col_TextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button OK_Btn;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startdateTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker enddateTime;
        private System.Windows.Forms.CheckedListBox Col_ListBox;
    }
}
