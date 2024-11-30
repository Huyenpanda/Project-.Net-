using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Dao
{
    public static class ConnectionManager
    {
        //private static readonly string connectString = "Data Source=JERRY\\SQLEXPRESS;Initial Catalog=VanPhongPham;UserID=sa;Password=1234$;TrustServerCertificate=True";
        private static readonly string connectString = "Data Source=LAPTOP-8BGH2AU5\\SQLEXPRESS;Initial Catalog=VanPhongPham;User ID=sa;Password=1235;TrustServerCertificate=True";
        public static string getConnectString()
        {
            return connectString;
        }
    }
}
