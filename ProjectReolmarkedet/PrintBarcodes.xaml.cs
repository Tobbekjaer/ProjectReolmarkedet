using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Interaction logic for PrintBarcodes.xaml
    /// </summary>
    public partial class PrintBarcodes : Window
    {
        public PrintBarcodes()
        {

            InitializeComponent();
        }

        public void DisplayBarcodes(string connectionString)
        {



            //string ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString;

            //try {
            //    using (SqlConnection con = new SqlConnection(ConnectionString)) {

            //        con.Open();

            //        SqlCommand cmd = new SqlCommand("SELECT FlowerName, ProductionTimeInDays, HalfLife, SizeInSquareMeters FROM FlowerSort", con);

            //        using (SqlDataReader reader = cmd.ExecuteReader()) {
            //            while (reader.Read()) {

            //                string line = "";

            //                foreach (DbDataRecord row in reader) {

            //                    string flowerName = reader["FlowerName"].ToString();
            //                    int productionTime = int.Parse(reader["ProductionTimeInDays"].ToString());
            //                    int halfLife = int.Parse(reader["HalfLife"].ToString());
            //                    double size = double.Parse(reader["SizeInSquareMeters"].ToString());

            //                    line += $"{flowerName}, {productionTime}, {halfLife}, {size}\n";

            //                }

            //                tbSorts.Text = line;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}

        }


    }
}
