using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
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
using System.Windows.Shapes;

namespace Shop_bestellsystem
{
    /// <summary>
    /// Interaktionslogik für Window_ShoppingBasket.xaml
    /// </summary>
    public partial class Window_ShoppingBasket : Window
    {
        ShoppingBasket shop;
        List<ShoppingBasket> basketlist = new List<ShoppingBasket>();

        public Window_ShoppingBasket()
        {
            InitializeComponent();
            shop = new ShoppingBasket();
            DataContext = shop;
            shop.AddProduct();

            
            cartListView.ItemsSource = shop.BasketList;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string street1 = street.Text;
            string firstname1 = firstname.Text;
            string lastname1 = lastname.Text;
            string city1 = city.Text;
            int plz1 = Convert.ToInt32(plz.Text);
            string country1 = country.Text;
            string mail1 = mail.Text;
            string tel1 = tel.Text;
            shop = new ShoppingBasket(street1, firstname1, lastname1, city1, plz1,country1,mail1,tel1 );

            shop.testing();
            this.Close();
            
            var Window_OrderConfirmation = new Window_OrderConfirmation(shop);
            Window_OrderConfirmation.ShowDialog();

            
        }

        
    }
}
