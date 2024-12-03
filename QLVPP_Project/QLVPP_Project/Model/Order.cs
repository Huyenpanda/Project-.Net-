using System;

namespace QLVPP_Project.Model
{
    class Order
    {
        private int orderId;
        private int accountId;
        private DateTime createDate;
        private double total;
        private int paymentId;

        public Order(int orderId, int accountId, DateTime createDate, double total, int paymentId)
        {
            this.orderId = orderId;
            this.accountId = accountId;
            this.createDate = createDate;
            this.total = total;
            this.paymentId = paymentId;
        }

        public Order(int accountId, DateTime createDate, double total, int paymentId)
        {
            this.accountId = accountId;
            this.createDate = createDate;
            this.total = total;
            this.paymentId = paymentId;
        }

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
        }
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        public int PaymentID
        {
            get { return paymentId; }
            set { paymentId = value; }
        }
    }
}
