namespace ERPTools.UserForm
{
    partial class ScrDataGridView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.筛选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myDataGridViewRead1 = new ERPTools.UserForm.MyDataGridViewRead();
            this.pagerControl1 = new ERPTools.UserForm.PagerControl();
            this.userScr1 = new ERPTools.UserForm.UserScr();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewRead1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.userScr1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1321, 736);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1321, 764);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.myDataGridViewRead1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pagerControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.24657F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.753425F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1321, 736);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.筛选ToolStripMenuItem,
            this.显示全部ToolStripMenuItem,
            this.导出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1321, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 筛选ToolStripMenuItem
            // 
            this.筛选ToolStripMenuItem.Name = "筛选ToolStripMenuItem";
            this.筛选ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.筛选ToolStripMenuItem.Text = "筛选";
            this.筛选ToolStripMenuItem.Click += new System.EventHandler(this.筛选ToolStripMenuItem_Click);
            // 
            // 显示全部ToolStripMenuItem
            // 
            this.显示全部ToolStripMenuItem.Name = "显示全部ToolStripMenuItem";
            this.显示全部ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.显示全部ToolStripMenuItem.Text = "显示全部";
            this.显示全部ToolStripMenuItem.Click += new System.EventHandler(this.显示全部ToolStripMenuItem_Click);
            // 
            // myDataGridViewRead1
            // 
            this.myDataGridViewRead1.AllowUserToAddRows = false;
            this.myDataGridViewRead1.AllowUserToDeleteRows = false;
            this.myDataGridViewRead1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.myDataGridViewRead1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridViewRead1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.myDataGridViewRead1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.myDataGridViewRead1.BackgroundColor = System.Drawing.Color.White;
            this.myDataGridViewRead1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myDataGridViewRead1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.myDataGridViewRead1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.myDataGridViewRead1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.myDataGridViewRead1.DefaultCellStyle = dataGridViewCellStyle3;
            this.myDataGridViewRead1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridViewRead1.EnableHeadersVisualStyles = false;
            this.myDataGridViewRead1.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.myDataGridViewRead1.Location = new System.Drawing.Point(3, 2);
            this.myDataGridViewRead1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.myDataGridViewRead1.Name = "myDataGridViewRead1";
            this.myDataGridViewRead1.ReadOnly = true;
            this.myDataGridViewRead1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.myDataGridViewRead1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.myDataGridViewRead1.RowTemplate.Height = 23;
            this.myDataGridViewRead1.RowTemplate.ReadOnly = true;
            this.myDataGridViewRead1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myDataGridViewRead1.Size = new System.Drawing.Size(1315, 689);
            this.myDataGridViewRead1.TabIndex = 0;
            this.myDataGridViewRead1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridViewRead1_CellDoubleClick);
            this.myDataGridViewRead1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.myDataGridViewRead1_Scroll);
            this.myDataGridViewRead1.BindingContextChanged += new System.EventHandler(this.myDataGridViewRead1_BindingContextChanged);
            this.myDataGridViewRead1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.myDataGridViewRead1_MouseClick_1);
            // 
            // pagerControl1
            // 
            this.pagerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagerControl1.JumpText = "跳转";
            this.pagerControl1.Location = new System.Drawing.Point(3, 695);
            this.pagerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pagerControl1.Name = "pagerControl1";
            this.pagerControl1.PageIndex = 1;
            this.pagerControl1.PageSize = 100;
            this.pagerControl1.RecordCount = 0;
            this.pagerControl1.Size = new System.Drawing.Size(1315, 39);
            this.pagerControl1.TabIndex = 1;
            // 
            // userScr1
            // 
            this.userScr1.AutoScroll = true;
            this.userScr1.AutoSize = true;
            this.userScr1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userScr1.BackColor = System.Drawing.SystemColors.Control;
            this.userScr1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.userScr1.ColName = "列名";
            this.userScr1.Location = new System.Drawing.Point(115, 40);
            this.userScr1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userScr1.Name = "userScr1";
            this.userScr1.Size = new System.Drawing.Size(280, 503);
            this.userScr1.TabIndex = 0;
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.导出ToolStripMenuItem.Text = "导出";
            this.导出ToolStripMenuItem.Click += new System.EventHandler(this.导出ToolStripMenuItem_Click);
            // 
            // ScrDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ScrDataGridView";
            this.Size = new System.Drawing.Size(1321, 764);
            this.Load += new System.EventHandler(this.ScrDataGridView_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridViewRead1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private UserScr userScr1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MyDataGridViewRead myDataGridViewRead1;
        private PagerControl pagerControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 筛选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
    }
}
