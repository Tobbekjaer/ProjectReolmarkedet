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

        public List<string> productIDs;

        // Variable to hold the receipt and call receipt dialogs constructor at inizialisation
        private string tbReceiptText; 

        public ScanItem()
        {
            productRepo = new ProductRepo();
            productIDs = new List<string>();
            InitializeComponent();
        }

        // Gets the scanned sales item from the database and displays it in the tekstbox
        public void DisplaySaleItems(string connectionString)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT WHERE ProductID = @ProductID", con);
                    cmd.Parameters.AddWithValue("@ProductID", tbProductID.Text.Trim());

                    productIDs.Add(tbProductID.Text.Trim());

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string line = "";
                        while (reader.Read())
                        {

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
                MessageBox.Show(e.Message);
            }
        }

        // Adding prices of each item together as a price total
        public void TotalPrice()
        {
            double totalPrice = 0;
            foreach (Product product in productRepo.GetProducts())
            {
                totalPrice += product.Price;
                tbTotalPrice.Text = $"{totalPrice} DKK";
            }
        }

        // When an item is scanned the item is displayed and the price is added to the price total
        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");
            DisplaySaleItems(connectionString);
            TotalPrice();
        }

        // Deletes sales items from database and displaying sold items in the receipt window
        private void DeleteItem()
        {
            try
            {
                // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
                string connectionString = config.GetConnectionString("MyDBConnection");

                using (SqlConnection con = new SqlConnection(connectionString))
                {

                    con.Open();

                    // Command to delete the product from PRODUCT 
                    SqlCommand cmdDelete = new SqlCommand("DELETE FROM PRODUCT WHERE ProductID = @ProductID", con);
                    // Command to display product info in Receipt window
                    SqlCommand cmdRead = new SqlCommand("SELECT * FROM PRODUCT WHERE ProductID = @ProductID", con);

                    // Variables to hold product info
                    string productName;
                    int price, rackNumber, rackOwner;

                    string line = "";

                    // Foreach productID in productIDs list, add it to the tbReceipt string
                    foreach (string product in productIDs)
                    {
                        // Reads the sales item with curtain ProductID from database
                        cmdRead.Parameters.AddWithValue("@ProductID", product);

                        using (SqlDataReader reader = cmdRead.ExecuteReader()) {

                            while (reader.Read()) {

                                productName = reader["ProductName"].ToString();
                                price = Convert.ToInt32(reader["Price"].ToString());
                                rackNumber = Convert.ToInt32(reader["RackNumber"].ToString());
                                rackOwner = Convert.ToInt32(reader["RackOwnerID"].ToString());

                                line += $"Produkt: {productName}, Pris: {price} kr., Reol: {price}, ReollejerID: {rackNumber}\n";
                                
                            }

                        }
                        // Deletes the sales item from the database
                        cmdDelete.Parameters.AddWithValue("@ProductID", product);
                        if(cmdDelete.ExecuteNonQuery() == productIDs.Count) {
                            MessageBox.Show($"{productIDs.Count} row(s) effected."); 
                        }
                       
                    }
                    // Adding all receipt info
                    tbReceiptText = line; 

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnEndSale_Click(object sender, RoutedEventArgs e)
        {
            // Call delete item to delete sales items from database and displaying sold items in the receipt window
            DeleteItem();
            this.Close();
            // Instantiating and opening receipt dialog with the receipt text
            Receipt receiptDialog = new Receipt(tbReceiptText);
            receiptDialog.ShowDialog();
        }

    }
}
