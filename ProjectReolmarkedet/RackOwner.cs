using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    public class RackOwner
    {
		// Properties
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		private int _phone;

		public int Phone
		{
			get { return _phone; }
			set { _phone = value; }
		}
		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		private string _bankDetails;

		public string BankDetails
		{
			get { return _bankDetails; }
			set { _bankDetails = value; }
		}

		// Constructor
		public RackOwner(string name, int phone, string email, string bankDetails)
		{
			_name = name;
			_phone = phone;
			_email = email;
			_bankDetails = bankDetails;
		}

	}
}
