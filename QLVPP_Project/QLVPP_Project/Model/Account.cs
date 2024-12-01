using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Model
{
    class Account
    {
        private int accountId;
        private string accountName;
        private string role;
        private string username;
        private string password;
        private string email;
        private string phone;

        public Account(int accountId, string accountName, string role, string username, string password, string email, string phone)
        {
            this.accountId = accountId;
            this.accountName = accountName;
            this.role = role;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
        }

        public Account(string accountName, string role, string username, string password, string email, string phone)
        {
            this.accountName = accountName;
            this.role = role;
            this.username = username;
            this.password = password;
            this.email = email;
            this.phone = phone;
        }

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string PassWord
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }



    }
}
