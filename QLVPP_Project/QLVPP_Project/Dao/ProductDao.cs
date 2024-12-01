using QLVPP_Project.Model;
using System;
using System.Data.SqlClient;
using System.Data;

namespace QLVPP_Project.Dao
{
    class ProductDao : ModelDao<Product>
    {
        string connectString = ConnectionManager.getConnectString();

        private static ProductDao instance;

        public static ProductDao Instance 
        {
            get {if (instance == null) instance = new ProductDao(); return ProductDao.instance; }
            private set { ProductDao.instance = value; }
            
        }
        public ProductDao() { }

        public DataTable getAll()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "Select * from Product";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }


        public Product getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Product model)
        {
            return false;
        }

        public bool Update(Product model)
        {
            throw new NotImplementedException();
        }
        public bool Delete(int id)
        {
            return false;
        }
    }
}
