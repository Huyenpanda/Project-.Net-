using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Model
{
    class Cypher
    {
        public string cypherSHA1(string pass)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(pass));
                StringBuilder hashStringBuider = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuider.Append(b.ToString("x2"));
                }
                return hashStringBuider.ToString().ToUpper();
            }
        }
    }

}
