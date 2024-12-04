using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Model
{
    class OrderDetail
    {
        private int orderDetailId;
        private int productId;
        private int quantity;
        private double total;
        private int orderId;
        private bool status;
        public OrderDetail() { }
        public OrderDetail(int orderId, int productId, int quantity, double total) {
            OrderId = orderId; 
            ProductId = productId; 
            Quantity = quantity; 
            Total = total; 
        }
        public OrderDetail(int orderDetailId, int productId, int quantity, double total, int orderId, bool status)
        {
            this.orderDetailId = orderDetailId;
            this.productId = productId;
            this.quantity = quantity;
            this.total = total;
            this.orderId = orderId;
            this.status = status;
        }

        public OrderDetail(int productId, int quantity, double total, int orderId, bool status)
        {
            this.productId = productId;
            this.quantity = quantity;
            this.total = total;
            this.orderId = orderId;
            this.status = status;
        }

        public int OrderDetailId
        {
            get { return orderDetailId; }
            set { orderDetailId = value; }
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
