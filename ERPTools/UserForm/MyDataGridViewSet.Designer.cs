namespace ERPTools.UserForm
{
    partial class MyDataGridViewSet
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加一行ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空所选内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空整列toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空整行toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加一行ToolStripMenuItem,
            this.删除ToolStripMenuItem1,
            this.清空所选内容ToolStripMenuItem,
            this.清空整列toolStripMenuItem,
            this.清空整行toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 124);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // 添加一行ToolStripMenuItem
            // 
            this.添加一行ToolStripMenuItem.Name = "添加一行ToolStripMenuItem";
            this.添加一行ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.添加一行ToolStripMenuItem.Text = "插入一行";
            // 
            // 删除ToolStripMenuItem1
            // 
            this.删除ToolStripMenuItem1.Name = "删除ToolStripMenuItem1";
            this.删除ToolStripMenuItem1.Size = new System.Drawing.Size(168, 24);
            this.删除ToolStripMenuItem1.Text = "删除所选行";
            // 
            // 清空所选内容ToolStripMenuItem
            // 
            this.清空所选内容ToolStripMenuItem.Name = "清空所选内容ToolStripMenuItem";
            this.清空所选内容ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.清空所选内容ToolStripMenuItem.Text = "清空所选内容";
            // 
            // 清空整列toolStripMenuItem
            // 
            this.清空整列toolStripMenuItem.Name = "清空整列toolStripMenuItem";
            this.清空整列toolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.清空整列toolStripMenuItem.Text = "清空整列";
            // 
            // 清空整行toolStripMenuItem1
            // 
            this.清空整行toolStripMenuItem1.Name = "清空整行toolStripMenuItem1";
            this.清空整行toolStripMenuItem1.Size = new System.Drawing.Size(168, 24);
            this.清空整行toolStripMenuItem1.Text = "清空整行";
            // 
            // MyDataGridViewSet
            // 
            this.AllowUserToOrderColumns = true;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ColumnHeadersHeight = 18;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowTemplate.Height = 27;
            this.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.MyDataGridView_CellParsing);
            this.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.MyDataGridView_RowPostPaint);
            this.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.MyDataGridView_UserAddedRow);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyDataGridView_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加一行ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空所选内容ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空整列toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空整行toolStripMenuItem1;
    }
}
