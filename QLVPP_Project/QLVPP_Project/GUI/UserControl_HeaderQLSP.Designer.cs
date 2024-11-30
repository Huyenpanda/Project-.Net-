namespace QLVPP_Project
{
    partial class UserControl_HeaderQLSP
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelQLSP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQLSP
            // 
            this.labelQLSP.AutoSize = true;
            this.labelQLSP.BackColor = System.Drawing.Color.Maroon;
            this.labelQLSP.Font = new System.Drawing.Font("Book Antiqua", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQLSP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.labelQLSP.Location = new System.Drawing.Point(404, 55);
            this.labelQLSP.Name = "labelQLSP";
            this.labelQLSP.Size = new System.Drawing.Size(336, 46);
            this.labelQLSP.TabIndex = 0;
            this.labelQLSP.Text = "Quản lý Sản Phẩm";
            // 
            // UserControl_HeaderQLSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.Controls.Add(this.labelQLSP);
            this.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UserControl_HeaderQLSP";
            this.Size = new System.Drawing.Size(1100, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQLSP;
    }
}
