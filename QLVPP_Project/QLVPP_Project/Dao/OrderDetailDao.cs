using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLVPP_Project.Model;

namespace QLVPP_Project.Dao
{
    class OrderDetailDao : ModelDao<OrderDetail>
    {
        string connectString = ConnectionManager.getConnectString();

        private static OrderDetailDao instance;

        public static OrderDetailDao Instance
        {
            get { if (instance == null) instance = new OrderDetailDao(); return OrderDetailDao.instance; }
            private set { OrderDetailDao.instance = value; }
        }

        public OrderDetailDao() { }


        public DataTable getAll()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT od.OrderDetailId, od.ProductId, od.Quantity, od.Total, od.OrderId, od.Status " +
                             "FROM [OrderDetail] od";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }
        public DataTable getByOrderId(int orderId)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = @"
            SELECT 
                od.ProductId,
                p.ProductName,
                od.Quantity,
                p.Price,
                (od.Quantity * p.Price) AS Total
            FROM OrderDetail od
            INNER JOIN Product p ON od.ProductId = p.ProductId
            WHERE od.OrderId = @OrderId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }
        public DataTable getOrderDetailByOrderId(int orderId)
        {
            DataTable data = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = @"
                SELECT od.OrderDetailId,od.OrderId, od.ProductId, p.ProductName, p.Price, od.Quantity, od.Total,  od.Status 
                FROM OrderDetail od
                JOIN Product p ON od.ProductId = p.ProductId
                WHERE od.OrderId = @OrderId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(data);
                    conn.Close();
                }

                if (data.Rows.Count > 0)
                {
                    Console.WriteLine("Data loaded successfully!");
                }
                else
                {
                    Console.WriteLine("No data found for this OrderId!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }

            return data;
        }

        public bool Insert(OrderDetail model)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();

                    // Kiểm tra ProductId có tồn tại trong bảng Product
                    string checkProductSql = "SELECT COUNT(1) FROM Product WHERE ProductId = @ProductId";
                    SqlCommand checkProductCmd = new SqlCommand(checkProductSql, conn);
                    checkProductCmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                    int productExists = (int)checkProductCmd.ExecuteScalar();

                    if (productExists == 0)
                    {
                        MessageBox.Show($"ProductId {model.ProductId} không tồn tại trong bảng Product.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    // Chèn dữ liệu vào OrderDetail
                    string sql = "INSERT INTO OrderDetail (OrderId, ProductId, Quantity, Total, Status) " +
                                 "VALUES (@OrderId, @ProductId, @Quantity, @Total, @Status)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OrderId", model.OrderId);
                    cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                    cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
                    cmd.Parameters.AddWithValue("@Total", model.Total);
                    cmd.Parameters.AddWithValue("@Status", model.Status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error OrderDetailDao: {ex.Message}");
                    MessageBox.Show($"Error: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool Delete(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM [OrderDetail] WHERE OrderId = @OrderId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in OrderDetailDao.DeleteByOrderId: {ex.Message}");
                    return false;
                }
            }
        }
        /*  public DataTable getByOrderId(int orderId)
          {
              DataTable data = new DataTable();
              using (SqlConnection conn = new SqlConnection(connectString))
              {
                  conn.Open();
                  string sql = "SELECT * FROM OrderDetail WHERE OrderId = @OrderId";
                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.Parameters.AddWithValue("@OrderId", orderId);
                  SqlDataAdapter adap = new SqlDataAdapter(cmd);
                  adap.Fill(data);
                  conn.Close();
              }
              return data;
          }
*/
        public OrderDetail getById(int id)
        {
            throw new NotImplementedException();
        }



        public bool Update(OrderDetail model)
        {
            throw new NotImplementedException();
        }


    }
}
