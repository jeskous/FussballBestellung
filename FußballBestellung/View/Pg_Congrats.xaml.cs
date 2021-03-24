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
    /// Interaction logic for Pg_Congrats.xaml
    /// </summary>
    public partial class Pg_Congrats : Page
    {

        List<Football> cart = new List<Football>();
        Customer Customer;

        public Pg_Congrats(List<Football> cart, Customer customer)
        {
            this.cart = cart;
            this.Customer = customer;
            InitializeComponent();

        }

        private void Overview_btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Customer.FirstName);
        }

        private void starRating_rating_ValueChanged(object sender, Syncfusion.Windows.Controls.Input.ValueChangedEventArgs e)
        {
            submitRating(starRating_rating.Value);
            starRating_rating.IsEnabled = false;
        }

        //
        //Helper
        //
        void submitRating(double starRating)
        {
            //ToDo Bewertung bearbeiten
            MessageBox.Show("Danke für deine Bewertung!");
        }
    }
}
