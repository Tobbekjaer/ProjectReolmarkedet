using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    class EmployeeRepo
    {
        // Private list of employees
        private List<Employee> _employees = new List<Employee>();

        // Public property to get or set employees from the private list
        public List<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee); 
        }
    }

}
