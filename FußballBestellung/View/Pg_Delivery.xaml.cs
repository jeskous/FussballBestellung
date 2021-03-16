using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FußballBestellung
{
    /// <summary>
    /// Interaction logic for Pg_Delivery.xaml
    /// </summary>
    public partial class Pg_Delivery : Page
    {

        List<Football> cart = new List<Football>();
        double TotalPrice;

        public Pg_Delivery(List<Football> cart, double totalPrice)
        {
            this.TotalPrice = totalPrice;
            this.cart = cart;

            InitializeComponent();
        }

        private void DeliveryBtn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void DeliveryBtn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (tb_LastName.Text == "" || 
                tb_FirstName.Text == "" || 
                tb_PhoneNumber.Text == "" ||
                tb_Street.Text == "" ||
                tb_HouseNumber.Text == "" || 
                tb_Postal.Text == "" ||
                tb_City.Text == "")
            {
                MessageBox.Show("Kein Feld darf leer sein!");
            }
            else
            {
                Customer customer = new Customer
                (tb_LastName.Text,
                tb_FirstName.Text,
                tb_PhoneNumber.Text,
                tb_Street.Text,
                Convert.ToInt32(tb_HouseNumber.Text),
                Convert.ToInt32(tb_Postal.Text),
                tb_City.Text);

                this.NavigationService.Navigate(new Pg_Payment(cart, customer, TotalPrice));
            }
        }

        //Helper
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
