using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Pg_Shop.xaml
    /// </summary>
    public partial class Pg_Shop_List : Page
    {
        JuhuuEntities Entities = new JuhuuEntities();
        List<Football> footballs = new List<Football>();
        List<Football> cart = new List<Football>();
        List<Football> shopItems;
        double totalPrice = 0;

        

        public Pg_Shop_List()
        {
            InitializeComponent();

            InitFootballList();

            shopItems = new List<Football>();
            foreach(var item in footballs)
            {
                shopItems.Add(new Football() { Name = item.Name, Brand = item.Brand, Price = item.Price, ImagePath = item.ImagePath });
            }

            CustomItems.ItemsSource = shopItems;
        }

        //
        // Form Methods
        //

        private void ShopBtn_Add_Click(object sender, RoutedEventArgs e)
        {

            var item = (sender as Button).DataContext;
            int index = CustomItems.Items.IndexOf(item);

            cart.Add(footballs[index]);
            totalPrice += footballs[index].Price;
            displayCart();
            updateTotalPrice();
        }
        private void ShopBtn_Remove_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext;
            int index = listView_cart.Items.IndexOf(item);

            totalPrice -= cart[index].Price;
            cart.Remove(cart[index]);
            
            displayCart();
            updateTotalPrice();
        }

        //
        //Navigation
        //
        private void ShopBtn_Submit_Click(object sender, RoutedEventArgs e)
        {
            if (cart.Count != 0)
            {
                this.NavigationService.Navigate(new Pg_Delivery(cart, totalPrice));
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie ein Produkt aus!");
            }              
        }



        //
        //Helper
        //

        void InitFootballList()
        {
            //fill footballs list from database
            foreach(var Ball in Entities.Table_Footballs)
            {
                footballs.Add(new Football(Ball.Name, Convert.ToInt32(Ball.Size), Ball.Brand, Convert.ToDouble(Ball.Price), null));
            }
        }
        ListBoxItem addListBoxItem()
        {
            var ListBoxItem = new ListBoxItem();

            return ListBoxItem;
        }
        void updateTotalPrice()
        {
            lbl_Cart_Price_Value.Content = $"{totalPrice.ToString("C2")}";
        }

        //fills tb_cart with items in cart
        void displayCart()
        {
            listView_cart.ItemsSource = null;
            listView_cart.ItemsSource = cart;
        }

        private void ShopBtn_CheckPrice_Click(object sender, RoutedEventArgs e)
        {
            if(Calc_Calculator.Visibility == Visibility.Visible)
            {
                Calc_Calculator.Visibility = Visibility.Hidden;
            }
            else
            {
                Calc_Calculator.Visibility = Visibility.Visible;
            }
            
        }
    }
}
