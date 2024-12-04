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

        private static AccountDao instance;

        public static AccountDao Instance
        {
            get { if (instance == null) instance = new AccountDao(); return AccountDao.instance; }
            private set { AccountDao.instance = value; }
        }
        public DataTable getAll()
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "Select * from Account";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(data);
                conn.Close();
            }
            return data;
        }


            // Thêm phương thức GetUserNameById
            public string GetUserNameById(int accountId)
            {
                string userName = null;
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = "SELECT UserName FROM Account WHERE AccountId = @AccountId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userName = reader["UserName"].ToString();
                    }
                    conn.Close();
                }
                return userName;
            }

            // Thêm phương thức getAccountById
            public Account getAccountById(int accountId)
            {
                Account account = null;
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM Account WHERE AccountId = @AccountId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        account = new Account
                        {
                            AccountId = (int)reader["AccountId"],
                            AccountName = reader["AccountName"].ToString(),
                            UserName = reader["UserName"].ToString(),
                            PassWord = reader["PassWord"].ToString(),
                            Email = reader["Email"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Role = reader["Role"].ToString()
                        };
                    }
                    conn.Close();
                }
                return account;
            }


    public bool Insert(Account acc)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO Account (AccountName, Role, Username, Password, Email, Phone) " +
                                 "VALUES (@AccName, @Role, @Username, @Password, @Email, @Phone)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AccName", acc.AccountName);
                    cmd.Parameters.AddWithValue("@Role", acc.Role);
                    cmd.Parameters.AddWithValue("@Username", acc.UserName);
                    cmd.Parameters.AddWithValue("@Password", acc.PassWord);
                    cmd.Parameters.AddWithValue("@Email", acc.Email);
                    cmd.Parameters.AddWithValue("@Phone", acc.Phone);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erorr AccountDao: {ex.Message}");
                    return false;
                }
            }
        }

        public bool Delete(int accId)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "DELETE FROM Account WHERE AccountId = @AccId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@AccId", accId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error AccountDao: {ex.Message}");
                    return false;
                }
            }
        }
        public bool UpdateContactInfo(int accountId, string phone, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Account SET Phone = @Phone, Email = @Email WHERE AccountId = @AccountId";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@AccountId", accountId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error AccountDao.UpdateContactInfo: {ex.Message}");
                    return false;
                }
            }
        }

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


        public DataTable searchByRoleOrAccountName(string role,string accName)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                try
                {
                    conn.Open();
                    StringBuilder sql = new StringBuilder("SELECT * FROM Account WHERE 1=1");

                    // Kiểm tra giá trị role và accName
                    if (!string.IsNullOrEmpty(role))
                    {
                        sql.Append(" AND Role = @Role");
                    }
                    if (!string.IsNullOrEmpty(accName))
                    {
                        sql.Append(" AND AccountName LIKE @AccountName");
                    }

                    using (SqlCommand cmd = new SqlCommand(sql.ToString(), conn))
                    {
                        // Gán tham số nếu có giá trị
                        if (!string.IsNullOrEmpty(role))
                        {
                            cmd.Parameters.AddWithValue("@Role", role);
                        }
                        if (!string.IsNullOrEmpty(accName))
                        {
                            cmd.Parameters.AddWithValue("@AccountName", $"%{accName}%");
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(data);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error AccountDao: {ex.Message}");
                }
                finally
                {
                    conn.Close();
                }
            }
            return data;
        }
        public int GetAccountIdByName(string accountName)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string sql = "SELECT AccountId FROM Account WHERE AccountName = @AccountName";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@AccountName", accountName);
                object result = cmd.ExecuteScalar();
                conn.Close();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
                return -1; // Không tìm thấy tài khoản
            }
        }





    }
}
