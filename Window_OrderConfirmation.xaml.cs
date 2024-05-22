using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Aspose.Pdf;


namespace Shop_bestellsystem
{
    /// <summary>
    /// Interaktionslogik für Window_OrderConfirmation.xaml
    /// </summary>
    public partial class Window_OrderConfirmation : Window
    { 
        ShoppingBasket shop;
        


        public Window_OrderConfirmation(ShoppingBasket shop)
        {
            try
            {
                InitializeComponent();
                this.shop = shop;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Initialisieren der Window_OrderConfirmation: {ex.Message}");
            }
        }


        public void Rechnungdownload(object sender, RoutedEventArgs e)
        {
            
            // initialize document object
            
            shop.SerializetoPdf();
        }
            
    }
}
