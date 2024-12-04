namespace QLVPP_Project.GUI.Staff
{
    partial class FormCapNhatHoaDon
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSuaSP = new System.Windows.Forms.Button();
            this.buttonLuuHD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonXoaSP = new System.Windows.Forms.Button();
            this.dataGridViewProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewOrderDetail = new System.Windows.Forms.DataGridView();
            this.labelPaymentMethod = new System.Windows.Forms.Label();
            this.dateTimePickerCreateDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.comboBoxPaymentMethod = new System.Windows.Forms.ComboBox();
            this.textBoxAccountName = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelCreateDate = new System.Windows.Forms.Label();
            this.labelAccountName = new System.Windows.Forms.Label();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.buttonThemSP = new System.Windows.Forms.Button();
            this.labelThemSP = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.checkBoxStatus = new System.Windows.Forms.CheckBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.labelPhone = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textBoxEmail);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.textBoxPhone);
            this.panel1.Controls.Add(this.labelPhone);
            this.panel1.Controls.Add(this.checkBoxStatus);
            this.panel1.Controls.Add(this.labelStatus);
            this.panel1.Controls.Add(this.buttonSuaSP);
            this.panel1.Controls.Add(this.buttonLuuHD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonXoaSP);
            this.panel1.Controls.Add(this.dataGridViewProduct);
            this.panel1.Controls.Add(this.dataGridViewOrderDetail);
            this.panel1.Controls.Add(this.labelPaymentMethod);
            this.panel1.Controls.Add(this.dateTimePickerCreateDate);
            this.panel1.Controls.Add(this.textBoxTotal);
            this.panel1.Controls.Add(this.comboBoxPaymentMethod);
            this.panel1.Controls.Add(this.textBoxAccountName);
            this.panel1.Controls.Add(this.labelTotal);
            this.panel1.Controls.Add(this.labelCreateDate);
            this.panel1.Controls.Add(this.labelAccountName);
            this.panel1.Controls.Add(this.buttonHuy);
            this.panel1.Controls.Add(this.buttonThemSP);
            this.panel1.Controls.Add(this.labelThemSP);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 722);
            this.panel1.TabIndex = 1;
            // 
            // buttonSuaSP
            // 
            this.buttonSuaSP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonSuaSP.ForeColor = System.Drawing.Color.Maroon;
            this.buttonSuaSP.Location = new System.Drawing.Point(1072, 65);
            this.buttonSuaSP.Name = "buttonSuaSP";
            this.buttonSuaSP.Size = new System.Drawing.Size(147, 61);
            this.buttonSuaSP.TabIndex = 23;
            this.buttonSuaSP.Text = "Sửa SP";
            this.buttonSuaSP.UseVisualStyleBackColor = true;
            this.buttonSuaSP.Click += new System.EventHandler(this.buttonSuaSP_Click);
            // 
            // buttonLuuHD
            // 
            this.buttonLuuHD.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonLuuHD.ForeColor = System.Drawing.Color.Maroon;
            this.buttonLuuHD.Location = new System.Drawing.Point(390, 582);
            this.buttonLuuHD.Name = "buttonLuuHD";
            this.buttonLuuHD.Size = new System.Drawing.Size(162, 61);
            this.buttonLuuHD.TabIndex = 22;
            this.buttonLuuHD.Text = "Lưu";
            this.buttonLuuHD.UseVisualStyleBackColor = true;
            this.buttonLuuHD.Click += new System.EventHandler(this.buttonLuuHD_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(813, 592);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(457, 44);
            this.label2.TabIndex = 21;
            this.label2.Text = "Danh Sách Sản Phẩm";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(813, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(548, 44);
            this.label1.TabIndex = 20;
            this.label1.Text = "Danh Sách Sản Phẩm Trong Đơn Hàng";
            // 
            // buttonXoaSP
            // 
            this.buttonXoaSP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonXoaSP.ForeColor = System.Drawing.Color.Maroon;
            this.buttonXoaSP.Location = new System.Drawing.Point(1303, 65);
            this.buttonXoaSP.Name = "buttonXoaSP";
            this.buttonXoaSP.Size = new System.Drawing.Size(147, 61);
            this.buttonXoaSP.TabIndex = 19;
            this.buttonXoaSP.Text = "Xóa  SP";
            this.buttonXoaSP.UseVisualStyleBackColor = true;
            this.buttonXoaSP.Click += new System.EventHandler(this.buttonXoaSP_Click);
            // 
            // dataGridViewProduct
            // 
            this.dataGridViewProduct.AllowUserToAddRows = false;
            this.dataGridViewProduct.AllowUserToDeleteRows = false;
            this.dataGridViewProduct.AllowUserToResizeColumns = false;
            this.dataGridViewProduct.AllowUserToResizeRows = false;
            this.dataGridViewProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduct.Location = new System.Drawing.Point(820, 359);
            this.dataGridViewProduct.Name = "dataGridViewProduct";
            this.dataGridViewProduct.ReadOnly = true;
            this.dataGridViewProduct.RowHeadersWidth = 51;
            this.dataGridViewProduct.RowTemplate.Height = 24;
            this.dataGridViewProduct.Size = new System.Drawing.Size(630, 211);
            this.dataGridViewProduct.TabIndex = 18;
            // 
            // dataGridViewOrderDetail
            // 
            this.dataGridViewOrderDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetail.Location = new System.Drawing.Point(820, 149);
            this.dataGridViewOrderDetail.Name = "dataGridViewOrderDetail";
            this.dataGridViewOrderDetail.RowHeadersWidth = 51;
            this.dataGridViewOrderDetail.RowTemplate.Height = 24;
            this.dataGridViewOrderDetail.Size = new System.Drawing.Size(630, 125);
            this.dataGridViewOrderDetail.TabIndex = 17;
            // 
            // labelPaymentMethod
            // 
            this.labelPaymentMethod.AutoSize = true;
            this.labelPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPaymentMethod.Location = new System.Drawing.Point(127, 256);
            this.labelPaymentMethod.Name = "labelPaymentMethod";
            this.labelPaymentMethod.Size = new System.Drawing.Size(161, 28);
            this.labelPaymentMethod.TabIndex = 16;
            this.labelPaymentMethod.Text = "PaymentMethod:";
            // 
            // dateTimePickerCreateDate
            // 
            this.dateTimePickerCreateDate.Location = new System.Drawing.Point(305, 146);
            this.dateTimePickerCreateDate.Name = "dateTimePickerCreateDate";
            this.dateTimePickerCreateDate.Size = new System.Drawing.Size(247, 22);
            this.dateTimePickerCreateDate.TabIndex = 15;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBoxTotal.Location = new System.Drawing.Point(305, 197);
            this.textBoxTotal.Multiline = true;
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(205, 28);
            this.textBoxTotal.TabIndex = 14;
            // 
            // comboBoxPaymentMethod
            // 
            this.comboBoxPaymentMethod.FormattingEnabled = true;
            this.comboBoxPaymentMethod.Location = new System.Drawing.Point(305, 260);
            this.comboBoxPaymentMethod.Name = "comboBoxPaymentMethod";
            this.comboBoxPaymentMethod.Size = new System.Drawing.Size(161, 24);
            this.comboBoxPaymentMethod.TabIndex = 12;
            // 
            // textBoxAccountName
            // 
            this.textBoxAccountName.Location = new System.Drawing.Point(305, 89);
            this.textBoxAccountName.Multiline = true;
            this.textBoxAccountName.Name = "textBoxAccountName";
            this.textBoxAccountName.Size = new System.Drawing.Size(308, 28);
            this.textBoxAccountName.TabIndex = 10;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(230, 197);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(58, 28);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.Text = "Total:";
            // 
            // labelCreateDate
            // 
            this.labelCreateDate.AutoSize = true;
            this.labelCreateDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreateDate.Location = new System.Drawing.Point(175, 141);
            this.labelCreateDate.Name = "labelCreateDate";
            this.labelCreateDate.Size = new System.Drawing.Size(113, 28);
            this.labelCreateDate.TabIndex = 6;
            this.labelCreateDate.Text = "CreateDate:";
            // 
            // labelAccountName
            // 
            this.labelAccountName.AutoSize = true;
            this.labelAccountName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAccountName.Location = new System.Drawing.Point(148, 89);
            this.labelAccountName.Name = "labelAccountName";
            this.labelAccountName.Size = new System.Drawing.Size(140, 28);
            this.labelAccountName.TabIndex = 5;
            this.labelAccountName.Text = "AccountName:";
            // 
            // buttonHuy
            // 
            this.buttonHuy.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonHuy.ForeColor = System.Drawing.Color.Maroon;
            this.buttonHuy.Location = new System.Drawing.Point(92, 582);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(196, 61);
            this.buttonHuy.TabIndex = 2;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = true;
            this.buttonHuy.Click += new System.EventHandler(this.buttonHuy_Click);
            // 
            // buttonThemSP
            // 
            this.buttonThemSP.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonThemSP.ForeColor = System.Drawing.Color.Maroon;
            this.buttonThemSP.Location = new System.Drawing.Point(820, 65);
            this.buttonThemSP.Name = "buttonThemSP";
            this.buttonThemSP.Size = new System.Drawing.Size(162, 61);
            this.buttonThemSP.TabIndex = 1;
            this.buttonThemSP.Text = "Thêm SP";
            this.buttonThemSP.UseVisualStyleBackColor = true;
            this.buttonThemSP.Click += new System.EventHandler(this.buttonThemSP_Click);
            // 
            // labelThemSP
            // 
            this.labelThemSP.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelThemSP.Location = new System.Drawing.Point(68, 27);
            this.labelThemSP.Name = "labelThemSP";
            this.labelThemSP.Size = new System.Drawing.Size(242, 44);
            this.labelThemSP.TabIndex = 0;
            this.labelThemSP.Text = "Thêm Hóa Đơn";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(219, 311);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(69, 28);
            this.labelStatus.TabIndex = 25;
            this.labelStatus.Text = "Status:";
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Location = new System.Drawing.Point(305, 320);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(136, 20);
            this.checkBoxStatus.TabIndex = 26;
            this.checkBoxStatus.Text = "Chưa Thanh Toán";
            this.checkBoxStatus.UseVisualStyleBackColor = true;
            this.checkBoxStatus.CheckedChanged += new System.EventHandler(this.checkBoxStatus_CheckedChanged);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(305, 370);
            this.textBoxPhone.Multiline = true;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(308, 28);
            this.textBoxPhone.TabIndex = 28;
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhone.Location = new System.Drawing.Point(217, 370);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(71, 28);
            this.labelPhone.TabIndex = 27;
            this.labelPhone.Text = "Phone:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(305, 438);
            this.textBoxEmail.Multiline = true;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(308, 28);
            this.textBoxEmail.TabIndex = 30;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(225, 438);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(63, 28);
            this.labelEmail.TabIndex = 29;
            this.labelEmail.Text = "Email:";
            // 
            // FormCapNhatHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1591, 733);
            this.Controls.Add(this.panel1);
            this.Name = "FormCapNhatHoaDon";
            this.Text = "FormCapNhatHoaDon";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxPaymentMethod;
        private System.Windows.Forms.TextBox textBoxAccountName;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelCreateDate;
        private System.Windows.Forms.Label labelAccountName;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.Button buttonThemSP;
        private System.Windows.Forms.Label labelThemSP;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetail;
        private System.Windows.Forms.Label labelPaymentMethod;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreateDate;
        private System.Windows.Forms.DataGridView dataGridViewProduct;
        private System.Windows.Forms.Button buttonXoaSP;
        private System.Windows.Forms.Button buttonSuaSP;
        private System.Windows.Forms.Button buttonLuuHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.CheckBox checkBoxStatus;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label labelPhone;
    }
}