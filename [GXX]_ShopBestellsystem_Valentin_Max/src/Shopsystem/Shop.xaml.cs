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
		#region variables
		private ProductList productList;
        public List<(Product liste, int number)> BasketList;
		private string searchPrompt;
		#endregion

		#region constructors
		public Shop(ProductList productList, List<(Product, int)> basketList)
        {
            InitializeComponent();
			this.productList = productList;
			this.BasketList = basketList;
            this.productList.Visualize(wrapper, ProductTemplate_ButtonClicked);
			LoadSearchBar();
		}
		#endregion

		#region methods
		private void LoadSearchBar()
        {
			Loggerclass.logger.Information("Loading search bar in Shop page.");

			SearchBar searchBar = new SearchBar
			{
				Name = "miniSearchBar",
				Margin = new Thickness(270, -310, 270, 0),
				Height = 150,
				ProductListKey = this.productList,
			};
			searchBar.ButtonClicked += SearchBar_ButtonClicked;

			grid.Children.Add(searchBar);
			Grid.SetRow(searchBar, 0);
			Grid.SetRowSpan(searchBar, 2);
		}

		private void SearchBar_ButtonClicked(object sender, string e)
		{
			Loggerclass.logger.Information("Search bar button clicked in Shop page. Prompt: {Prompt}", e);

			this.searchPrompt = e;
			if (searchPrompt == "$"){ 
				this.productList.Reset(wrapper, ProductTemplate_ButtonClicked);

				Loggerclass.logger.Information("Resetting product list in Shop page.");
			}
			else
			{
				this.productList.Filter(searchPrompt, wrapper, ProductTemplate_ButtonClicked);

				Loggerclass.logger.Information("Filtering product list in Shop page with prompt: {Prompt}", searchPrompt);
			}
		}

		private void ProductTemplate_ButtonClicked(object sender, RoutedEventArgs e)
        {
			Loggerclass.logger.Information("Product template button clicked in Shop page.");

			if (sender is ProductTemplate productTemplate)
            {
                string alias = productTemplate.Alias;
                int number = productTemplate.spinBox.Number;

                Product product = this.productList.FindProductByAlias(alias);

				this.BasketList.Add((product, number));
				Loggerclass.logger.Information("Product added to basket: {ProductName}, Quantity: {Quantity}", product.Name, number);
			}
		}
		#endregion
	}
}