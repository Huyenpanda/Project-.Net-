namespace QLVPP_Project.GUI
{
    partial class UserControlThemSanPham
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelThemSP = new System.Windows.Forms.Label();
            this.buttonLuu = new System.Windows.Forms.Button();
            this.buttonHuy = new System.Windows.Forms.Button();
            this.labelProductID = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelCategoryName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.labelDescription);
            this.panel1.Controls.Add(this.labelCategoryName);
            this.panel1.Controls.Add(this.labelPrice);
            this.panel1.Controls.Add(this.labelProductName);
            this.panel1.Controls.Add(this.labelProductID);
            this.panel1.Controls.Add(this.buttonHuy);
            this.panel1.Controls.Add(this.buttonLuu);
            this.panel1.Controls.Add(this.labelThemSP);
            this.panel1.Location = new System.Drawing.Point(189, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 675);
            this.panel1.TabIndex = 0;
            // 
            // labelThemSP
            // 
            this.labelThemSP.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.labelThemSP.Location = new System.Drawing.Point(68, 27);
            this.labelThemSP.Name = "labelThemSP";
            this.labelThemSP.Size = new System.Drawing.Size(242, 44);
            this.labelThemSP.TabIndex = 0;
            this.labelThemSP.Text = "Thêm Sản Phẩm";
            // 
            // buttonLuu
            // 
            this.buttonLuu.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonLuu.ForeColor = System.Drawing.Color.Maroon;
            this.buttonLuu.Location = new System.Drawing.Point(392, 550);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(196, 61);
            this.buttonLuu.TabIndex = 1;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.UseVisualStyleBackColor = true;
            // 
            // buttonHuy
            // 
            this.buttonHuy.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.buttonHuy.ForeColor = System.Drawing.Color.Maroon;
            this.buttonHuy.Location = new System.Drawing.Point(95, 550);
            this.buttonHuy.Name = "buttonHuy";
            this.buttonHuy.Size = new System.Drawing.Size(196, 61);
            this.buttonHuy.TabIndex = 2;
            this.buttonHuy.Text = "Hủy";
            this.buttonHuy.UseVisualStyleBackColor = true;
            // 
            // labelProductID
            // 
            this.labelProductID.AutoSize = true;
            this.labelProductID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductID.Location = new System.Drawing.Point(187, 92);
            this.labelProductID.Name = "labelProductID";
            this.labelProductID.Size = new System.Drawing.Size(104, 28);
            this.labelProductID.TabIndex = 4;
            this.labelProductID.Text = "ProductID:";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProductName.Location = new System.Drawing.Point(154, 151);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(137, 28);
            this.labelProductName.TabIndex = 5;
            this.labelProductName.Text = "ProductName:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrice.Location = new System.Drawing.Point(233, 215);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(58, 28);
            this.labelPrice.TabIndex = 6;
            this.labelPrice.Text = "Price:";
            // 
            // labelCategoryName
            // 
            this.labelCategoryName.AutoSize = true;
            this.labelCategoryName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategoryName.Location = new System.Drawing.Point(143, 276);
            this.labelCategoryName.Name = "labelCategoryName";
            this.labelCategoryName.Size = new System.Drawing.Size(148, 28);
            this.labelCategoryName.TabIndex = 7;
            this.labelCategoryName.Text = "CategoryName:";
            this.labelCategoryName.Click += new System.EventHandler(this.labelCategoryName_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(175, 340);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(116, 28);
            this.labelDescription.TabIndex = 8;
            this.labelDescription.Text = "Description:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(305, 92);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(359, 28);
            this.textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(305, 151);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(359, 28);
            this.textBox2.TabIndex = 10;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(305, 215);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(359, 28);
            this.textBox3.TabIndex = 11;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(305, 279);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(359, 24);
            this.comboBox1.TabIndex = 12;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(305, 340);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(359, 161);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // UserControlThemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlThemSanPham";
            this.Size = new System.Drawing.Size(1300, 1000);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelThemSP;
        private System.Windows.Forms.Button buttonHuy;
        private System.Windows.Forms.Button buttonLuu;
        private System.Windows.Forms.Label labelProductID;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelCategoryName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ImageList imageList1;
    }
}
