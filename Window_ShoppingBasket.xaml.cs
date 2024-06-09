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
        public List<(Product product, int quant)> basketList;
        public List<Product> productListe = new List<Product>();
        
        public Window_ShoppingBasket(List<(Product, int)> basketList)
        {
            InitializeComponent();
            this.basketList = basketList;

            if (basketList == null || basketList.Count == 0)
            {
                MessageBox.Show("The basketList is empty or null.");
                Loggerclass.logger.Warning("basketList ist Leer (is null)");
            }
            else
            {
                Loggerclass.logger.Information($"In der basketList sind Werte enthalten");
                foreach (var item in basketList)
                {
                    Product product = item.Item1;
                    product.Quantity = item.Item2;
                    
                    productListe.Add(product);            
                    cartListView.ItemsSource = productListe;
                    Loggerclass.logger.Information($"Zeile an Inhalten in die ListView hinzugefüt");







                    
                }
            }
            Loggerclass.logger.Information($"Hinzufügen der Inhalte in ListView abgeschlossen!");
            shop = new ShoppingBasket(productListe);

            double deliverycosts = shop.deliveryprice();
            double gesprice = shop.gespreis();
            string deliverytimes = shop.lieferdatum();
            deliverycost.Text = $"Delivery costs: {deliverycosts} €";
            fullprice.Text = $"Total price: {gesprice} €";
            deliveryTime.Text = $"Delivery time: {deliverytimes}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string street1 = street.Text;
            string firstname1 = firstname.Text;
            string lastname1 = lastname.Text;
            string city1 = city.Text;
            string plz1 = plz.Text;
            string country1 = country.Text;
            string mail1 = mail.Text;
			
            
	        shop = new ShoppingBasket(street, firstname, lastname, city, plz, country, mail);
            if (shop.korrektinput == true)
            {
                Loggerclass.logger.Information($"Alle Eingaben sind Richtig (mail, vorname, usw.) ");
                Loggerclass.logger.Information($"Alle Überprüfungen in den Properties sind Wahr!");
                shop = new ShoppingBasket(street1, firstname1, lastname1, city1, plz1, country1, mail1, productListe);

               
                this.Close();

                var Window_OrderConfirmation = new Window_OrderConfirmation(shop);
                Window_OrderConfirmation.ShowDialog();
            }
            
           
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void MinimizeWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

      
        private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
