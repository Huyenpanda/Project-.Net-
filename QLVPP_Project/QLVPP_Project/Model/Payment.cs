using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Model
{
    class Payment
    {
        private int paymentId;
        private string paymentMethod;

        public Payment(int paymentId, string paymentMethod)
        {
            this.paymentId = paymentId;
            this.paymentMethod = paymentMethod;
        }

        public Payment(string paymentMethod)
        {
            this.paymentMethod = paymentMethod;
        }

        public int PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }
        public string PaymentMethod
        { 
            get { return paymentMethod; } 
            set { paymentMethod = value; } 
        }
    }
}
