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
        // Privat list of employee
        private List<Employee> _employee = new List<Employee>();

        // Public list, to get or set employee from the private list
        public List<Employee> Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }

        // AddEmployee() method adds a new Rack to the list
        public void AddEmployee(Employee employee)
        {
            _employee.Add(employee);

            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");

            employee.InsertIntoDatabase(connectionString);
        }
    }
}
