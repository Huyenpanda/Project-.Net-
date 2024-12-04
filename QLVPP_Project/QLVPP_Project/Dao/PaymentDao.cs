using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLVPP_Project.Model;

namespace QLVPP_Project.Dao
{
    class PaymentDao : ModelDao<Payment>
    {
        string connectString = ConnectionManager.getConnectString();

        private static PaymentDao instance;

        public static PaymentDao Instance
        {
            get { if (instance == null) instance = new PaymentDao(); return PaymentDao.instance; }
            private set { PaymentDao.instance = value; }
        }

        public PaymentDao() { }

        public DataTable getAll()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT PaymentId, PaymentMethod FROM Payment";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }


        public bool Insert(Payment order)
        {
            // Implement the insert logic here
            return true;
        }

        public bool Update(Payment order)
        {
            // Implement the update logic here
            return true;
        }

        public bool Delete(int id)
        {
            // Implement the delete logic here
            return true;
        }

        public Payment getById(int id)
        {
            throw new NotImplementedException();
        }
    }

}
