namespace ERPTools.UserForm
{
    partial class MachineNumberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineNumberForm));
            this.projectNumber_Text = new System.Windows.Forms.TextBox();
            this.ok_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // projectNumber_Text
            // 
            this.projectNumber_Text.Location = new System.Drawing.Point(113, 33);
            this.projectNumber_Text.Name = "projectNumber_Text";
            this.projectNumber_Text.Size = new System.Drawing.Size(237, 25);
            this.projectNumber_Text.TabIndex = 0;
            // 
            // ok_Btn
            // 
            this.ok_Btn.Location = new System.Drawing.Point(28, 93);
            this.ok_Btn.Name = "ok_Btn";
            this.ok_Btn.Size = new System.Drawing.Size(322, 42);
            this.ok_Btn.TabIndex = 1;
            this.ok_Btn.Text = "确定";
            this.ok_Btn.UseVisualStyleBackColor = true;
            this.ok_Btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "项目编号";
            // 
            // MachineNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 156);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ok_Btn);
            this.Controls.Add(this.projectNumber_Text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MachineNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "项目流水";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox projectNumber_Text;
        private System.Windows.Forms.Button ok_Btn;
        private System.Windows.Forms.Label label1;
    }
}