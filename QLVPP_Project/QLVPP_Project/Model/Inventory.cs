using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Model
{
    class Inventory
    {
        private int inventoryId;
        private int productId;
        private int quanitity;

        public Inventory(int inventoryId, int productId, int quanitity)
        {
            this.inventoryId = inventoryId;
            this.productId = productId;
            this.quanitity = quanitity;
        }

        public Inventory(int productId, int quanitity)
        {
            this.productId = productId;
            this.quanitity = quanitity;
        }

        public int InventoryId 
        { 
            get { return inventoryId; } 
            set { inventoryId = value; }
        }
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }
        public int Quantity
        {
            get { return quanitity; }
            set { quanitity = value; }
        }


    }
}
