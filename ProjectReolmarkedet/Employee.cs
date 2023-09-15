using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectReolmarkedet
{
    public class Employee
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

		// Constructor
		public Employee(string name, int phone, string email)
		{
			_name = name;
			_phone = phone;
			_email = email;
		}

      

        public void InsertIntoDatabase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO PRODUCT (Employee) VALUES (@Employee)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Employee", _name);
                    command.Parameters.AddWithValue("@Employee", _phone);
                    command.Parameters.AddWithValue("@Employee", _email);
                }

            }
        }

    }
}
