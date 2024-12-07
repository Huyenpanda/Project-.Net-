using QLVPP_Project.Dao;
using QLVPP_Project.GUI.admin;
using QLVPP_Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVPP_Project
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string un = txtUsername.Text;
            string pass = txtPassword.Text;
            bool ck = true;
            if(un == "" || un == null)
            {
                MessageBox.Show("Username > 3 ký tự");
                ck = false;
            }
            if(pass == "" || pass == null || pass.Length > 5 )
            {
                MessageBox.Show("Password > 5 ký tự");
                ck = false;
            }

            if (ck)
            {
                if (new AccountDao().checkLogin(un, pass))
                {
                    if (new AccountDao().isAdminOrStaff(un))
                    {   
                        this.Hide();
                        FrmTrangChu newFrm = new FrmTrangChu();
                        newFrm.Show();
                    }
                    else
                    {
                        this.Hide();
                        FormQuanLySanPham newFrm = new FormQuanLySanPham();
                        newFrm.Show();
                    }
                    SessionManager.AccountId = AccountDao.Instance.GetAccountIdByUserName(un);
                }
            }
            else
                MessageBox.Show("Lỗi đăng nhập");

        }
    }
}
