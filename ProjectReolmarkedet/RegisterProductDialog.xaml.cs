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
        public RegisterProductDialog()
        {
            InitializeComponent();
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (string.IsNullOrEmpty(Convert.ToString(tbProduct.Text)) || string.IsNullOrEmpty(Convert.ToString(tbPrice.Text))) {
                    MessageBox.Show("Alle felter skal være udfyldt");
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





    }
}
