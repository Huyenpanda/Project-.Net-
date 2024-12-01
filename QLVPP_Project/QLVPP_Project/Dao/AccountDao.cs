using QLVPP_Project.Model;
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
    class AccountDao 
    {
        string connectString = ConnectionManager.getConnectString();
        public bool checkLogin(string username,string pass)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                    Select * 
                    from Account
                    where 
                    Username = @un and Password = @pc";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@un", username);

                        cmd.Parameters.AddWithValue("@pc", new Cypher().cypherSHA1(pass));
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                return true;
                            else
                                return false;
                        }

                    }
                }
                catch (Exception ex) { 
                    Console.WriteLine("Error AccountDao: "+ ex.Message);
                    return false;
                }

                
            }
        }


        public bool isAdminOrStaff(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = @"
                    Select * 
                    from Account 
                    where Username = @un";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@un", username);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string role = reader["Role"].ToString();
                                
                                return role.Equals("admin", StringComparison.OrdinalIgnoreCase);
                            }
                            else
                            {
                                
                                return false;
                            }
                               
                            
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error AccountDao: " + ex.Message);
                    return false;
                }


            }
        }



        


    }
}
