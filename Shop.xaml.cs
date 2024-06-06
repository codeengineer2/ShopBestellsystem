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
        public List<(Product, int)> basketList;

        public Shop(ProductList productList, List<(Product, int)> basketList)
        {
            InitializeComponent();
            this.basketList = basketList;
            this.productList = productList;
            this.productList.Visualize(wrapper, ProductTemplate_ButtonClicked);
        }
		private void SearchBar_ButtonClicked(object sender, string e)
		{
			this.searchPrompt = e;
			if (searchPrompt == "$"){ 
				this.productList.Reset(wrapper, ProductTemplate_ButtonClicked);
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
                string alias = productTemplate.Alias;
                int number = productTemplate.spinBox.Number;

                Product product = productList.FindProductByAlias(alias);

				basketList.Add((product, number));
				MessageBox.Show($"Value {product.Name} {number} added to the list.");
			}
        }


    }
}