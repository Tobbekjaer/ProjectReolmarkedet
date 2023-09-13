using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    public class Product
    {
		// Properties
		private string _productName;

		public string ProductName
		{
			get { return _productName; }
			set { _productName = value; }
		}
		private double _price;

		public double Price
		{
			get { return _price; }
			set { _price = value; }
		}
		private int _barcode;


		// Constructor
		public Product(string productName, double price)	
		{
			_productName = productName;
			_price = price;
		}
	}
}
