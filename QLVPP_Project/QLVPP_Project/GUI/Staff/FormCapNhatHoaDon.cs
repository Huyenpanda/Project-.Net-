using System;
using System.ComponentModel;
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
        private bool isEditing;
        private int currentOrderId;
        private DataTable orderDetailTable;
        ProductDao productDao = new ProductDao();
        public FormCapNhatHoaDon(bool isEditing = false, int orderId = 0)
        {
            InitializeComponent();
            InitializeOrderDetailGrid();
            this.isEditing = isEditing; 
            this.currentOrderId = orderId; 
            if (isEditing) { 
                labelThemSP.Text = "Sửa Thông Tin Hóa Đơn"; 
                LoadOrderDetails(orderId); 
            }
            else
            {
                labelThemSP.Text = "Thêm Hóa Đơn";
                Account acc = AccountDao.Instance.getAccountById(SessionManager.AccountId);
                textBoxAccountName.Text = acc.AccountName;
                textBoxPhone.Text = acc.Phone;
                textBoxEmail.Text = acc.Email;
            }
            textBoxAccountName.ReadOnly = true;
            textBoxEmail.ReadOnly = true;
            textBoxPhone.ReadOnly = true;

            LoadDataGridViewProduct();
            
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
            orderDetailTable = new DataTable();
            orderDetailTable.Columns.Add("ProductId", typeof(int));
            orderDetailTable.Columns.Add("ProductName", typeof(string));
            orderDetailTable.Columns.Add("Quantity", typeof(int));
            orderDetailTable.Columns.Add("Price", typeof(double));
            orderDetailTable.Columns.Add("Total", typeof(double));

            dataGridViewOrderDetail.DataSource = orderDetailTable;
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

                using (var form = new Form())
                {
                    form.Width = 250;
                    form.Height = 150;
                    form.Text = "Thêm Sản Phẩm";
                    form.StartPosition = FormStartPosition.CenterScreen;

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

                            // Kiểm tra xem sản phẩm đã tồn tại trong DataTable
                            var existRow = orderDetailTable.AsEnumerable()
                                .FirstOrDefault(row => row.Field<int>("ProductId") == ProductId);
                            if (existRow != null)
                            {
                                MessageBox.Show("Sản phẩm đã được thêm vào hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            // Thêm hàng mới vào DataTable
                            DataRow newRow = orderDetailTable.NewRow();
                            newRow["ProductId"] = ProductId;
                            newRow["ProductName"] = productName;
                            newRow["Quantity"] = quantity;
                            newRow["Price"] = price;
                            newRow["Total"] = total;
                            orderDetailTable.Rows.Add(newRow);

                            // Cập nhật tổng tiền
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

        private void LoadOrderDetails(int orderId)
        {
            Order order = OrderDao.Instance.getById(orderId);
            if (order != null)
            {
                textBoxAccountName.Text = AccountDao.Instance.GetUserNameById(order.AccountId);
                dateTimePickerCreateDate.Value = order.CreateDate;
                textBoxTotal.Text = order.Total.ToString("C2");
                comboBoxPaymentMethod.SelectedValue = order.PaymentId;

                DataTable orderDetails = OrderDetailDao.Instance.getByOrderId(orderId);
                //foreach (DataRow row in orderDetails.Rows)
                //{
                //    dataGridViewOrderDetail.Rows.Add(row["ProductId"], ProductDao.Instance.getProductNameById((int)row["ProductId"]), row["Quantity"], row["Price"], row["Total"]);
                //}
                dataGridViewOrderDetail.DataSource = null;
                dataGridViewOrderDetail.DataSource = orderDetails;
                var customer = AccountDao.Instance.getAccountById(order.AccountId);
                if (customer != null)
                {
                    textBoxPhone.Text = customer.Phone;
                    textBoxEmail.Text = customer.Email;
                }

                // Lấy trạng thái từ chi tiết hóa đơn đầu tiên
                
            }
        }


        private void buttonLuuHD_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string accountName = textBoxAccountName.Text;
                DateTime createDate = dateTimePickerCreateDate.Value;
                int paymentId;
                decimal totalPrice;

                // Kiểm tra nếu phương thức thanh toán được chọn hay chưa
                if (comboBoxPaymentMethod.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn phương thức thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paymentId = Convert.ToInt32(comboBoxPaymentMethod.SelectedValue);

                // Kiểm tra và chuyển đổi tổng giá từ textBoxTotal
                if (!decimal.TryParse(textBoxTotal.Text, System.Globalization.NumberStyles.Currency, System.Globalization.CultureInfo.CurrentCulture, out totalPrice))
                {
                    MessageBox.Show("Vui lòng thêm sản phẩm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy giá trị từ input
                string phone = textBoxPhone.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                

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
                int accountId = SessionManager.AccountId;
                if (!AccountDao.Instance.UpdateContactInfo(accountId, phone, email))
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
               
                if (isEditing)
                {
                    Order updatedOrder = new Order
                    {
                        OrderId = currentOrderId,
                        AccountId = accountId,
                        CreateDate = createDate,
                        PaymentId = paymentId,
                        Total = totalPrice
                    };

                    if (OrderDao.Instance.Update(updatedOrder))
                    {
                        // Cập nhật chi tiết hóa đơn
                        foreach (DataGridViewRow row in dataGridViewOrderDetail.Rows)
                        {
                            if (row.Cells["ProductId"].Value == null || row.Cells["Quantity"].Value == null || row.Cells["Total"].Value == null)
                            {
                                continue;
                            }

                            int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);
                            OrderDetail odt = OrderDetailDao.Instance.getByProductIdAndOrderId(productId, updatedOrder.OrderId);
                            OrderDetail orderDetail = new OrderDetail
                            {
                                OrderDetailId = odt.OrderDetailId,
                                OrderId = updatedOrder.OrderId,
                                ProductId = productId,
                                Quantity = quantity,
                                Total = total,
                                Status = false
                            };
                           
                            if (!OrderDetailDao.Instance.Update(orderDetail))
                            {
                                MessageBox.Show("Cập nhật chi tiết hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        MessageBox.Show("Đã cập nhật hóa đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật hóa đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Thêm mới hóa đơn
                    Order newOrder = new Order
                    {
                        AccountId = accountId,
                        CreateDate = createDate,
                        PaymentId = paymentId,
                        Total = totalPrice
                    };

                    if (OrderDao.Instance.Insert(newOrder))
                    {
                        // Lưu chi tiết hóa đơn
                        foreach (DataGridViewRow row in dataGridViewOrderDetail.Rows)
                        {
                            if (row.Cells["ProductId"].Value == null || row.Cells["Quantity"].Value == null || row.Cells["Total"].Value == null)
                            {
                                continue;
                            }

                            int productId = Convert.ToInt32(row.Cells["ProductId"].Value);
                            int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                            decimal total = Convert.ToDecimal(row.Cells["Total"].Value);

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
                                Status = false
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

        

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
