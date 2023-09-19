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

            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string connectionString = config.GetConnectionString("MyDBConnection");

            try
            {
                employee.InsertIntoDatabase(connectionString);
            }
            catch (Exception ex)
            {
                // Handle database-related exceptions here (e.g., log or report the error).
                // You can also consider rolling back the operation if the database insertion fails.
            }



            /*
            // AddEmployee() method adds a new Rack to the list
            public void AddEmployee(Employee employee)
            {
                _employee.Add(employee);

                // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
                string connectionString = config.GetConnectionString("MyDBConnection");

                employee.InsertIntoDatabase(connectionString);
            } */
        }
    }

}
