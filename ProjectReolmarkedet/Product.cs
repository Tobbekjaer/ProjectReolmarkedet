using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

namespace ProjectReolmarkedet
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int RackOwnerID { get; set; }
        public int Rack { get; set; }

        // Constructor that accepts all four arguments
        public Product(string productName, double price, int rackOwnerID, int rack)
        {
            ProductName = productName;
            Price = price;
            RackOwnerID = rackOwnerID;
            Rack = rack;
        }

        // Default constructor
        public Product()
        {
        }
    }

}
