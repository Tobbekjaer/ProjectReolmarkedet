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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Data.SqlClient; 
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

namespace ProjectReolmarkedet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Create an instance of the dialog window
        // ProductRepo productRepo;
        public MainWindow()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");
            // productRepo = new ProductRepo();
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the dialog window
            RegisterProductDialog dialog = new RegisterProductDialog();
            dialog.ShowDialog();
           
           
                
            //// Bør også indeholde CustomerID, RackNumber og RackOwnerID, når man opretter et produkt? 
            //if (dialog.ShowDialog() == true) {
            //    Product product = new Product(
            //        dialog.tbProduct.Text,
            //        Convert.ToInt32(dialog.tbPrice.Text)
            //        );
            //    productRepo.AddProduct(product);

            //    // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            //    IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            //    string connectionString = config.GetConnectionString("MyDBConnection");


            //    using (SqlConnection connection = new SqlConnection(connectionString)) {
            //        connection.Open();

            //        // Bør også indeholde CustomerID, RackNumber og RackOwnerID, når man opretter et produkt? 
            //        string insertQuery = "INSERT INTO PRODUCT (ProductName, Price, RackOwnerID, Rack) VALUES (@ProductName, @Price, @RackOwnerID, @RackNumber)";

            //        using (SqlCommand command = new SqlCommand(insertQuery, connection)) {
            //            command.Parameters.AddWithValue("@ProductName", dialog.tbProduct.Text);
            //            command.Parameters.AddWithValue("@Price", Convert.ToDouble(dialog.tbPrice.Text));
            //            command.Parameters.AddWithValue("@RackOwnerID", Convert.ToInt32(dialog.tbRackOwnerID.Text));
            //            command.Parameters.AddWithValue("@RackNumber", Convert.ToInt32(dialog.tbRack.Text));

            //            if (command.ExecuteNonQuery() == 1) {
            //                MessageBox.Show("1 row affected.");
            //            }
            //        }

                
        }

        

        //if (dialog.ShowDialog() == true) {
        //    Flowersort flowersort = new Flowersort(
        //    dialog.tbName.Text,
        //    Convert.ToInt32(dialog.tbProductionTime.Text),
        //    Convert.ToInt32(dialog.tbHalfLife.Text),
        //    Convert.ToDouble(dialog.tbSize.Text));

        //    // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
        //    IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
        //    string connectionString = config.GetConnectionString("MyDBConnection");

        //    // kaller metoden og Gemmer informationen i databsen
        //    flowersort.InsertIntoDatabase(connectionString);

        //    flowersorts.Add(flowersort);
        //}
        //AddToTextBlock();


        //public void AddToTextBlock()
        //{
            
        //    RegisterProductDialog registerProductDialog = new RegisterProductDialog();
        //    string line = ""; 

        //    foreach(Product product in productRepo.Products) {
        //        line += $"{product.ProductName}, {product.Price}\n";
        //    }

        //    registerProductDialog.tbProductList.Text = line;
        //}

        //public void AddToTextBlock()
        //{
        //    string line = "";

        //    foreach (Flowersort flowersort in flowersorts) {
        //        line += $"{flowersort.Name}, {flowersort.ProductionTime}, {flowersort.HalfLife}, {flowersort.Size}\n";
        //    }
        //    tbSorter.Text = line;
        //}


    }
}
