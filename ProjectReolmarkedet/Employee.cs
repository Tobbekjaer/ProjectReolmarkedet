﻿using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

                string insertQuery = "INSERT INTO EMPLOYEE (Name, Phone, Email) VALUES (@Name, @Phone, @Email)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", _name);
                    command.Parameters.AddWithValue("@Phone", _phone);
                    command.Parameters.AddWithValue("@Email", _email);
                    
                    if(command.ExecuteNonQuery() == 1) {
						MessageBox.Show("1 row effected.");

					}
                }

            }
        }

    }
}
