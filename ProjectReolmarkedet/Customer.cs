using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    public class Customer
    {
		// Properties
		private int _paymentDetails;

		public int PaymentDetails
		{
			get { return _paymentDetails; }
			set { _paymentDetails = value; }
		}
		// Constructor
		public Customer(int paymentDetails) 
		{
			_paymentDetails = paymentDetails;
		}

	}
}
