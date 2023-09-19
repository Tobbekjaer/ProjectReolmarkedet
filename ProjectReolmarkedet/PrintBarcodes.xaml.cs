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
    /// <summary>
    /// Interaction logic for PrintBarcodes.xaml
    /// </summary>
    public partial class PrintBarcodes : Window
    {
        public PrintBarcodes()
        {
            // Configurerer Databasen. husk at bruge de 3 using statements; System.Data; Microsoft.Extensions.Configuration.Json; Microsoft.Extensions.Configuration;
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); // Husk at selve json filen skal have navnet appsettings.json
            string connectionString = config.GetConnectionString("MyDBConnection");
            InitializeComponent();
            DisplayBarcodes(connectionString);
        }

        public void DisplayBarcodes(string connectionString)
        {

            try {
                using (SqlConnection con = new SqlConnection(connectionString)) {

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM PRODUCT", con);

                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                       
                            while (reader.Read()) {

                                string line = "";

                                int productID = Convert.ToInt32(reader["ProductID"].ToString());
                                string productName = reader["ProductName"].ToString();
                                int price = Convert.ToInt32(reader["Price"].ToString());
                                int rackNumber = Convert.ToInt32(reader["RackNumber"].ToString());

                                line += $"Stregkode: {productID}, Produkt: {productName}, Pris: {price}, Reol: {rackNumber}\n";
                               
                                tbOverview.Text += line;
                            }

                    }
                }

            } catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }



    }
}
