using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QLVPP_Project.Model;

namespace QLVPP_Project.Dao
{
    class OrderDao : ModelDao<Order>
    {
        string connectString = ConnectionManager.getConnectString();

        private static OrderDao instance;

        public static OrderDao Instance
        {
            get { if (instance == null) instance = new OrderDao(); return OrderDao.instance; }
            private set { OrderDao.instance = value; }
        }

        public OrderDao() { }

        public DataTable getAll()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT o.OrderId, o.CreateDate, a.Username, od.Status, o.Total " +
                             "FROM [Order] o " +
                             "JOIN [Account] a ON o.AccountId = a.AccountId " +
                             "JOIN [OrderDetail] od ON o.OrderId = od.OrderId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }

        public Order getById(int id)
        {
            Order order = null;
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT * FROM [Order] WHERE OrderId = @OrderId";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@OrderId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    order = new Order(
                        reader.GetInt32(reader.GetOrdinal("OrderId")),
                        reader.GetInt32(reader.GetOrdinal("AccountId")),
                        reader.GetDateTime(reader.GetOrdinal("CreateDate")),
                        reader.GetDecimal(reader.GetOrdinal("Total")),
                        reader.GetInt32(reader.GetOrdinal("PaymentId"))
                    );
                }
                conn.Close();
            }
            return order;
        }

        public bool Insert(Order order)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO [Order] (AccountId, CreateDate, Total, PaymentId) " +
                                 "VALUES (@AccountId, @CreateDate, @Total, @PaymentId); " +
                                 "SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AccountId", order.AccountId);
                    cmd.Parameters.AddWithValue("@CreateDate", order.CreateDate);
                    cmd.Parameters.AddWithValue("@Total", order.Total);
                    cmd.Parameters.AddWithValue("@PaymentId", order.PaymentId);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        order.OrderId = Convert.ToInt32(result);
                        Console.WriteLine($"New OrderId: {order.OrderId}"); // Log OrderId
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve OrderId.");
                    }
/*
                    if (result != null)
                    {
                        order.OrderId = Convert.ToInt32(result);
                        return true;
                    }*/
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error OrderDao: {ex.Message}");
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
                    string sql = "DELETE FROM [Order] WHERE OrderId = @OrderId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in OrderDao.Delete: {ex.Message}");
                    return false;
                }
            }
        }
        public bool DeleteOrders(List<int> orderIds)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();

                    // Tạo chuỗi lệnh SQL
                    string orderIdsString = string.Join(",", orderIds);
                    string sql = $"DELETE FROM [OrderDetail] WHERE OrderId IN ({orderIdsString}); " +
                                 $"DELETE FROM [Order] WHERE OrderId IN ({orderIdsString});";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    conn.Close();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting orders: " + ex.Message);
                    return false;
                }
            }
        }



        public bool Update(Order order)
        {
            // Implement the update logic here
            return true;
        }

    }

}
