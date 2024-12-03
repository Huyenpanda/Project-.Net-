using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLVPP_Project.Model
{
    public class Product
    {
        private int productId;
        private string productName;
        private string description;
        private double price;
        private string unit;
        private string imgUrl;
        private int categoryId;
        public string CategoryName { get; set; }

        public Product(int productId, string productName, string description, double price, string unit, string imgUrl, int categoryId, string categoryName)
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            Price = price;
            Unit = unit;
            ImgUrl = imgUrl;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
        public Product()
        {
        }
        public Product(int productId,string productName, string description, double price, string unit, string imgUrl, int categoryId)
        {
            ProductId = productId;
            ProductName = productName;
            Description = description;
            Price = price;
            Unit = unit;
            ImgUrl = imgUrl;
            CategoryId = categoryId;
        }

        public Product(string productName, string description, double price, string unit, string IMGUrl, int categoryId)
        {
            this.productName = productName;
            this.description = description;
            this.price = price;
            this.unit = unit;
            imgUrl = IMGUrl;
            this.categoryId = categoryId;
        }

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        { 
            get  { return productName; } 
            set { productName = value; } 
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public double Price
        { 
            get { return price; } 
            set { price = value; } 
        }
        public string Unit
        { 
            get { return unit; } 
            set { unit = value; } 
        }

        public string ImgUrl
        { 
            get { return imgUrl; } 
            set { imgUrl = value; } 
        }
        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }
        

    }
}
