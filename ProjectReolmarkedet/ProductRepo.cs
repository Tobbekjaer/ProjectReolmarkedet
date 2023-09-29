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
       
        private List<Product> _products = new List<Product>();

        
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

       
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

