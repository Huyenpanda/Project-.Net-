using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Model
{
    public class SessionManager
    {
        private int accountId = 0;

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
    }
}
