﻿namespace ERPTools.UserForm
{
    partial class DataShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataShow));
            this.scrDataGridView1 = new ERPTools.UserForm.ScrDataGridView();
            this.SuspendLayout();
            // 
            // scrDataGridView1
            // 
            this.scrDataGridView1.DataSource = null;
            this.scrDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.scrDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scrDataGridView1.Name = "scrDataGridView1";
            this.scrDataGridView1.Size = new System.Drawing.Size(800, 450);
            this.scrDataGridView1.TabIndex = 0;
            // 
            // DataShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scrDataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DataShow";
            this.Text = "DataShow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private ScrDataGridView scrDataGridView1;
    }
}