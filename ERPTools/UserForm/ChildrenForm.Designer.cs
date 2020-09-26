namespace ERPTools.UserForm
{
    partial class ChildrenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildrenForm));
            this.scrDataGridView1 = new ScrDataGridView();
            this.SuspendLayout();
            // 
            // scrDataGridView1
            // 
            this.scrDataGridView1.DataSource = null;
            this.scrDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.scrDataGridView1.Name = "scrDataGridView1";
            this.scrDataGridView1.Size = new System.Drawing.Size(1924, 1055);
            this.scrDataGridView1.TabIndex = 3;
            // 
            // ChildrenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.scrDataGridView1);
            this.DoubleBuffered = true;
            this.Name = "ChildrenForm";
            this.Text = "ChildrenForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ScrDataGridView scrDataGridView1;
    }
}
