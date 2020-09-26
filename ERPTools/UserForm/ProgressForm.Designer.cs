namespace ERPTools.UserForm
{
    partial class ProgressForm
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
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.未订货ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.未入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.未出库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.已出库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scrDataGridView1 = new ERPTools.UserForm.ScrDataGridView();
            this.全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询ToolStripMenuItem,
            this.未订货ToolStripMenuItem,
            this.未入库ToolStripMenuItem,
            this.未出库ToolStripMenuItem,
            this.已出库ToolStripMenuItem,
            this.全部ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.查询ToolStripMenuItem.Text = "查询";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 未订货ToolStripMenuItem
            // 
            this.未订货ToolStripMenuItem.Name = "未订货ToolStripMenuItem";
            this.未订货ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.未订货ToolStripMenuItem.Text = "未订货";
            this.未订货ToolStripMenuItem.Click += new System.EventHandler(this.未订货ToolStripMenuItem_Click);
            // 
            // 未入库ToolStripMenuItem
            // 
            this.未入库ToolStripMenuItem.Name = "未入库ToolStripMenuItem";
            this.未入库ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.未入库ToolStripMenuItem.Text = "未入库";
            this.未入库ToolStripMenuItem.Click += new System.EventHandler(this.未入库ToolStripMenuItem_Click);
            // 
            // 未出库ToolStripMenuItem
            // 
            this.未出库ToolStripMenuItem.Name = "未出库ToolStripMenuItem";
            this.未出库ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.未出库ToolStripMenuItem.Text = "未出库";
            this.未出库ToolStripMenuItem.Click += new System.EventHandler(this.未出库ToolStripMenuItem_Click);
            // 
            // 已出库ToolStripMenuItem
            // 
            this.已出库ToolStripMenuItem.Name = "已出库ToolStripMenuItem";
            this.已出库ToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.已出库ToolStripMenuItem.Text = "已出库";
            this.已出库ToolStripMenuItem.Click += new System.EventHandler(this.已出库ToolStripMenuItem_Click);
            // 
            // scrDataGridView1
            // 
            this.scrDataGridView1.DataSource = null;
            this.scrDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrDataGridView1.Location = new System.Drawing.Point(0, 28);
            this.scrDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrDataGridView1.Name = "scrDataGridView1";
            this.scrDataGridView1.Size = new System.Drawing.Size(1924, 1027);
            this.scrDataGridView1.TabIndex = 1;
            // 
            // 全部ToolStripMenuItem
            // 
            this.全部ToolStripMenuItem.Name = "全部ToolStripMenuItem";
            this.全部ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.全部ToolStripMenuItem.Text = "全部";
            this.全部ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem_Click);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scrDataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ProgressForm";
            this.Size = new System.Drawing.Size(1924, 1055);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 未订货ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 未入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 未出库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 已出库ToolStripMenuItem;
        private ScrDataGridView scrDataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 全部ToolStripMenuItem;
    }
}
