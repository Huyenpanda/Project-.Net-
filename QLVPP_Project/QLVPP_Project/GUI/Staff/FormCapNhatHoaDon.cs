using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using QLVPP_Project.Dao;
using QLVPP_Project.Model;

namespace QLVPP_Project.GUI.Staff
{
    public partial class FormCapNhatHoaDon : Form
    {
        ProductDao productDao = new ProductDao();
        public FormCapNhatHoaDon()
        {
            InitializeComponent();
            LoadDataGridViewProduct();
            InitializeOrderDetailGrid();
            LoadPaymentMethods();
        }
        private void LoadPaymentMethods()
        {
            DataTable paymentMethods = PaymentDao.Instance.getAll();
            comboBoxPaymentMethod.DataSource = paymentMethods;
            comboBoxPaymentMethod.DisplayMember = "PaymentMethod";
            comboBoxPaymentMethod.ValueMember = "PaymentId";

        }

        private void InitializeOrderDetailGrid()
        {
            dataGridViewOrderDetail.Columns.Add("ProductId", "ProductId");
            dataGridViewOrderDetail.Columns.Add("ProductName", "ProductName");
            dataGridViewOrderDetail.Columns.Add("Quantity", "Quantity");
            dataGridViewOrderDetail.Columns.Add("Price", "Price");
            dataGridViewOrderDetail.Columns.Add("Total", "Total");
        }
        private void checkBoxStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStatus.Checked)
            {
                checkBoxStatus.Text = "Đã Thanh Toán";
            }
            else
            {
                checkBoxStatus.Text = "Chưa Thanh Toán";
            }
        }


        private void LoadDataGridViewProduct()
        {
            dataGridViewProduct.DataSource = ProductDao.Instance.getAll();
        }
        private void UpdateTotalPrice()
        {
            double total = 0;
            foreach (DataGridViewRow row in dataGridViewOrderDetail.Rows)
            {
                total += Convert.ToDouble(row.Cells["Total"].Value);
            }
            textBoxTotal.Text = total.ToString("C2"); // Định dạng tiền tệ
        }

        // Sự kiện khi nhấn nút Thêm Sản Phẩm
        private void buttonThemSP_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewProduct.SelectedRows[0];
                int ProductId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value);

                string productName = selectedRow.Cells["ProductName"].Value.ToString();
                double price = Convert.ToDouble(selectedRow.Cells["Price"].Value);
                

                // Hiển thị hộp thoại nhập số lượng
                using (var form = new Form())
                {
                    form.Width = 250;
                    form.Height = 150;
                    form.Text = "Thêm Sản Phẩm";

                    var label = new Label() { Left = 10, Top = 10, Text = "Nhập số lượng:" };
                    var textBox = new TextBox() { Left = 10, Top = 30, Width = 200 };
                    var buttonOk = new Button() { Text = "OK", Left = 150, Width = 60, Top = 60, DialogResult = DialogResult.OK };

                    form.AcceptButton = buttonOk;
                    form.Controls.Add(label);
                    form.Controls.Add(textBox);
                    form.Controls.Add(buttonOk);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (int.TryParse(textBox.Text, out int quantity) && quantity > 0)
                        {
                            double total = price * quantity;

                            // Kiểm tra xem sản phẩm đã tồn tại trong DataGridView chưa
                            foreach (DataGridViewRow existingRow in dataGridViewOrderDetail.Rows)
                            {
                                if (existingRow.Cells["ProductId"].Value != null &&
                                    Convert.ToInt32(existingRow.Cells["ProductId"].Value) == ProductId)
                                {
                                    MessageBox.Show("Sản phẩm này đã được thêm vào chi tiết hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }

                            // Thêm sản phẩm vào chi tiết hóa đơn
                            dataGridViewOrderDetail.Rows.Add(ProductId, productName, quantity, price, total);
                            UpdateTotalPrice();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonXoaSP_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderDetail.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewOrderDetail.SelectedRows)
                {
                    dataGridViewOrderDetail.Rows.Remove(row);
                    UpdateTotalPrice();
                }
                MessageBox.Show("Đã xóa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void buttonSuaSP_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrderDetail.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewOrderDetail.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["ProductId"].Value);
                string productName = selectedRow.Cells["ProductName"].Value.ToString();
                double price = Convert.ToDouble(selectedRow.Cells["Price"].Value);
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

                // Hiển thị hộp thoại sửa số lượng
                using (var form = new Form())
                {
                    form.Width = 250;
                    form.Height = 150;
                    form.Text = "Sửa Sản Phẩm";

                    var label = new Label() { Left = 10, Top = 10, Text = "Nhập số lượng mới:" };
                    var textBox = new TextBox() { Left = 10, Top = 30, Width = 200, Text = quantity.ToString() };
                    var buttonOk = new Button() { Text = "OK", Left = 150, Width = 60, Top = 60, DialogResult = DialogResult.OK };

                    form.AcceptButton = buttonOk;
                    form.Controls.Add(label);
                    form.Controls.Add(textBox);
                    form.Controls.Add(buttonOk);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (int.TryParse(textBox.Text, out int newQuantity) && newQuantity > 0)
                        {
                            double total = price * newQuantity;
                            selectedRow.Cells["Quantity"].Value = newQuantity;
                            selectedRow.Cells["Total"].Value = total;

                            MessageBox.Show("Đã cập nhật sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UpdateTotalPrice();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLuuHD_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string accountName = textBoxAccountName.Text;
                DateTime createDate = dateTimePickerCreateDate.Value;
                int paymentId;
                double totalPrice;

                // Kiểm tra nếu phương thức thanh toán được chọn hay chưa
                if (comboBoxPaymentMethod.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paymentId = Convert.ToInt32(comboBoxPaymentMethod.SelectedValue);

                // Kiểm tra và chuyển đổi tổng giá từ textBoxTotal
                if (!double.TryParse(textBoxTotal.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out totalPrice))
                {
                    MessageBox.Show("Vui lòng thêm sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy giá trị từ input
                string phone = textBoxPhone.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                bool status = checkBoxStatus.Checked;
                
                // Kiểm tra định dạng email và số điện thoại
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!IsValidPhone(phone))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đảm bảo tài khoản khách hàng tồn tại và cập nhật Phone, Email
                int accountId = EnsureCustomerAccount(accountName);
                if (!AccountDao.Instance.UpdateContactInfo(accountId, phone, email))
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo đối tượng hóa đơn mới
                Order newOrder = new Order
                {
                    AccountId = accountId,
                    CreateDate = createDate,
                    PaymentId = paymentId,
                    Total = totalPrice
                };

                // Chèn hóa đơn mới vào cơ sở dữ liệu
                if (OrderDao.Instance.Insert(newOrder))
                {
                    // Lưu chi tiết hóa đơn vào cơ sở dữ liệu
                    foreach (DataGridViewRow row in dataGridViewOrderDetail.Rows)
                    {
                        if (row.Cells["ProductId"].Value == null || row.Cells["Quantity"].Value == null || row.Cells["Total"].Value == null)
                        {
                            continue;
                        }

                        int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        double total = Convert.ToDouble(row.Cells["Total"].Value);

                        if (productId <= 0 || quantity <= 0 || total <= 0)
                        {
                            continue;
                        }

                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderId = newOrder.OrderId,
                            ProductId = productId,
                            Quantity = quantity,
                            Total = total,
                            Status = status // Lưu trạng thái từ checkBoxStatus
                        };

                        if (!OrderDetailDao.Instance.Insert(orderDetail))
                        {
                            MessageBox.Show("Lưu chi tiết hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    MessageBox.Show("Đã lưu hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Đóng form sau khi lưu thành công
                }
                else
                {
                    MessageBox.Show("Lưu hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(textBoxAccountName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBoxPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dataGridViewOrderDetail.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 10 && phone.Length <= 15;
        }

        private int EnsureCustomerAccount(string accountName)
        {
            int accountId = AccountDao.Instance.GetAccountIdByName(accountName);
            if (accountId == -1) // Tài khoản chưa tồn tại
            {
                Account newAccount = new Account
                {
                    AccountName = accountName,
                    Role = "customer",
                    UserName = accountName, // Giả sử Username bằng AccountName
                    PassWord = "defaultPassword", // Mật khẩu mặc định
                    Email = "", // Có thể cập nhật sau
                    Phone = ""  // Có thể cập nhật sau
                };

                if (AccountDao.Instance.Insert(newAccount))
                {
                    accountId = AccountDao.Instance.GetAccountIdByName(accountName);
                }
            }
            return accountId;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
