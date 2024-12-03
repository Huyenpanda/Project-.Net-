using System.Windows.Forms;

namespace QLVPP_Project
{
    partial class UserControl_SideBar
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panel_SideBar;
        private PictureBox pictureBox_logo;
        private Button button_QuanLySanPham;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl_SideBar));
            this.panel_SideBar = new System.Windows.Forms.Panel();
            this.buttonThoat = new System.Windows.Forms.Button();
            this.buttonQLDH = new System.Windows.Forms.Button();
            this.button_QuanLySanPham = new System.Windows.Forms.Button();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.panel_SideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_SideBar
            // 
            this.panel_SideBar.BackColor = System.Drawing.Color.Maroon;
            this.panel_SideBar.Controls.Add(this.buttonThoat);
            this.panel_SideBar.Controls.Add(this.buttonQLDH);
            this.panel_SideBar.Controls.Add(this.button_QuanLySanPham);
            this.panel_SideBar.Controls.Add(this.pictureBox_logo);
            this.panel_SideBar.Location = new System.Drawing.Point(0, 0);
            this.panel_SideBar.Name = "panel_SideBar";
            this.panel_SideBar.Size = new System.Drawing.Size(300, 950);
            this.panel_SideBar.TabIndex = 0;
            // 
            // buttonThoat
            // 
            this.buttonThoat.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThoat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(56)))), ((int)(((byte)(57)))));
            this.buttonThoat.Location = new System.Drawing.Point(67, 854);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(137, 45);
            this.buttonThoat.TabIndex = 5;
            this.buttonThoat.Text = "Thoát";
            this.buttonThoat.UseVisualStyleBackColor = true;
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // buttonQLDH
            // 
<<<<<<< HEAD
            this.buttonQLDH.BackgroundImage = global::QLVPP_Project.Properties.Resources.MaroonCloud_background;
            this.buttonQLDH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonQLDH.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold);
            this.buttonQLDH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.buttonQLDH.Location = new System.Drawing.Point(-32, 347);
            this.buttonQLDH.Name = "buttonQLDH";
            this.buttonQLDH.Size = new System.Drawing.Size(364, 100);
            this.buttonQLDH.TabIndex = 4;
            this.buttonQLDH.Text = "Quản Lý Đơn Hàng";
            this.buttonQLDH.UseVisualStyleBackColor = true;
            this.buttonQLDH.Click += new System.EventHandler(this.buttonQLDH_Click);
=======
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.button2.Location = new System.Drawing.Point(0, 357);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(300, 100);
            this.button2.TabIndex = 4;
            this.button2.Text = "Quản Lý Đơn Hàng";
            this.button2.UseVisualStyleBackColor = true;
>>>>>>> origin/develop
            // 
            // button_QuanLySanPham
            // 
            this.button_QuanLySanPham.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_QuanLySanPham.BackgroundImage")));
            this.button_QuanLySanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_QuanLySanPham.Font = new System.Drawing.Font("Modern No. 20", 14F, System.Drawing.FontStyle.Bold);
            this.button_QuanLySanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(246)))), ((int)(((byte)(194)))));
            this.button_QuanLySanPham.Location = new System.Drawing.Point(0, 251);
            this.button_QuanLySanPham.Name = "button_QuanLySanPham";
            this.button_QuanLySanPham.Size = new System.Drawing.Size(300, 100);
            this.button_QuanLySanPham.TabIndex = 1;
            this.button_QuanLySanPham.Text = "Quản Lý Sản phẩm";
            this.button_QuanLySanPham.UseVisualStyleBackColor = true;
            this.button_QuanLySanPham.Click += new System.EventHandler(this.buttonQuanLySanPham_Click);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_logo.ErrorImage = null;
            this.pictureBox_logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_logo.Image")));
            this.pictureBox_logo.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(300, 257);
            this.pictureBox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_logo.TabIndex = 0;
            this.pictureBox_logo.TabStop = false;
            // 
            // UserControl_SideBar
            // 
            this.Controls.Add(this.panel_SideBar);
            this.Name = "UserControl_SideBar";
            this.Size = new System.Drawing.Size(300, 950);
            this.panel_SideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.ResumeLayout(false);

        }
        private Button buttonQLDH;
        private Button buttonThoat;
    }
}
