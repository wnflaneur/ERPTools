namespace ERPTools
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bOMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.进度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生产ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.库存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.物料档案ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库校验ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.默认界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bOMToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.物料ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.进度ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.库存ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.物料档案ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库校验ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Mainpanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sqlUpdateTime_Text = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.站点查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOMToolStripMenuItem,
            this.物料ToolStripMenuItem,
            this.进度ToolStripMenuItem,
            this.生产ToolStripMenuItem,
            this.库存ToolStripMenuItem,
            this.物料档案ToolStripMenuItem,
            this.数据库校验ToolStripMenuItem,
            this.数据库更新ToolStripMenuItem,
            this.默认界面ToolStripMenuItem,
            this.站点查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1167, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bOMToolStripMenuItem
            // 
            this.bOMToolStripMenuItem.Name = "bOMToolStripMenuItem";
            this.bOMToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.bOMToolStripMenuItem.Text = "BOM";
            this.bOMToolStripMenuItem.Click += new System.EventHandler(this.bOMToolStripMenuItem_Click);
            // 
            // 物料ToolStripMenuItem
            // 
            this.物料ToolStripMenuItem.Name = "物料ToolStripMenuItem";
            this.物料ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.物料ToolStripMenuItem.Text = "物料";
            this.物料ToolStripMenuItem.Click += new System.EventHandler(this.物料ToolStripMenuItem_Click);
            // 
            // 进度ToolStripMenuItem
            // 
            this.进度ToolStripMenuItem.Name = "进度ToolStripMenuItem";
            this.进度ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.进度ToolStripMenuItem.Text = "进度";
            this.进度ToolStripMenuItem.Click += new System.EventHandler(this.进度ToolStripMenuItem_Click);
            // 
            // 生产ToolStripMenuItem
            // 
            this.生产ToolStripMenuItem.Name = "生产ToolStripMenuItem";
            this.生产ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.生产ToolStripMenuItem.Text = "生产";
            this.生产ToolStripMenuItem.Click += new System.EventHandler(this.生产ToolStripMenuItem_Click);
            // 
            // 库存ToolStripMenuItem
            // 
            this.库存ToolStripMenuItem.Name = "库存ToolStripMenuItem";
            this.库存ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.库存ToolStripMenuItem.Text = "库存";
            this.库存ToolStripMenuItem.Click += new System.EventHandler(this.库存ToolStripMenuItem_Click);
            // 
            // 物料档案ToolStripMenuItem
            // 
            this.物料档案ToolStripMenuItem.Name = "物料档案ToolStripMenuItem";
            this.物料档案ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.物料档案ToolStripMenuItem.Text = "物料档案";
            this.物料档案ToolStripMenuItem.Click += new System.EventHandler(this.物料档案ToolStripMenuItem_Click);
            // 
            // 数据库校验ToolStripMenuItem
            // 
            this.数据库校验ToolStripMenuItem.Name = "数据库校验ToolStripMenuItem";
            this.数据库校验ToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.数据库校验ToolStripMenuItem.Text = "数据库校验";
            this.数据库校验ToolStripMenuItem.Click += new System.EventHandler(this.数据库自检ToolStripMenuItem_Click);
            // 
            // 数据库更新ToolStripMenuItem
            // 
            this.数据库更新ToolStripMenuItem.Name = "数据库更新ToolStripMenuItem";
            this.数据库更新ToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.数据库更新ToolStripMenuItem.Text = "数据库更新";
            this.数据库更新ToolStripMenuItem.Click += new System.EventHandler(this.本地数据库更新ToolStripMenuItem_Click);
            // 
            // 默认界面ToolStripMenuItem
            // 
            this.默认界面ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bOMToolStripMenuItem1,
            this.物料ToolStripMenuItem1,
            this.进度ToolStripMenuItem1,
            this.库存ToolStripMenuItem1,
            this.物料档案ToolStripMenuItem1,
            this.数据库校验ToolStripMenuItem1});
            this.默认界面ToolStripMenuItem.Name = "默认界面ToolStripMenuItem";
            this.默认界面ToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.默认界面ToolStripMenuItem.Text = "默认界面设置";
            // 
            // bOMToolStripMenuItem1
            // 
            this.bOMToolStripMenuItem1.Name = "bOMToolStripMenuItem1";
            this.bOMToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.bOMToolStripMenuItem1.Text = "BOM";
            this.bOMToolStripMenuItem1.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 物料ToolStripMenuItem1
            // 
            this.物料ToolStripMenuItem1.Name = "物料ToolStripMenuItem1";
            this.物料ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.物料ToolStripMenuItem1.Text = "物料";
            this.物料ToolStripMenuItem1.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 进度ToolStripMenuItem1
            // 
            this.进度ToolStripMenuItem1.Name = "进度ToolStripMenuItem1";
            this.进度ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.进度ToolStripMenuItem1.Text = "进度";
            this.进度ToolStripMenuItem1.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 库存ToolStripMenuItem1
            // 
            this.库存ToolStripMenuItem1.Name = "库存ToolStripMenuItem1";
            this.库存ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.库存ToolStripMenuItem1.Text = "库存";
            this.库存ToolStripMenuItem1.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 物料档案ToolStripMenuItem1
            // 
            this.物料档案ToolStripMenuItem1.Name = "物料档案ToolStripMenuItem1";
            this.物料档案ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.物料档案ToolStripMenuItem1.Text = "物料档案";
            this.物料档案ToolStripMenuItem1.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // 数据库校验ToolStripMenuItem1
            // 
            this.数据库校验ToolStripMenuItem1.Name = "数据库校验ToolStripMenuItem1";
            this.数据库校验ToolStripMenuItem1.Size = new System.Drawing.Size(167, 26);
            this.数据库校验ToolStripMenuItem1.Text = "数据库校验";
            this.数据库校验ToolStripMenuItem1.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // Mainpanel
            // 
            this.Mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mainpanel.Location = new System.Drawing.Point(0, 28);
            this.Mainpanel.Name = "Mainpanel";
            this.Mainpanel.Size = new System.Drawing.Size(1167, 728);
            this.Mainpanel.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sqlUpdateTime_Text,
            this.toolStripLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 734);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1167, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sqlUpdateTime_Text
            // 
            this.sqlUpdateTime_Text.Name = "sqlUpdateTime_Text";
            this.sqlUpdateTime_Text.Size = new System.Drawing.Size(0, 16);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // 站点查询ToolStripMenuItem
            // 
            this.站点查询ToolStripMenuItem.Name = "站点查询ToolStripMenuItem";
            this.站点查询ToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.站点查询ToolStripMenuItem.Text = "站点查询";
            this.站点查询ToolStripMenuItem.Click += new System.EventHandler(this.站点查询ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1167, 756);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Mainpanel);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bOMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 进度ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 库存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 物料档案ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库校验ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库更新ToolStripMenuItem;
        private System.Windows.Forms.Panel Mainpanel;
        private System.Windows.Forms.ToolStripMenuItem 默认界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bOMToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 物料ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 进度ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 库存ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 物料档案ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 数据库校验ToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sqlUpdateTime_Text;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripMenuItem 生产ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 站点查询ToolStripMenuItem;
    }
}

