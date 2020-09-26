namespace ERPTools.UserForm
{
    partial class DataForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.myDataGridView2 = new ERPTools.UserForm.MyDataGridViewRead();
            this.scrDataGridView1 = new ERPTools.UserForm.ScrDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.myDataGridView2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.scrDataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.67862F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.32138F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1924, 753);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // myDataGridView2
            // 
            this.myDataGridView2.AllowUserToAddRows = false;
            this.myDataGridView2.AllowUserToDeleteRows = false;
            this.myDataGridView2.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.myDataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.myDataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.myDataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.myDataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.myDataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.myDataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(223)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.myDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.myDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.myDataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            this.myDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataGridView2.EnableHeadersVisualStyles = false;
            this.myDataGridView2.GridColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.myDataGridView2.Location = new System.Drawing.Point(3, 3);
            this.myDataGridView2.Name = "myDataGridView2";
            this.myDataGridView2.ReadOnly = true;
            this.myDataGridView2.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.myDataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.myDataGridView2.RowTemplate.Height = 27;
            this.myDataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.myDataGridView2.Size = new System.Drawing.Size(1918, 97);
            this.myDataGridView2.TabIndex = 3;
            // 
            // scrDataGridView1
            // 
            this.scrDataGridView1.DataSource = null;
            this.scrDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrDataGridView1.Location = new System.Drawing.Point(3, 106);
            this.scrDataGridView1.Name = "scrDataGridView1";
            this.scrDataGridView1.Size = new System.Drawing.Size(1918, 644);
            this.scrDataGridView1.TabIndex = 6;
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataForm";
            this.Text = "物料库查询";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DataForm_FormClosed);
            this.Load += new System.EventHandler(this.DataForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myDataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MyDataGridViewRead myDataGridView2;
        private ScrDataGridView scrDataGridView1;
    }
}