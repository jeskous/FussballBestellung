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

namespace FußballBestellung
{
    /// <summary>
    /// Interaction logic for Pg_Delivery.xaml
    /// </summary>
    public partial class Pg_Delivery : Page
    {

        List<Football> cart = new List<Football>();

        public Pg_Delivery(List<Football> cart)
        {
            this.cart = cart;

            InitializeComponent();
        }

        private void DeliveryBtn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void DeliveryBtn_Submit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pg_Payment(cart));
        }
    }
}
