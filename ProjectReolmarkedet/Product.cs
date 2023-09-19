using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;

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
        


        // Constructor
        public Product(string productName, double price)
        {
            _productName = productName;
            _price = price;
        }

        public void InsertIntoDatabase(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                // Bør også indeholde CustomerID, RackNumber og RackOwnerID, når man opretter et produkt? 

                string insertQuery = "INSERT INTO PRODUCT (ProductName, Price) VALUES (@ProductName, @Price)"; 


                using (SqlCommand command = new SqlCommand(insertQuery, connection)) {
                    command.Parameters.AddWithValue("@ProductName", _productName);
                    command.Parameters.AddWithValue("@Price", _price);
                    //command.Parameters.AddWithValue("@RackOwnerID", _rackOwnerID);
                    //command.Parameters.AddWithValue("@Rack", _rack);


                    if(command.ExecuteNonQuery() == 1) {
                        MessageBox.Show("1 row affected.");
                    }


                }

            }
        }



        //    // Skriver SQL i C#. Husk at Tabellen Flowersorts skal laves i MSSMS og have de samme colonne navne som i Flowersorts
        //    public void InsertIntoDatabase(string connectionString)
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString)) {
        //            connection.Open();

        //            string insertQuery = "INSERT INTO FlowerSort (FlowerName, ProductionTimeInDays, HalfLife, SizeInSquareMeters) VALUES (@FlowerName, @ProductionTimeInDays, @HalfLife, @SizeInSquareMeters)";

        //            using (SqlCommand command = new SqlCommand(insertQuery, connection)) {
        //                command.Parameters.AddWithValue("@FlowerName", Name);
        //                command.Parameters.AddWithValue("@ProductionTimeInDays", ProductionTime);
        //                command.Parameters.AddWithValue("@HalfLife", HalfLife);
        //                command.Parameters.AddWithValue("@SizeInSquareMeters", Size);

        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }

        //}


    }
}
