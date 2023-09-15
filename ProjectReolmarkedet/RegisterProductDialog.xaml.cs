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
    /// <summary>
    /// Interaction logic for RegisterProductDialog.xaml
    /// </summary>
    public partial class RegisterProductDialog : Window
    {

        ProductRepo productRepo;
        public RegisterProductDialog()
        {
            productRepo = new ProductRepo();
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Bør også indeholde CustomerID, RackNumber og RackOwnerID, når man opretter et produkt? 
            try {
                if (string.IsNullOrEmpty(Convert.ToString(tbProduct.Text)) || string.IsNullOrEmpty(Convert.ToString(tbPrice.Text)) ||
                    string.IsNullOrEmpty(Convert.ToString(tbRackOwnerID.Text)) || string.IsNullOrEmpty(Convert.ToString(tbRack.Text))) {
                    MessageBox.Show("Alle felter skal være udfyldt");

                    // Bør også indeholde CustomerID, RackNumber og RackOwnerID, når man opretter et produkt? 
                   
                        Product product = new Product(
                            tbProduct.Text,
                            Convert.ToInt32(tbPrice.Text)
                            );
                        productRepo.AddProduct(product);

                        // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
                        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
                        string connectionString = config.GetConnectionString("MyDBConnection");
                        

                        using (SqlConnection connection = new SqlConnection(connectionString)) {
                            connection.Open();

                            // Bør også indeholde CustomerID, RackNumber og RackOwnerID, når man opretter et produkt? 
                            string insertQuery = "INSERT INTO PRODUCT (ProductName, Price, RackOwnerID, Rack) VALUES (@ProductName, @Price, @RackOwnerID, @RackNumber)";

                            using (SqlCommand command = new SqlCommand(insertQuery, connection)) {
                                command.Parameters.AddWithValue("@ProductName", tbProduct.Text);
                                command.Parameters.AddWithValue("@Price", Convert.ToDouble(tbPrice.Text));
                                command.Parameters.AddWithValue("@RackOwnerID", Convert.ToInt32(tbRackOwnerID.Text));
                                command.Parameters.AddWithValue("@RackNumber", Convert.ToInt32(tbRack.Text));

                                if (command.ExecuteNonQuery() == 1) {
                                    MessageBox.Show("1 row affected.");
                                }
                            }

                        }
                    }
                    else {
                        
                        this.DialogResult = true;
                    }
                
            }
            catch (Exception ex) {
                // Handle the exception here, e.g. display an error message to the user
                MessageBox.Show("Der opstod en fejl: " + ex.Message);
            }
        }



        public void AddToTextBlock()
        {

            string line = "";

            foreach (Product product in productRepo.Products) {
                line += $"{product.ProductName}, {product.Price}\n";
            }

            tbProductList.Text = line;
        }

        private void btnAfslut_Click(object sender, RoutedEventArgs e)
        {
            btnAfslut.IsCancel = true;
        }
    }
}
