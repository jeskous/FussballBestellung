using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
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

        List<Customer> CustomersList = new List<Customer>();
        List<Football> cart = new List<Football>();
        double TotalPrice;

        public Pg_Delivery(List<Football> cart, double totalPrice)
        {
            this.TotalPrice = totalPrice;
            this.cart = cart;

            InitializeComponent();

            InitCustomers();

            tabControl_Delivery.Visibility = Visibility.Hidden;
            listView_CustomerList.ItemsSource = CustomersList;
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
                tb_City.Text,
                ColorPicker_color.Color);

                //ToDO Wenn Customer noch nicht vorhanden neu erstellen
                CustomersList.Add(customer);

                this.NavigationService.Navigate(new Pg_Payment(cart, customer, TotalPrice));
            }
        }

        //Helper
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //Nutzerverwaltung

        void InitCustomers()
        {
            //ToDo Liste Von Nutzern Laden und nicht immer neu erstellen

            Customer customer1 = new Customer("Latte", "Andi", "0171 22445", "Musterstraße", 4, 69420, "LA");
            CustomersList.Add(customer1);

            Customer customer2 = new Customer("Zufall", "Rainer", "0171 22445", "Musterstraße", 5, 69420, "LA");
            CustomersList.Add(customer2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabControl_Delivery.Visibility = Visibility.Visible;
            clearLabels();
        }

        private void getSelectedUser(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            int index = listView_CustomerList.Items.IndexOf(item);

            fillLabels(CustomersList[index]);
            tabControl_Delivery.Visibility = Visibility.Visible;
        }

        void fillLabels(Customer customer)
        {
            tb_LastName.Text = customer.LastName;
            tb_LastName.IsReadOnly = true;

            tb_FirstName.Text = customer.FirstName;
            tb_FirstName.IsReadOnly = true;

            tb_Street.Text = customer.Street;
            tb_Street.IsReadOnly = true;

            tb_HouseNumber.Text = customer.HouseNumber.ToString();
            tb_HouseNumber.IsReadOnly = true;

            tb_Postal.Text = customer.Postal.ToString();
            tb_Postal.IsReadOnly = true;

            tb_City.Text = customer.City;
            tb_City.IsReadOnly = true;

            tb_PhoneNumber.Text = customer.Phone;
            tb_PhoneNumber.IsReadOnly = true;
        }

        void clearLabels()
        {
            tb_LastName.Text = "";
            tb_LastName.IsReadOnly = false;

            tb_FirstName.Text = "";
            tb_FirstName.IsReadOnly = false;

            tb_Street.Text = "";
            tb_Street.IsReadOnly = false;

            tb_HouseNumber.Text = "";
            tb_HouseNumber.IsReadOnly = false;

            tb_Postal.Text = "";
            tb_Postal.IsReadOnly = false;

            tb_City.Text = "";
            tb_City.IsReadOnly = false;

            tb_PhoneNumber.Text = "";
            tb_PhoneNumber.IsReadOnly = false;
        }

    }
}
