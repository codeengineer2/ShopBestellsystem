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
        List<(string, int)> basketList = new List<(string, int)>();

        public Shop(ProductList productList)
        {
            InitializeComponent();
            this.productList = productList;
            this.productList.Visualize(wrapper, ProductTemplate_ButtonClicked);
        }
        private void CustomControl_TextChanged(object sender, string e)
        {
            this.searchPrompt = e;
            if (searchPrompt.Contains("$")){
                this.productList.Reset(searchPrompt, wrapper, ProductTemplate_ButtonClicked);
            }
            else
            {
                this.productList.Filter(searchPrompt, wrapper, ProductTemplate_ButtonClicked);
            }
        }

        private void ProductTemplate_ButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is ProductTemplate productTemplate)
            {
                string name = productTemplate.Alias;
                int number = productTemplate.spinBox.Number;
                basketList.Add((name, number));
                MessageBox.Show($"Value {basketList} added to the list.");
            }
        }
    }
}