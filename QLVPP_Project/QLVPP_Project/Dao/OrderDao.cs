using System;
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
                        (int)reader["OrderId"],
                        (int)reader["AccountId"],
                        (DateTime)reader["CreateDate"],
                        (double)reader["Total"],
                        (int)reader["PaymentId"]
                    );
                }
                conn.Close();
            }
            return order;
        }

        public bool Insert(Order order)
        {
            // Implement the insert logic here
            return true;
        }

        public bool Update(Order order)
        {
            // Implement the update logic here
            return true;
        }

        public bool Delete(int id)
        {
            // Implement the delete logic here
            return true;
        }
    }
}
