using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Interaction logic for Pg_Overview.xaml
    /// </summary>
    public partial class Pg_Overview : Page
    {
        JuhuuEntities Entities = new JuhuuEntities();
        List<Football> cart = new List<Football>();
        Customer Customer;
        double TotalPrice;

        public Pg_Overview(List<Football> cart, Customer customer, double totalPrice)
        {
            this.cart = cart;
            this.Customer = customer;
            this.TotalPrice = totalPrice;
            InitializeComponent();

            displayCart();
            displayCustomerInfo();
        }

        private void Overview_btn_Submit_Click(object sender, RoutedEventArgs e)
        {

            bool exists = false;
            foreach (var cus in Entities.Customer)
            {
                if (cus.FirstName == Customer.FirstName && cus.LastName == Customer.LastName)
                {
                    exists = true;
                }
            }
            if (!exists)
            {

                try
                {

                    //ToDo Fix add new customer to DB

                    List<string> IDList = new List<string>();
                    foreach (var cus in Entities.Customer)
                    {
                        IDList.Add(cus.ID);
                    }

                    int newID = Convert.ToInt32(IDList[IDList.Count - 1]) + 1;

                    Customer.ID = newID.ToString();


                    Entities.Customer.Add(Customer);
                    Entities.SaveChangesAsync();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
            }

            this.NavigationService.Navigate(new Pg_Congrats(cart, Customer));
        }

        private void Overview_btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        //
        // Helper
        //

        void displayCustomerInfo()
        {
            lbl_FirstName_Value.Content = Customer.FirstName;
            lbl_LastName_Value.Content = Customer.LastName;
            lbl_Phone_Value.Content = Customer.Phone;
            lbl_Street_Value.Content = Customer.Street;
            lbl_HouseNumber_Value.Content = Customer.HouseNumber;
            lbl_Postal_Value.Content = Customer.Postal;
            lbl_City_Value.Content = Customer.City;
            if(Customer.ChosenPayment == "PayPal")
            {
                lbl_PaymentMethod_Value.Content = Customer.Paypal.MethodName;
            }
            else
            {
                lbl_PaymentMethod_Value.Content = Customer.BankAccount.MethodName;
            }
        }
        void displayCart()
        {

            listView_cart.ItemsSource = null;
            listView_cart.ItemsSource = cart;
            lbl_Cart_Price_Value.Content = $"{TotalPrice.ToString("C2")}";
        }
    }
}
