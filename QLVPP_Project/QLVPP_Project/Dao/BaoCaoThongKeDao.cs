using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVPP_Project.Dao
{
    
    class BaoCaoThongKeDao
    {

        private string connectString = ConnectionManager.getConnectString();
        private static BaoCaoThongKeDao instance;

        internal static BaoCaoThongKeDao Instance
        {
            get { if (instance == null) instance = new BaoCaoThongKeDao(); return BaoCaoThongKeDao.instance; }
            private set { BaoCaoThongKeDao.instance = value; }
        }

        public BaoCaoThongKeDao() { }

        public DataTable revenueByMonth()
        {
            string sql = @"
                SELECT 
                    MONTH(CreateDate) AS Month, 
                    SUM(Total) AS Revenue
                FROM [Order]
                GROUP BY MONTH(CreateDate)
                ORDER BY Month;
            ";
            DataTable dt = new DataTable();
            using (SqlConnection connect = new SqlConnection(connectString))
            {
                SqlCommand cmd = new SqlCommand(sql, connect);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                
                try
                {
                    connect.Open();
                    adapter.Fill(dt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error BaoCaoTKDao: " + ex);
                }
            }
            return dt;
        }

        public DataTable getTopSaleProduct()
        {
            string query = @"
        WITH ProductSales AS (
            SELECT 
                p.ProductName, 
                SUM(od.Quantity) AS TotalQuantity
            FROM 
                OrderDetail od
            INNER JOIN 
                Product p ON od.ProductId = p.ProductId
            GROUP BY 
                p.ProductName
        ), RankedProducts AS (
            SELECT 
                ProductName, 
                TotalQuantity,
                ROW_NUMBER() OVER (ORDER BY TotalQuantity DESC) AS Rank
            FROM 
                ProductSales
        )
        SELECT 
            CASE 
                WHEN Rank <= 5 THEN ProductName
                ELSE 'Other'
            END AS ProductGroup,
            SUM(TotalQuantity) AS TotalQuantity
        FROM 
            RankedProducts
        GROUP BY 
            CASE 
                WHEN Rank <= 5 THEN ProductName
                ELSE 'Other'
            END;";

            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;

        }

    }
}
