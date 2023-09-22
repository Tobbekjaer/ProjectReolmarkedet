using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    public class ProductRepo
    {
        // Privat list of products
        private List<Product> _products = new List<Product>();

        // Public list, to get or set products from the private list
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        // AddProduct() method adds a new product to the list
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }


        public List<Product> GetProducts()
        {
            return _products;
        }



    }

}

