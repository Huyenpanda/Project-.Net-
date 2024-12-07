using QLVPP_Project.Dao;
using QLVPP_Project.Model;
using System.Data;
using System.Windows.Forms;
using System;

namespace QLVPP_Project.GUI.Staff
{
    public partial class FormChiTietHoaDon : Form
    {
        private int orderId;

        public FormChiTietHoaDon(int OrderId)
        {
            InitializeComponent();
            this.orderId = OrderId;
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            try
            {
                Order order = OrderDao.Instance.getById(orderId);
                if (order == null)
                {
                    Console.WriteLine("Order not found!");
                    return;
                }

                // Gọi phương thức LoadOrderDetails để kiểm tra xem nó có hoạt động không
                LoadOrderDetails(orderId);
                //LoadOrderStatus(orderId);
                LoadPaymentMethod(order.PaymentId);
                LoadOrderTotal(orderId);
                LoadAccountDetails(order.AccountId);
                LoadOrderCreateDate(orderId);
                LoadOrderId(orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading order details: " + ex.Message);
            }
        }


        private void LoadOrderDetails(int orderId)
        {
            try
            {
                DataTable orderDetails = OrderDetailDao.Instance.getOrderDetailByOrderId(orderId);
                Console.WriteLine("Order details retrieved: " + orderDetails.Rows.Count + " rows.");
                if (orderDetails.Rows.Count == 0)
                {
                    Console.WriteLine("No order details found for this order.");
                    return;
                }

                foreach (DataRow row in orderDetails.Rows)
                {
                    Console.WriteLine($"ProductId: {row["ProductId"]}, ProductName: {row["ProductName"]}, Price: {row["Price"]}, Quantity: {row["Quantity"]}, Total: {row["Total"]}");
                }

                // Hiển thị dữ liệu lên dataGridViewOrderDetail
                dataGridViewDSSPDH.DataSource = orderDetails;

                // Cấu hình hiển thị
                dataGridViewDSSPDH.Columns["ProductId"].HeaderText = "Product ID";
                dataGridViewDSSPDH.Columns["ProductName"].HeaderText = "Product Name";
                dataGridViewDSSPDH.Columns["Price"].HeaderText = "Price";
                dataGridViewDSSPDH.Columns["Quantity"].HeaderText = "Quantity";
                dataGridViewDSSPDH.Columns["Total"].HeaderText = "Total";

                dataGridViewDSSPDH.Columns["ProductId"].Width = 100;
                dataGridViewDSSPDH.Columns["ProductName"].Width = 200;
                dataGridViewDSSPDH.Columns["Price"].Width = 100;
                dataGridViewDSSPDH.Columns["Quantity"].Width = 100;
                dataGridViewDSSPDH.Columns["Total"].Width = 120;

                // Căn giữa nội dung
                foreach (DataGridViewColumn column in dataGridViewDSSPDH.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading order details: " + ex.Message);
            }
        }

        /*private void LoadOrderStatus(int orderId)
        {
            try
            {
                DataTable orderDetails = OrderDetailDao.Instance.getByOrderId(orderId);
                Console.WriteLine("Order status retrieved: " + orderDetails.Rows.Count + " rows.");
                if (orderDetails.Rows.Count > 0)
                {
                    checkBoxStatus.Checked = (bool)orderDetails.Rows[0]["Status"];
                    checkBoxStatus.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading order status: " + ex.Message);
            }
        }*/

        private void LoadPaymentMethod(int paymentId)
        {
            try
            {
                string paymentMethod = PaymentDao.Instance.GetPaymentMethodById(paymentId);
                textBoxPaymentMethod.Text = paymentMethod;
                textBoxPaymentMethod.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading payment method: " + ex.Message);
            }
        }

        private void LoadOrderTotal(int orderId)
        {
            try
            {
                Order order = OrderDao.Instance.getById(orderId);
                if (order != null)
                {
                    textBoxTotal.Text = order.Total.ToString();
                    textBoxTotal.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading order total: " + ex.Message);
            }
        }

        private void LoadAccountDetails(int accountId)
        {
            try
            {
                Account account = AccountDao.Instance.getAccountById(accountId);
                if (account != null)
                {
                    textBoxEmail.Text = account.Email;
                    textBoxPhone.Text = account.Phone;
                    textBoxAccountName.Text = account.AccountName;
                    textBoxEmail.ReadOnly = true;
                    textBoxPhone.ReadOnly = true;
                    textBoxAccountName.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading account details: " + ex.Message);
            }
        }

        private void LoadOrderCreateDate(int orderId)
        {
            try
            {
                Order order = OrderDao.Instance.getById(orderId);
                if (order != null)
                {
                    textBoxCreateDate.Text = order.CreateDate.ToString("yyyy-MM-dd");
                    textBoxCreateDate.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading order create date: " + ex.Message);
            }
        }

        private void LoadOrderId(int orderId)
        {
            try
            {
                textBoxOrderId.Text = orderId.ToString();
                textBoxOrderId.ReadOnly = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading order ID: " + ex.Message);
            }
        }
    }
}
