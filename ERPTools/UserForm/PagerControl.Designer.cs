namespace ERPTools.UserForm
{
    partial class PagerControl
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPageSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lnkFirst = new System.Windows.Forms.LinkLabel();
            this.lnkPrev = new System.Windows.Forms.LinkLabel();
            this.lnkNext = new System.Windows.Forms.LinkLabel();
            this.lnkLast = new System.Windows.Forms.LinkLabel();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblCurrentPage);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.lblPageCount);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalCount);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.txtPageSize);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.lnkFirst);
            this.flowLayoutPanel1.Controls.Add(this.lnkPrev);
            this.flowLayoutPanel1.Controls.Add(this.lnkNext);
            this.flowLayoutPanel1.Controls.Add(this.lnkLast);
            this.flowLayoutPanel1.Controls.Add(this.txtPageNum);
            this.flowLayoutPanel1.Controls.Add(this.btnGo);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(765, 34);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentPage.Location = new System.Drawing.Point(3, 0);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(15, 29);
            this.lblCurrentPage.TabIndex = 0;
            this.lblCurrentPage.Text = "1";
            this.lblCurrentPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(24, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "/";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPageCount.Location = new System.Drawing.Point(45, 0);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(15, 29);
            this.lblPageCount.TabIndex = 4;
            this.lblPageCount.Text = "1";
            this.lblPageCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(66, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "共";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCount.Location = new System.Drawing.Point(94, 0);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(15, 29);
            this.lblTotalCount.TabIndex = 8;
            this.lblTotalCount.Text = "1";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(115, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "条记录";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(173, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 29);
            this.label7.TabIndex = 12;
            this.label7.Text = "每页";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPageSize
            // 
            this.txtPageSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPageSize.Location = new System.Drawing.Point(216, 3);
            this.txtPageSize.Name = "txtPageSize";
            this.txtPageSize.Size = new System.Drawing.Size(100, 25);
            this.txtPageSize.TabIndex = 13;
            this.txtPageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPageSize.TextChanged += new System.EventHandler(this.txtPageSize_TextChanged);
            this.txtPageSize.Leave += new System.EventHandler(this.txtPageSize_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(322, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 29);
            this.label8.TabIndex = 15;
            this.label8.Text = "条";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkFirst
            // 
            this.lnkFirst.AutoSize = true;
            this.lnkFirst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkFirst.Location = new System.Drawing.Point(350, 0);
            this.lnkFirst.Name = "lnkFirst";
            this.lnkFirst.Size = new System.Drawing.Size(37, 29);
            this.lnkFirst.TabIndex = 16;
            this.lnkFirst.TabStop = true;
            this.lnkFirst.Text = "首页";
            this.lnkFirst.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkFirst.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkFirst_LinkClicked);
            // 
            // lnkPrev
            // 
            this.lnkPrev.AutoSize = true;
            this.lnkPrev.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkPrev.Location = new System.Drawing.Point(393, 0);
            this.lnkPrev.Name = "lnkPrev";
            this.lnkPrev.Size = new System.Drawing.Size(52, 29);
            this.lnkPrev.TabIndex = 17;
            this.lnkPrev.TabStop = true;
            this.lnkPrev.Text = "上一页";
            this.lnkPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkPrev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPrev_LinkClicked);
            // 
            // lnkNext
            // 
            this.lnkNext.AutoSize = true;
            this.lnkNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkNext.Location = new System.Drawing.Point(451, 0);
            this.lnkNext.Name = "lnkNext";
            this.lnkNext.Size = new System.Drawing.Size(52, 29);
            this.lnkNext.TabIndex = 19;
            this.lnkNext.TabStop = true;
            this.lnkNext.Text = "下一页";
            this.lnkNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkNext_LinkClicked);
            // 
            // lnkLast
            // 
            this.lnkLast.AutoSize = true;
            this.lnkLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkLast.Location = new System.Drawing.Point(509, 0);
            this.lnkLast.Name = "lnkLast";
            this.lnkLast.Size = new System.Drawing.Size(37, 29);
            this.lnkLast.TabIndex = 21;
            this.lnkLast.TabStop = true;
            this.lnkLast.Text = "尾页";
            this.lnkLast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkLast.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLast_LinkClicked);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPageNum.Location = new System.Drawing.Point(552, 3);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(100, 25);
            this.txtPageNum.TabIndex = 22;
            this.txtPageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPageNum.TextChanged += new System.EventHandler(this.txtPageNum_TextChanged);
            this.txtPageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNum_KeyPress);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(658, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 23;
            this.btnGo.Text = "跳转";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // PagerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "PagerControl";
            this.Size = new System.Drawing.Size(765, 34);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPageSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lnkFirst;
        private System.Windows.Forms.LinkLabel lnkPrev;
        private System.Windows.Forms.LinkLabel lnkNext;
        private System.Windows.Forms.LinkLabel lnkLast;
        private System.Windows.Forms.TextBox txtPageNum;
        private System.Windows.Forms.Button btnGo;
    }
}
