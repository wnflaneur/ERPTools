namespace ERPTools.UserForm
{
    partial class MaterialCreatetForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.myDataGridView1 = new ERPTools.UserForm.MyDataGridViewSet();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.物料编码生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入execelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出execlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据默认设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据关联ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.合并ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1924, 1023);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1924, 1055);
            this.toolStripContainer1.TabIndex = 1;
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
            this.myDataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.myDataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.myDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.myDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.myDataGridView1.Size = new System.Drawing.Size(1924, 1023);
            this.myDataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.toolStripComboBox1,
            this.物料编码生成ToolStripMenuItem,
            this.导入execelToolStripMenuItem,
            this.导出execlToolStripMenuItem,
            this.数据默认设置ToolStripMenuItem,
            this.数据关联ToolStripMenuItem,
            this.保存格式ToolStripMenuItem,
            this.合并ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 32);
            this.menuStrip1.TabIndex = 1;
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
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // 物料编码生成ToolStripMenuItem
            // 
            this.物料编码生成ToolStripMenuItem.Name = "物料编码生成ToolStripMenuItem";
            this.物料编码生成ToolStripMenuItem.Size = new System.Drawing.Size(113, 28);
            this.物料编码生成ToolStripMenuItem.Text = "物料编码生成";
            this.物料编码生成ToolStripMenuItem.Click += new System.EventHandler(this.物料编码生成ToolStripMenuItem_Click);
            // 
            // 导入execelToolStripMenuItem
            // 
            this.导入execelToolStripMenuItem.Name = "导入execelToolStripMenuItem";
            this.导入execelToolStripMenuItem.Size = new System.Drawing.Size(100, 28);
            this.导入execelToolStripMenuItem.Text = "导入execel";
            this.导入execelToolStripMenuItem.Click += new System.EventHandler(this.导入execelToolStripMenuItem_Click);
            // 
            // 导出execlToolStripMenuItem
            // 
            this.导出execlToolStripMenuItem.Name = "导出execlToolStripMenuItem";
            this.导出execlToolStripMenuItem.Size = new System.Drawing.Size(91, 28);
            this.导出execlToolStripMenuItem.Text = "导出execl";
            this.导出execlToolStripMenuItem.Click += new System.EventHandler(this.导出execlToolStripMenuItem_Click);
            // 
            // 数据默认设置ToolStripMenuItem
            // 
            this.数据默认设置ToolStripMenuItem.Name = "数据默认设置ToolStripMenuItem";
            this.数据默认设置ToolStripMenuItem.Size = new System.Drawing.Size(113, 28);
            this.数据默认设置ToolStripMenuItem.Text = "数据默认设置";
            this.数据默认设置ToolStripMenuItem.Click += new System.EventHandler(this.数据默认设置ToolStripMenuItem_Click);
            // 
            // 数据关联ToolStripMenuItem
            // 
            this.数据关联ToolStripMenuItem.Name = "数据关联ToolStripMenuItem";
            this.数据关联ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.数据关联ToolStripMenuItem.Text = "数据关联";
            this.数据关联ToolStripMenuItem.Click += new System.EventHandler(this.数据关联ToolStripMenuItem_Click);
            // 
            // 保存格式ToolStripMenuItem
            // 
            this.保存格式ToolStripMenuItem.Name = "保存格式ToolStripMenuItem";
            this.保存格式ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.保存格式ToolStripMenuItem.Text = "保存格式";
            this.保存格式ToolStripMenuItem.Click += new System.EventHandler(this.保存格式ToolStripMenuItem_Click);
            // 
            // 合并ToolStripMenuItem
            // 
            this.合并ToolStripMenuItem.Name = "合并ToolStripMenuItem";
            this.合并ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.合并ToolStripMenuItem.Text = "合并";
            this.合并ToolStripMenuItem.Click += new System.EventHandler(this.合并ToolStripMenuItem_Click);
            // 
            // MaterialCreatetForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.Name = "MaterialCreatetForm";
            this.Size = new System.Drawing.Size(1924, 1055);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MaterialCreatetForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MaterialCreatetForm_DragEnter);
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
        private System.Windows.Forms.ToolStripMenuItem 导入execelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据关联ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据默认设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem 导出execlToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MyDataGridViewSet myDataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 物料编码生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 合并ToolStripMenuItem;
    }
}
