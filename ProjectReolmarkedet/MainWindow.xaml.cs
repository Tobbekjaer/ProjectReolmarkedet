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
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the dialog window
            RegisterProductDialog dialog = new RegisterProductDialog();
            dialog.ShowDialog();
                
        }

        private void Sale_Button(object sender, RoutedEventArgs e)
        {
            // Create an instance of the dialog window
            ScanItem dialog = new ScanItem();
            dialog.ShowDialog();
        }


        }
}
