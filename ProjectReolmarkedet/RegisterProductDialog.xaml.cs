using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
using System.Xml.Linq;

namespace ProjectReolmarkedet
{
    public partial class RegisterProductDialog : Window
    {
        ProductRepo productRepo; // Instance of ProductRepo to manage products
        private string connectionString; // Connection string for database
        private List<int> productIDs = new List<int>(); // List to store generated ProductIDs

        public RegisterProductDialog()
        {
            productRepo = new ProductRepo(); // Initialize the ProductRepo instance

            // Load the database connection string from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");

            InitializeComponent();
        }

        private void ClearProduct()
        {
            // Clear input fields
            tbProduct.Clear();
            tbPrice.Clear();
            tbRackOwnerID.Clear();
            tbRack.Clear();
        }

        private void AddToTextBlock()
        {
            string line = "";

            // Generate a formatted string with product information and display it in the text block
            foreach (Product product in productRepo.Products)
            {
                line += $"{product.ProductName}, {product.Price}\n";
            }

            tbProductList.Text = line;
        }

        private void AddProductToDatabase(Product product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Create an INSERT command to add the product to the database and retrieve the generated ProductID
                    SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCT (ProductName, Price) VALUES (@ProductName, @Price); SELECT SCOPE_IDENTITY();", con);
                    cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                    cmd.Parameters.AddWithValue("@Price", product.Price);

                    // Execute the command and get the generated ProductID
                    int generatedProductID = Convert.ToInt32(cmd.ExecuteScalar());

                    // Optionally, you can store the generatedProductID or perform other actions here

                    productIDs.Add(generatedProductID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the product to the database: " + ex.Message);
            }
        }

        // Helper method to check if the RackOwnerID exists in the database
        private bool RackOwnerExists(int rackOwnerID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM RackOwner WHERE RackOwnerID = @RackOwnerID", con);
                    cmd.Parameters.AddWithValue("@RackOwnerID", rackOwnerID);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while checking RackOwnerID existence: " + ex.Message);
                return false;
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Convert.ToString(tbProduct.Text)) || string.IsNullOrEmpty(Convert.ToString(tbPrice.Text)) ||
                    string.IsNullOrEmpty(Convert.ToString(tbRackOwnerID.Text)) || string.IsNullOrEmpty(Convert.ToString(tbRack.Text)))
                {
                    MessageBox.Show("Alle felter skal være udfyldt");
                    return;
                }

                // Parse input fields to create a new Product instance
                int rackOwnerID = Convert.ToInt32(tbRackOwnerID.Text);
                if (!RackOwnerExists(rackOwnerID))
                {
                    MessageBox.Show("Den indtastede RackOwnerID findes ikke i databasen.");
                    return;
                }

                Product product = new Product(
                    tbProduct.Text,
                    Convert.ToDouble(tbPrice.Text),
                    rackOwnerID,
                    Convert.ToInt32(tbRack.Text)
                );

                // Add the product to the database
                AddProductToDatabase(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Der opstod en fejl: " + ex.Message);
            }
            finally
            {
                ClearProduct();
                AddToTextBlock();
            }
        }

        private int GetGeneratedProductID()
        {
            int generatedProductID = -1;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('PRODUCT') AS LastProductID", con);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            generatedProductID = Convert.ToInt32(reader["LastProductID"]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return generatedProductID;
        }

        private void btnAfslut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();

                // Open the PrintBarcodes window and pass the list of generated ProductIDs
                PrintBarcodes dialog = new PrintBarcodes(productIDs);
                dialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}

