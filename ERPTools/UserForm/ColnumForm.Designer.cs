namespace ERPTools.UserForm
{

    partial class ColnumForm
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
            this.colName_Label = new System.Windows.Forms.Label();
            this.colValue_comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // colName_Label
            // 
            this.colName_Label.AutoSize = true;
            this.colName_Label.Location = new System.Drawing.Point(14, 15);
            this.colName_Label.Name = "colName_Label";
            this.colName_Label.Size = new System.Drawing.Size(63, 15);
            this.colName_Label.TabIndex = 0;
            this.colName_Label.Text = "colName";
            // 
            // colValue_comboBox
            // 
            this.colValue_comboBox.FormattingEnabled = true;
            this.colValue_comboBox.Location = new System.Drawing.Point(132, 12);
            this.colValue_comboBox.Name = "colValue_comboBox";
            this.colValue_comboBox.Size = new System.Drawing.Size(170, 23);
            this.colValue_comboBox.TabIndex = 1;
            // 
            // ColnumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colValue_comboBox);
            this.Controls.Add(this.colName_Label);
            this.Name = "ColnumForm";
            this.Size = new System.Drawing.Size(340, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label colName_Label;
        private System.Windows.Forms.ComboBox colValue_comboBox;
    }
}
