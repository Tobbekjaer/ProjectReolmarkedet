using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    public class CustomerRepo
    {
        // Privat list of customers
        private List<Customer> _customers = new List<Customer>();

        // Public list, to get or set customer from the private list
        public List<Customer> Customer
        {
            get { return _customers; }
            set { _customers = value; }
        }

        // AddCustomer() method adds a new customer to the list
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}

