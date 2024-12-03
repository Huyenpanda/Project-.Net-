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
            this.buttonTimKiem = new System.Windows.Forms.Button();
            this.textBoxTenSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewQLSP = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxGiaTu = new System.Windows.Forms.TextBox();
            this.textBoxGiaDen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonTheoTen = new System.Windows.Forms.RadioButton();
            this.radioButtonTheoMa = new System.Windows.Forms.RadioButton();
            this.radioButtonTheoGia = new System.Windows.Forms.RadioButton();
            this.radioButtonLoc = new System.Windows.Forms.RadioButton();
            this.radioButtonTatCa = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLSP)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonThem
            // 
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonThem.ForeColor = System.Drawing.Color.Maroon;
            this.buttonThem.Location = new System.Drawing.Point(163, 80);
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
            this.buttonSua.Location = new System.Drawing.Point(163, 173);
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
            this.buttonXoa.Location = new System.Drawing.Point(163, 264);
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
            this.labelTenOrMa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTenOrMa.Location = new System.Drawing.Point(324, 80);
            this.labelTenOrMa.Name = "labelTenOrMa";
            this.labelTenOrMa.Size = new System.Drawing.Size(175, 31);
            this.labelTenOrMa.TabIndex = 3;
            this.labelTenOrMa.Text = "Tên Sản Phẩm :";
            // 
            // buttonTimKiem
            // 
            this.buttonTimKiem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonTimKiem.ForeColor = System.Drawing.Color.Maroon;
            this.buttonTimKiem.Location = new System.Drawing.Point(977, 189);
            this.buttonTimKiem.Name = "buttonTimKiem";
            this.buttonTimKiem.Size = new System.Drawing.Size(179, 61);
            this.buttonTimKiem.TabIndex = 4;
            this.buttonTimKiem.Text = "Tìm kiếm";
            this.buttonTimKiem.UseVisualStyleBackColor = true;
            this.buttonTimKiem.Click += new System.EventHandler(this.buttonTim_Click);
            // 
            // textBoxTenSP
            // 
            this.textBoxTenSP.Location = new System.Drawing.Point(524, 75);
            this.textBoxTenSP.Multiline = true;
            this.textBoxTenSP.Name = "textBoxTenSP";
            this.textBoxTenSP.Size = new System.Drawing.Size(416, 36);
            this.textBoxTenSP.TabIndex = 5;
            this.textBoxTenSP.TextChanged += new System.EventHandler(this.textBoxTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(569, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 41);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tìm Kiếm Sản Phẩm";
            // 
            // dataGridViewQLSP
            // 
            this.dataGridViewQLSP.AllowUserToAddRows = false;
            this.dataGridViewQLSP.AllowUserToDeleteRows = false;
            this.dataGridViewQLSP.AllowUserToResizeColumns = false;
            this.dataGridViewQLSP.AllowUserToResizeRows = false;
            this.dataGridViewQLSP.ColumnHeadersHeight = 29;
            this.dataGridViewQLSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewQLSP.Location = new System.Drawing.Point(163, 363);
            this.dataGridViewQLSP.Name = "dataGridViewQLSP";
            this.dataGridViewQLSP.ReadOnly = true;
            this.dataGridViewQLSP.RowHeadersWidth = 51;
            this.dataGridViewQLSP.RowTemplate.Height = 24;
            this.dataGridViewQLSP.Size = new System.Drawing.Size(993, 571);
            this.dataGridViewQLSP.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(414, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Giá từ:";
            // 
            // textBoxGiaTu
            // 
            this.textBoxGiaTu.Location = new System.Drawing.Point(524, 213);
            this.textBoxGiaTu.Multiline = true;
            this.textBoxGiaTu.Name = "textBoxGiaTu";
            this.textBoxGiaTu.Size = new System.Drawing.Size(126, 36);
            this.textBoxGiaTu.TabIndex = 10;
            // 
            // textBoxGiaDen
            // 
            this.textBoxGiaDen.Location = new System.Drawing.Point(814, 213);
            this.textBoxGiaDen.Multiline = true;
            this.textBoxGiaDen.Name = "textBoxGiaDen";
            this.textBoxGiaDen.Size = new System.Drawing.Size(126, 36);
            this.textBoxGiaDen.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(674, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 31);
            this.label3.TabIndex = 11;
            this.label3.Text = "Giá đến:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxMaSP
            // 
            this.textBoxMaSP.Location = new System.Drawing.Point(524, 149);
            this.textBoxMaSP.Multiline = true;
            this.textBoxMaSP.Name = "textBoxMaSP";
            this.textBoxMaSP.Size = new System.Drawing.Size(416, 36);
            this.textBoxMaSP.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(333, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 31);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mã Sản Phẩm:";
            // 
            // radioButtonTheoTen
            // 
            this.radioButtonTheoTen.AutoSize = true;
            this.radioButtonTheoTen.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.radioButtonTheoTen.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonTheoTen.Location = new System.Drawing.Point(472, 284);
            this.radioButtonTheoTen.Name = "radioButtonTheoTen";
            this.radioButtonTheoTen.Size = new System.Drawing.Size(131, 35);
            this.radioButtonTheoTen.TabIndex = 15;
            this.radioButtonTheoTen.TabStop = true;
            this.radioButtonTheoTen.Text = "Theo Tên";
            this.radioButtonTheoTen.UseVisualStyleBackColor = true;
            // 
            // radioButtonTheoMa
            // 
            this.radioButtonTheoMa.AutoSize = true;
            this.radioButtonTheoMa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.radioButtonTheoMa.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonTheoMa.Location = new System.Drawing.Point(648, 284);
            this.radioButtonTheoMa.Name = "radioButtonTheoMa";
            this.radioButtonTheoMa.Size = new System.Drawing.Size(128, 35);
            this.radioButtonTheoMa.TabIndex = 16;
            this.radioButtonTheoMa.TabStop = true;
            this.radioButtonTheoMa.Text = "Theo Mã";
            this.radioButtonTheoMa.UseVisualStyleBackColor = true;
            // 
            // radioButtonTheoGia
            // 
            this.radioButtonTheoGia.AutoSize = true;
            this.radioButtonTheoGia.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.radioButtonTheoGia.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonTheoGia.Location = new System.Drawing.Point(814, 284);
            this.radioButtonTheoGia.Name = "radioButtonTheoGia";
            this.radioButtonTheoGia.Size = new System.Drawing.Size(129, 35);
            this.radioButtonTheoGia.TabIndex = 17;
            this.radioButtonTheoGia.TabStop = true;
            this.radioButtonTheoGia.Text = "Theo Giá";
            this.radioButtonTheoGia.UseVisualStyleBackColor = true;
            // 
            // radioButtonLoc
            // 
            this.radioButtonLoc.AutoSize = true;
            this.radioButtonLoc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.radioButtonLoc.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonLoc.Location = new System.Drawing.Point(339, 284);
            this.radioButtonLoc.Name = "radioButtonLoc";
            this.radioButtonLoc.Size = new System.Drawing.Size(72, 35);
            this.radioButtonLoc.TabIndex = 18;
            this.radioButtonLoc.TabStop = true;
            this.radioButtonLoc.Text = "Lọc";
            this.radioButtonLoc.UseVisualStyleBackColor = true;
            // 
            // radioButtonTatCa
            // 
            this.radioButtonTatCa.AutoSize = true;
            this.radioButtonTatCa.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.radioButtonTatCa.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonTatCa.Location = new System.Drawing.Point(1006, 284);
            this.radioButtonTatCa.Name = "radioButtonTatCa";
            this.radioButtonTatCa.Size = new System.Drawing.Size(98, 35);
            this.radioButtonTatCa.TabIndex = 19;
            this.radioButtonTatCa.TabStop = true;
            this.radioButtonTatCa.Text = "Tất cả";
            this.radioButtonTatCa.UseVisualStyleBackColor = true;
            // 
            // UserControl_BodyQLSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.radioButtonTatCa);
            this.Controls.Add(this.radioButtonLoc);
            this.Controls.Add(this.radioButtonTheoGia);
            this.Controls.Add(this.radioButtonTheoMa);
            this.Controls.Add(this.radioButtonTheoTen);
            this.Controls.Add(this.textBoxMaSP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxGiaDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxGiaTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewQLSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTenSP);
            this.Controls.Add(this.buttonTimKiem);
            this.Controls.Add(this.labelTenOrMa);
            this.Controls.Add(this.buttonXoa);
            this.Controls.Add(this.buttonSua);
            this.Controls.Add(this.buttonThem);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Name = "UserControl_BodyQLSP";
            this.Size = new System.Drawing.Size(1300, 1000);
            this.Load += new System.EventHandler(this.UserControl_BodyQLSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQLSP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.Button buttonSua;
        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Label labelTenOrMa;
        private System.Windows.Forms.Button buttonTimKiem;
        private System.Windows.Forms.TextBox textBoxTenSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewQLSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxGiaTu;
        private System.Windows.Forms.TextBox textBoxGiaDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonTheoTen;
        private System.Windows.Forms.RadioButton radioButtonTheoMa;
        private System.Windows.Forms.RadioButton radioButtonTheoGia;
        private System.Windows.Forms.RadioButton radioButtonLoc;
        private System.Windows.Forms.RadioButton radioButtonTatCa;
    }
}
