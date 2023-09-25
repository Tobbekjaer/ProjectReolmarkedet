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
    /// Interaction logic for Receipt.xaml
    /// </summary>
    public partial class Receipt : Window
    {
        public Receipt(string tbReceipt)
        {
            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");
            InitializeComponent();
            DisplayReceipt(tbReceipt);
        }

        // Displaying the receipt in the receipt dialog window
        public void DisplayReceipt(string salesItem)
        {
            tbReceipt.Text += salesItem;
        }

        private void PrintReceipt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
