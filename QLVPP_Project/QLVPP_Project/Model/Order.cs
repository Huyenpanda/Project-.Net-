using System;
namespace QLVPP_Project.Model
{
    class Order
    {
        private int orderId;
        private int accountId;
        private DateTime createDate;
        private decimal total;
        private int paymentId;

        public Order() { }

        public Order(int orderId, int accountId, DateTime createDate, decimal total, int paymentId)
        {
            this.orderId = orderId;
            this.accountId = accountId;
            this.createDate = createDate;
            this.total = total;
            this.paymentId = paymentId;
        }

        public Order(int accountId, DateTime createDate, decimal total, int paymentId)
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
        public decimal Total
        {
            get { return total; }
            set { total = value; }
        }
        public int PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }
    }
}
