namespace ERPTools.UserForm
{
    partial class BomForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.myDataGridView1 = new ERPTools.UserForm.MyDataGridViewSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出excelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox2 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.确定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.精准匹配ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规格图号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.名称和规格图号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.去除特殊字符匹配ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据匹配ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找最新版ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据关联ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据合并配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.公式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.myDataGridView1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1924, 921);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1924, 953);
            this.toolStripContainer1.TabIndex = 5;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // myDataGridView1
            // 
            this.myDataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.myDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.myDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.myDataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.myDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.myDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.myDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.myDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView1.EnableHeadersVisualStyles = false;
            this.myDataGridView1.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.myDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.myDataGridView1.Name = "myDataGridView1";
            this.myDataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.myDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.myDataGridView1.RowTemplate.Height = 27;
            this.myDataGridView1.Size = new System.Drawing.Size(1924, 921);
            this.myDataGridView1.TabIndex = 0;
            this.myDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellDoubleClick);
            this.myDataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.myDataGridView1_CellValueChanged);
            this.myDataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.myDataGridView1_EditingControlShowing);
            this.myDataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myDataGridView1_KeyDown);
            this.myDataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.myDataGridView1_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.导入ToolStripMenuItem,
            this.导出excelToolStripMenuItem,
            this.toolStripComboBox2,
            this.toolStripComboBox1,
            this.toolStripTextBox1,
            this.确定ToolStripMenuItem,
            this.精准匹配ToolStripMenuItem,
            this.数据匹配ToolStripMenuItem,
            this.保存格式ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(1924, 32);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.保存ToolStripMenuItem.Text = "保存";
            this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // 导入ToolStripMenuItem
            // 
            this.导入ToolStripMenuItem.Name = "导入ToolStripMenuItem";
            this.导入ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.导入ToolStripMenuItem.Text = "导入";
            this.导入ToolStripMenuItem.Click += new System.EventHandler(this.导入ToolStripMenuItem_Click);
            // 
            // 导出excelToolStripMenuItem
            // 
            this.导出excelToolStripMenuItem.Name = "导出excelToolStripMenuItem";
            this.导出excelToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.导出excelToolStripMenuItem.Text = "导出";
            this.导出excelToolStripMenuItem.Click += new System.EventHandler(this.导出excelToolStripMenuItem_Click);
            // 
            // toolStripComboBox2
            // 
            this.toolStripComboBox2.Name = "toolStripComboBox2";
            this.toolStripComboBox2.Size = new System.Drawing.Size(121, 28);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "包含关系查询",
            "精确查询",
            "相似度模糊查询"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.Sorted = true;
            this.toolStripComboBox1.Tag = "";
            this.toolStripComboBox1.Text = "包含关系查询";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(200, 28);
            // 
            // 确定ToolStripMenuItem
            // 
            this.确定ToolStripMenuItem.Name = "确定ToolStripMenuItem";
            this.确定ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.确定ToolStripMenuItem.Text = "确定";
            this.确定ToolStripMenuItem.Click += new System.EventHandler(this.确定ToolStripMenuItem_Click);
            // 
            // 精准匹配ToolStripMenuItem
            // 
            this.精准匹配ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.名称ToolStripMenuItem,
            this.规格图号ToolStripMenuItem,
            this.名称和规格图号ToolStripMenuItem,
            this.去除特殊字符匹配ToolStripMenuItem});
            this.精准匹配ToolStripMenuItem.Name = "精准匹配ToolStripMenuItem";
            this.精准匹配ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.精准匹配ToolStripMenuItem.Text = "精准匹配";
            // 
            // 名称ToolStripMenuItem
            // 
            this.名称ToolStripMenuItem.Name = "名称ToolStripMenuItem";
            this.名称ToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.名称ToolStripMenuItem.Text = "名称";
            this.名称ToolStripMenuItem.Click += new System.EventHandler(this.名称ToolStripMenuItem_Click);
            // 
            // 规格图号ToolStripMenuItem
            // 
            this.规格图号ToolStripMenuItem.Name = "规格图号ToolStripMenuItem";
            this.规格图号ToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.规格图号ToolStripMenuItem.Text = "规格/图号";
            this.规格图号ToolStripMenuItem.Click += new System.EventHandler(this.规格图号ToolStripMenuItem_Click);
            // 
            // 名称和规格图号ToolStripMenuItem
            // 
            this.名称和规格图号ToolStripMenuItem.Name = "名称和规格图号ToolStripMenuItem";
            this.名称和规格图号ToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.名称和规格图号ToolStripMenuItem.Text = "名称和规格/图号";
            this.名称和规格图号ToolStripMenuItem.Click += new System.EventHandler(this.名称和规格图号ToolStripMenuItem_Click);
            // 
            // 去除特殊字符匹配ToolStripMenuItem
            // 
            this.去除特殊字符匹配ToolStripMenuItem.Name = "去除特殊字符匹配ToolStripMenuItem";
            this.去除特殊字符匹配ToolStripMenuItem.Size = new System.Drawing.Size(282, 26);
            this.去除特殊字符匹配ToolStripMenuItem.Text = "去除特殊字符匹配(规格图号)";
            this.去除特殊字符匹配ToolStripMenuItem.Click += new System.EventHandler(this.去除特殊字符匹配ToolStripMenuItem_Click);
            // 
            // 数据匹配ToolStripMenuItem
            // 
            this.数据匹配ToolStripMenuItem.Name = "数据匹配ToolStripMenuItem";
            this.数据匹配ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.数据匹配ToolStripMenuItem.Text = "数据匹配";
            this.数据匹配ToolStripMenuItem.Click += new System.EventHandler(this.数据匹配ToolStripMenuItem_Click);
            // 
            // 保存格式ToolStripMenuItem
            // 
            this.保存格式ToolStripMenuItem.Name = "保存格式ToolStripMenuItem";
            this.保存格式ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.保存格式ToolStripMenuItem.Text = "保存格式";
            this.保存格式ToolStripMenuItem.Click += new System.EventHandler(this.保存格式ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查找最新版ToolStripMenuItem,
            this.配置ToolStripMenuItem,
            this.公式ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 查找最新版ToolStripMenuItem
            // 
            this.查找最新版ToolStripMenuItem.Name = "查找最新版ToolStripMenuItem";
            this.查找最新版ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.查找最新版ToolStripMenuItem.Text = "版本信息";
            this.查找最新版ToolStripMenuItem.Click += new System.EventHandler(this.查找最新版ToolStripMenuItem_Click);
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据关联ToolStripMenuItem,
            this.数据合并配置ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 数据关联ToolStripMenuItem
            // 
            this.数据关联ToolStripMenuItem.Name = "数据关联ToolStripMenuItem";
            this.数据关联ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.数据关联ToolStripMenuItem.Text = "数据关联";
            this.数据关联ToolStripMenuItem.Click += new System.EventHandler(this.数据关联ToolStripMenuItem_Click_1);
            // 
            // 数据合并配置ToolStripMenuItem
            // 
            this.数据合并配置ToolStripMenuItem.Name = "数据合并配置ToolStripMenuItem";
            this.数据合并配置ToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.数据合并配置ToolStripMenuItem.Text = "数据合并配置";
            this.数据合并配置ToolStripMenuItem.Click += new System.EventHandler(this.数据合并配置ToolStripMenuItem_Click);
            // 
            // 公式ToolStripMenuItem
            // 
            this.公式ToolStripMenuItem.Name = "公式ToolStripMenuItem";
            this.公式ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.公式ToolStripMenuItem.Text = "公式";
            this.公式ToolStripMenuItem.Click += new System.EventHandler(this.公式ToolStripMenuItem_Click);
            // 
            // BomForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Name = "BomForm";
            this.Size = new System.Drawing.Size(1924, 953);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.BomForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.BomForm_DragEnter);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox2;
        private System.Windows.Forms.ToolStripMenuItem 确定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出excelToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查找最新版ToolStripMenuItem;
        private MyDataGridViewSet myDataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 导入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据匹配ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据关联ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据合并配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 公式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 精准匹配ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 规格图号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 名称和规格图号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 去除特殊字符匹配ToolStripMenuItem;
    }
}
