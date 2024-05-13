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
    /// Interaktionslogik für Window_OrderConfirmation.xaml
    /// </summary>
    public partial class Window_OrderConfirmation : Window
    {
        ShoppingBasket shop;

        public Window_OrderConfirmation()
        {

            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Initialisieren der Window_OrderConfirmation: {ex.Message}");
            }

        }

        public void Rechnungdownload(object sender, RoutedEventArgs e)
        {
            shop = new ShoppingBasket();
            shop.Serializetotxt();
        }
    }
}
