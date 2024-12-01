namespace QLVPP_Project
{
    partial class UserControl_BodyQLSP
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
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonSua = new System.Windows.Forms.Button();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.labelTenOrMa = new System.Windows.Forms.Label();
            this.buttonTim = new System.Windows.Forms.Button();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewQLSP = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLSP)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonThem
            // 
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonThem.ForeColor = System.Drawing.Color.Maroon;
            this.buttonThem.Location = new System.Drawing.Point(346, 64);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(138, 61);
            this.buttonThem.TabIndex = 0;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonSua
            // 
            this.buttonSua.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonSua.ForeColor = System.Drawing.Color.Maroon;
            this.buttonSua.Location = new System.Drawing.Point(597, 64);
            this.buttonSua.Name = "buttonSua";
            this.buttonSua.Size = new System.Drawing.Size(138, 61);
            this.buttonSua.TabIndex = 1;
            this.buttonSua.Text = "Sửa";
            this.buttonSua.UseVisualStyleBackColor = true;
            this.buttonSua.Click += new System.EventHandler(this.buttonSua_Click);
            // 
            // buttonXoa
            // 
            this.buttonXoa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonXoa.ForeColor = System.Drawing.Color.Maroon;
            this.buttonXoa.Location = new System.Drawing.Point(850, 64);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(138, 61);
            this.buttonXoa.TabIndex = 2;
            this.buttonXoa.Text = "Xóa";
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // labelTenOrMa
            // 
            this.labelTenOrMa.AutoSize = true;
            this.labelTenOrMa.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenOrMa.Location = new System.Drawing.Point(422, 186);
            this.labelTenOrMa.Name = "labelTenOrMa";
            this.labelTenOrMa.Size = new System.Drawing.Size(423, 38);
            this.labelTenOrMa.TabIndex = 3;
            this.labelTenOrMa.Text = "Tên Sản Phẩm  |  Mã Sản Phẩm";
            // 
            // buttonTim
            // 
            this.buttonTim.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonTim.ForeColor = System.Drawing.Color.Maroon;
            this.buttonTim.Location = new System.Drawing.Point(1027, 249);
            this.buttonTim.Name = "buttonTim";
            this.buttonTim.Size = new System.Drawing.Size(138, 61);
            this.buttonTim.TabIndex = 4;
            this.buttonTim.Text = "Tìm";
            this.buttonTim.UseVisualStyleBackColor = true;
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Location = new System.Drawing.Point(346, 249);
            this.textBoxTimKiem.Multiline = true;
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(642, 61);
            this.textBoxTimKiem.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(165, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tìm Kiếm:";
            // 
            // dataGridViewQLSP
            // 
            this.dataGridViewQLSP.AllowUserToAddRows = false;
            this.dataGridViewQLSP.AllowUserToDeleteRows = false;
            this.dataGridViewQLSP.AllowUserToResizeColumns = false;
            this.dataGridViewQLSP.AllowUserToResizeRows = false;
            this.dataGridViewQLSP.ColumnHeadersHeight = 29;
            this.dataGridViewQLSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewQLSP.Location = new System.Drawing.Point(172, 360);
            this.dataGridViewQLSP.Name = "dataGridViewQLSP";
            this.dataGridViewQLSP.ReadOnly = true;
            this.dataGridViewQLSP.RowHeadersWidth = 51;
            this.dataGridViewQLSP.RowTemplate.Height = 24;
            this.dataGridViewQLSP.Size = new System.Drawing.Size(993, 571);
            this.dataGridViewQLSP.TabIndex = 7;
            // 
            // UserControl_BodyQLSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridViewQLSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTimKiem);
            this.Controls.Add(this.buttonTim);
            this.Controls.Add(this.labelTenOrMa);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.buttonThem);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Name = "UserControl_BodyQLSP";
            this.Size = new System.Drawing.Size(1300, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Label labelTenOrMa;
        private System.Windows.Forms.Button buttonTim;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewQLSP;
    }
}
