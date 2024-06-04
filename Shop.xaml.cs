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

namespace Shop_bestellsystem
{
    /// <summary>
    /// Interaktionslogik für Shop.xaml
    /// </summary>
    public partial class Shop : Page
    {
        public string searchPrompt;
        ProductList productList;

        public Shop(ProductList productList)
        {
            InitializeComponent();
            this.productList = productList;
            this.productList.Visualize(wrapper);
        }
        private void CustomControl_TextChanged(object sender, string e)
        {
            // Hier können Sie den Text verwenden, wie Sie möchten
            // Zum Beispiel setzen Sie ihn in eine Variable
            this.searchPrompt = e;
            if (searchPrompt.Contains("$")){
                this.productList.Reset(searchPrompt, wrapper);
            }
            else
            {
                this.productList.Filter(searchPrompt, wrapper);
            }
     
        }
    }
}
