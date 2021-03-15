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
    /// Interaction logic for Pg_Payment.xaml
    /// </summary>
    public partial class Pg_Payment : Page
    {
        List<Football> cart = new List<Football>();
        Customer Customer;

        public Pg_Payment(List<Football> cart, Customer customer)
        {
            this.cart = cart;
            this.Customer = customer;
            InitializeComponent();

            //Hide TabCtrl Header
            Style s = new Style();
            s.Setters.Add(new Setter(UIElement.VisibilityProperty, Visibility.Collapsed));
            TabCtrl_Payments.ItemContainerStyle = s;
        }

        private void PaymentBtn_Submit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pg_Overview(cart, Customer));
        }

        private void PaymentBtn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        //Check active Page
        private void rb_PayPal_Checked(object sender, RoutedEventArgs e)
        {
            TabCtrl_Payments.SelectedItem = TabItem_PayPal;
        }

        private void rb_BankAccount_Checked(object sender, RoutedEventArgs e)
        {
            TabCtrl_Payments.SelectedItem = TabItem_BankAccount;
        }
    }
}
