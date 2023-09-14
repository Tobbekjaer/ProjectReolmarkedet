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
        public MainWindow()
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the dialog window
            RegisterProductDialog dialog = new RegisterProductDialog();

            // Bør også indeholde CustomerID, RackNumber og RackOwnerID, når man opretter et produkt? 
            if (dialog.ShowDialog() == true ) {
                Product product = new Product(dialog.tbProduct.Text, Convert.ToInt32(dialog.tbPrice.Text));
            }

            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");




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

    }
}
