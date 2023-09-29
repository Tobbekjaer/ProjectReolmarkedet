using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjectReolmarkedet
{
    public partial class PrintBarcodes : Window
    {
        private List<int> productIDs; // List to store the ProductIDs
        private string connectionString; // Connection string for database

        public PrintBarcodes(List<int> productIDs)
        {
            this.productIDs = productIDs; // Initialize the list of ProductIDs from the constructor parameter

            // Load the database connection string from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");

            InitializeComponent();
            DisplayBarcodeDetails(); // Display barcode details when the window is initialized
        }
        
        public void DisplayBarcodeDetails()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Build a SQL query to retrieve details for products with specified ProductIDs
                    string query = "SELECT * FROM PRODUCT WHERE ProductID IN (" +
                                 string.Join(",", productIDs) + ")";
                    SqlCommand cmd = new SqlCommand(query, con);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string line = "";

                            int retrievedProductID = Convert.ToInt32(reader["ProductID"].ToString());
                            string productName = reader["ProductName"].ToString();
                            double price = Convert.ToDouble(reader["Price"].ToString());
                            int rackNumber = Convert.ToInt32(reader["RackNumber"].ToString());

                            // Format and display product details
                            line += $"Stregkode: {retrievedProductID}, Produkt: {productName}, Pris: {price}, Reol: {rackNumber}\n";

                            tbOverview.Text += line; // Append the details to the text block
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred: " + e.Message);
            }
        }
    }
}
