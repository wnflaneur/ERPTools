namespace ERPTools.UserForm
{
    partial class DataTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.规格名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规格ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规格名称规格去除特殊字符ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规格去除特殊字符ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规格包含ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规格包含下划线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.scrDataGridView1 = new ERPTools.UserForm.ScrDataGridView();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.规格名称ToolStripMenuItem,
            this.规格ToolStripMenuItem,
            this.规格名称规格去除特殊字符ToolStripMenuItem,
            this.规格去除特殊字符ToolStripMenuItem,
            this.规格包含ToolStripMenuItem,
            this.规格包含下划线ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 规格名称ToolStripMenuItem
            // 
            this.规格名称ToolStripMenuItem.Name = "规格名称ToolStripMenuItem";
            this.规格名称ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.规格名称ToolStripMenuItem.Text = "规格名称";
            this.规格名称ToolStripMenuItem.Click += new System.EventHandler(this.规格名称ToolStripMenuItem_Click);
            // 
            // 规格ToolStripMenuItem
            // 
            this.规格ToolStripMenuItem.Name = "规格ToolStripMenuItem";
            this.规格ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.规格ToolStripMenuItem.Text = "规格";
            this.规格ToolStripMenuItem.Click += new System.EventHandler(this.规格ToolStripMenuItem_Click);
            // 
            // 规格名称规格去除特殊字符ToolStripMenuItem
            // 
            this.规格名称规格去除特殊字符ToolStripMenuItem.Name = "规格名称规格去除特殊字符ToolStripMenuItem";
            this.规格名称规格去除特殊字符ToolStripMenuItem.Size = new System.Drawing.Size(218, 24);
            this.规格名称规格去除特殊字符ToolStripMenuItem.Text = "规格名称，规格去除特殊字符";
            this.规格名称规格去除特殊字符ToolStripMenuItem.Click += new System.EventHandler(this.规格名称规格去除特殊字符ToolStripMenuItem_Click);
            // 
            // 规格去除特殊字符ToolStripMenuItem
            // 
            this.规格去除特殊字符ToolStripMenuItem.Name = "规格去除特殊字符ToolStripMenuItem";
            this.规格去除特殊字符ToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.规格去除特殊字符ToolStripMenuItem.Text = "规格去除特殊字符";
            this.规格去除特殊字符ToolStripMenuItem.Click += new System.EventHandler(this.规格去除特殊字符ToolStripMenuItem_Click);
            // 
            // 规格包含ToolStripMenuItem
            // 
            this.规格包含ToolStripMenuItem.Name = "规格包含ToolStripMenuItem";
            this.规格包含ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.规格包含ToolStripMenuItem.Text = "规格包含";
            this.规格包含ToolStripMenuItem.Click += new System.EventHandler(this.规格包含ToolStripMenuItem_Click);
            // 
            // 规格包含下划线ToolStripMenuItem
            // 
            this.规格包含下划线ToolStripMenuItem.Name = "规格包含下划线ToolStripMenuItem";
            this.规格包含下划线ToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.规格包含下划线ToolStripMenuItem.Text = "规格包含下划线";
            this.规格包含下划线ToolStripMenuItem.Click += new System.EventHandler(this.规格包含下划线ToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.scrDataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.42725F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1032, 648);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // scrDataGridView1
            // 
            this.scrDataGridView1.DataSource = null;
            this.scrDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrDataGridView1.Location = new System.Drawing.Point(3, 2);
            this.scrDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrDataGridView1.Name = "scrDataGridView1";
            this.scrDataGridView1.Size = new System.Drawing.Size(1026, 644);
            this.scrDataGridView1.TabIndex = 4;
            // 
            // DataTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Name = "DataTableForm";
            this.Size = new System.Drawing.Size(1032, 676);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 规格名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 规格去除特殊字符ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 规格包含ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 规格包含下划线ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ScrDataGridView scrDataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 规格ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 规格名称规格去除特殊字符ToolStripMenuItem;
    }
}
