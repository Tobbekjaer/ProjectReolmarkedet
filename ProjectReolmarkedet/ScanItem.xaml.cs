using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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

namespace ProjectReolmarkedet
{
    /// <summary>
    /// Interaction logic for ScanItem.xaml
    /// </summary>
    public partial class ScanItem : Window
    {
        ProductRepo productRepo;

        public ScanItem()
        {
            productRepo = new ProductRepo();
            InitializeComponent();
        }



        public void DisplaySaleItems(string connectionString)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT WHERE ProductID = @ProductID", con);
                    cmd.Parameters.AddWithValue("@ProductID", tbProductID.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string line = "";
                        while (reader.Read())
                        {
                            // Skal vi også have employee navn?
                            Product product = new Product(
                                reader["ProductName"].ToString(), 
                                Convert.ToDouble(reader["Price"].ToString())
                                );
                            productRepo.AddProduct(product);

                            line += $"Produkt: {product.ProductName}, Pris: {product.Price}\n";

                            tbSaleList.Text += line;
                        }

                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void TotalPrice()
        {
            double totalPrice = 0;
            foreach (Product product in productRepo.GetProducts())
            {
                totalPrice += product.Price;
                tbTotalPrice.Text = $"{totalPrice} DKK";
            }
        }

        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");
            DisplaySaleItems(connectionString);
            TotalPrice();
        }
    }
}
