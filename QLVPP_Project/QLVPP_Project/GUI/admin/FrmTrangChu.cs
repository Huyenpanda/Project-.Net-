using QLVPP_Project.Dao;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace QLVPP_Project.GUI.admin
{
    public partial class FrmTrangChu : Form
    {
        private int selectedRowIndex = -1;
        private int selectedRowIndexAccount = -1;
        public FrmTrangChu()
        {
            InitializeComponent();
            dataTableGridViewProduct(ProductDao.Instance.getAll());
            dataCbbCategory();
            
        }
        // DataTable Product
        private void dataTableGridViewProduct(DataTable data)
        {
            dtgrvProduct.DataSource = null;
            dtgrvProduct.DataSource = data;
        }
        // DataCbb Category
        private void dataCbbCategory()
        {
            DataTable data = CategoryDao.Instance.getAll();
            cbbCategory.DataSource = data;
            cbbCategory.DisplayMember = "CategoryName";
            cbbCategory.ValueMember = "CategoryId";
        }
        // DataTable Account
        private void dataTableGirdViewAccount(DataTable data)
        {
            dtgrvAccount.DataSource = null;
            dtgrvAccount.DataSource = data;
        }
        // DataCbb Role and RoleFind
        private void dataCbbRoleAccount()
        {
            DataTable data = new AccountDao().getAll();
            HashSet<string> roles = new HashSet<string>();
            foreach (DataRow row in data.Rows)
            {
                roles.Add(row["Role"].ToString());
            }
            List<String> roleList1 = new List<string>(roles);
            List<String> roleList2 = new List<string>(roles);

            CbbRole.DataSource = roleList1;
            CbbRoleFind.DataSource = roleList2;

        }
        // Data ChartBCTK Doanh Thu theo Thang
        public void dataChartRevenueByMonth()
        {
            chartRevenueByMonth.Series.Clear();
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            foreach (DataRow row in BaoCaoThongKeDao.Instance.revenueByMonth().Rows)
            {
                series.Points.AddXY("Tháng " + row["Month"], row["Revenue"]);
            }
            chartRevenueByMonth.Series.Add(series);
            chartRevenueByMonth.ChartAreas[0].AxisX.Title = "Tháng";
            chartRevenueByMonth.ChartAreas[0].AxisY.Title = "Doanh thu $";
        }
        // Data ChartPieBCTK Top SP ban chay
        public void dataChartTopSaleProduct()
        {
            chartTopSaleProduct.Series.Clear();
            chartTopSaleProduct.Legends.Clear();

            Series series = new Series("Sales")
            {
                ChartType = SeriesChartType.Pie
            };
            chartTopSaleProduct.Series.Add(series);
            foreach (DataRow row in BaoCaoThongKeDao.Instance.getTopSaleProduct().Rows)
            {
                string productName = row["ProductGroup"].ToString();
                int quantity = Convert.ToInt32(row["TotalQuantity"]);

                DataPoint point = new DataPoint
                {
                    AxisLabel = productName, 
                    YValues = new[] { (double)quantity }, 
                    Label = $"{productName}: {quantity}" 
                };
                chartTopSaleProduct.Series["Sales"].Points.Add(point);
            }

            chartTopSaleProduct.Legends.Clear(); 

            chartTopSaleProduct.ChartAreas[0].Position = new ElementPosition(0, 0, 100, 100); 
            chartTopSaleProduct.ChartAreas[0].InnerPlotPosition = new ElementPosition(0, 0, 100, 100); 
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            panelQLSP.BringToFront();
            LabelMain.Text = "Quản Lý Sản Phẩm";
        }

        private void btnQLTK_Click(object sender, EventArgs e)
        {
            panelQLTK.BringToFront();
            LabelMain.Text = "Quản Lý Tài Khoản";
            dataTableGirdViewAccount(new AccountDao().getAll());
            dataCbbRoleAccount();
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            panelBCTK.BringToFront();
            LabelMain.Text = "Báo Cáo Thống Kê";
            dataChartRevenueByMonth();
            dataChartTopSaleProduct();
        }

        // Insert Product
        private void btnInsertProduct_Click(object sender, EventArgs e)
        {
            string proName = txtProductName.Text;
            string descrip = rtxtDescription.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            string unit = txtUnit.Text;
            string imgUrl = txtImgUrl.Text;
            int cateId = Convert.ToInt32(cbbCategory.SelectedValue);

            Product newPro = new Product(proName, descrip, price, unit, imgUrl, cateId);

            if (ProductDao.Instance.Insert(newPro))
            {
                MessageBox.Show("Insert Product Success");
                dataTableGridViewProduct(ProductDao.Instance.getAll());
            }
            else
                MessageBox.Show("Insert Product Fail");

        }
        // Bind vào các trường dữ liệu
        private void dtgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgrvProduct.Rows[e.RowIndex];
                selectedRowIndex = e.RowIndex;
                txtProductName.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                rtxtDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "";
                txtImgUrl.Text = row.Cells["ImgUrl"].Value.ToString() ?? "";

                cbbCategory.SelectedValue = row.Cells["CategoryId"].Value ?? 0;

            }
        }
        // Update Product
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1)
            {
                MessageBox.Show("Vui chọn sản phẩm từ bảng để cập nhật");
                return;
            }
            DataGridViewRow row = dtgrvProduct.Rows[selectedRowIndex];
            int proId = Convert.ToInt32(row.Cells["ProductId"].Value);

            string proName = txtProductName.Text;
            string descrip = rtxtDescription.Text;
            double price = Convert.ToDouble(txtPrice.Text);
            string unit = txtUnit.Text;
            string imgUrl = txtImgUrl.Text;
            int cateId = Convert.ToInt32(cbbCategory.SelectedValue);
            Product updatePro = new Product(proId, proName, descrip, price, unit, imgUrl, cateId);
            if (ProductDao.Instance.Update(updatePro))
            {
                MessageBox.Show("Update Product Success");
                dataTableGridViewProduct(ProductDao.Instance.getAll());
            }
            else
                MessageBox.Show("Update Product Fail");

        }
        // Delete Product
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex == -1)
            {
                MessageBox.Show("Vui chọn sản phẩm từ bảng để xóa");
                return;
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa sản phẩm này ko ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                DataGridViewRow row = dtgrvProduct.Rows[selectedRowIndex];
                int proId = Convert.ToInt32(row.Cells["ProductId"].Value);

                if (ProductDao.Instance.Delete(proId))
                {
                    MessageBox.Show("Delete Product Success");
                    dataTableGridViewProduct(ProductDao.Instance.getAll());
                }
                else
                    MessageBox.Show("Delete Product Fail");
            }
        }

        // Insert n Product - DataTable from ImportExcel
        private void insertAllDataTable(DataTable dataExcel)
        {
            if (dataExcel.Rows.Count > 0)
            {
                foreach (DataRow row in dataExcel.Rows)
                {
                    string proName = row["ProductName"].ToString();
                    string descrip = row["Description"].ToString();
                    double price = Convert.ToDouble(row["Price"]);
                    string unit = row["Unit"].ToString();
                    string imgUrl = row["ImgUrl"].ToString();
                    int cateId = Convert.ToInt32(row["CategoryId"]);

                    Product newPro = new Product(proName, descrip, price, unit, imgUrl, cateId);
                    bool rs = ProductDao.Instance.Insert(newPro);
                    if (!rs)
                    {
                        MessageBox.Show("Insert Product Fail At : " + proName);

                    }

                }
                MessageBox.Show("Insert Product All Success");
            }
            else
                MessageBox.Show("No data to insert. Please import the Excel file first.");
        }

        // Import Excel Product
        private void btnImportExcelProduct_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                DataTable dataExcel = new ModelExcel().ImportExcel(filePath);
                insertAllDataTable(dataExcel);

                dataTableGridViewProduct(ProductDao.Instance.getAll());
            }
        }
        // Export Excel Product
        private void btnExportExcelProduct_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files (*xlsx)|*.xlsx";
            saveFileDialog.Title = "Save Excel Product File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;
                new ModelExcel().ExportExcel(ProductDao.Instance.getAll(), filepath);
                MessageBox.Show("Export Product Excel Success");
            }
        }
        // Tìm kiếm sản phẩm theo tên và giá 
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string proNameToFind = TxtProNameFind.Text;
            double fromPrice = 0;
            double toPrice = 0;
            if (!string.IsNullOrEmpty(TxtFromPrice.Text) && !double.TryParse(TxtFromPrice.Text, out fromPrice))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho giá từ.");
                return;
            }
            if (!string.IsNullOrEmpty(TxtToPrice.Text) && !double.TryParse(TxtToPrice.Text, out toPrice))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho giá đến.");
                return;
            }

            DataTable findDataTable = ProductDao.Instance.searchByNameAndPrice(proNameToFind, fromPrice, toPrice);
            dataTableGridViewProduct(findDataTable);


        }
        // Thoát đăng nhập
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin newFrm = new FrmLogin();
            newFrm.ShowDialog();
        }
        // Insert Account
        private void BtnInsertAccount_Click(object sender, EventArgs e)
        {
            string accName = TxtAccountName.Text;
            string role = CbbRole.SelectedItem.ToString();
            string userName = TxtUsername.Text;
            string password = TxtPassword.Text;
            string email = TxtEmail.Text;
            string phone = TxtPhone.Text;

            if (!string.IsNullOrEmpty(accName) && !string.IsNullOrEmpty(role) && !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone))
            {
                Account newAcc = new Account(accName, role, userName, new Cypher().cypherSHA1(password), email, phone);
                if (new AccountDao().Insert(newAcc))
                {
                    MessageBox.Show("Insert Account Success");
                    dataTableGirdViewAccount(new AccountDao().getAll());
                    TxtAccountName.Text = "";
                    CbbRole.SelectedIndex = 0;
                    TxtUsername.Text = "";
                    TxtPassword.Text = "";
                    TxtEmail.Text = "";
                    TxtPhone.Text = "";
                }
                else
                {
                    MessageBox.Show("Insert Account Fail");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng xem lại thông tin");
                return;
            }


        }
        // Delete Account
        private void BtnDeleteAccount_Click(object sender, EventArgs e)
        {
            if (selectedRowIndexAccount == -1)
            {
                MessageBox.Show("Vui lòng chọn account xóa");
                return;
            }
            else
            {
                DialogResult rs = MessageBox.Show("Bạn có xác nhận xóa tài khoản này ko ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                {
                    DataGridViewRow row = dtgrvAccount.Rows[selectedRowIndexAccount];
                    int accId = Convert.ToInt32(row.Cells["AccountId"].Value);
                    if (new AccountDao().Delete(accId))
                    {
                        MessageBox.Show("Delete Account Success");
                        dataTableGirdViewAccount(new AccountDao().getAll());
                    }
                    else
                    {
                        MessageBox.Show("Delete Account Fail");

                        return;
                    }
                }
                else
                    return;
            }
        }

        private void DtgrvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                selectedRowIndexAccount = (int)e.RowIndex;
        }
        // Search Theo Role or AccountName
        private void BtnSearchAccount_Click(object sender, EventArgs e)
        {
            string role = CbbRoleFind.SelectedItem.ToString();
            string accountName = TxtAccountNameFind.Text;

            DataTable data = new AccountDao().searchByRoleOrAccountName(role, accountName);
            dataTableGirdViewAccount(data);


        }
    }
}
