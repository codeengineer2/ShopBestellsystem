using DocumentFormat.OpenXml.Vml;
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
	/// Interaktionslogik für SearchBar.xaml
	/// </summary>
	public partial class SearchBar : UserControl
	{
		public event EventHandler<string> ButtonClicked;
		private List<Product> products = null;

		public static readonly DependencyProperty ProductListProperty = DependencyProperty.Register("ProductList", typeof(ProductList), typeof(SearchBar), new PropertyMetadata(null));
		public ProductList ProductListKey
		{
			get { return (ProductList)GetValue(ProductListProperty); }
			set { SetValue(ProductListProperty, value); }
		}

		public SearchBar()
		{
			InitializeComponent();
			searchContent.TextChanged += searchContent_TextChanged;
		}

		private void Searching(object sender, MouseButtonEventArgs e)
		{
			selectionBar.Children.Clear();
			string text = searchContent.Text;
			ButtonClicked?.Invoke(this, text.Trim());
		}

		private void SearchContent_GotFocus(object sender, RoutedEventArgs e)
		{
			selectionBar.Children.Clear();
			if (searchContent.Text.Length > 0)
			{
				products = ProductListKey.GetHighestSamePrompts(searchContent.Text.Trim());
				UpdateSearchSelection(products);
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					Button button = new Button
					{
						Content = ProductListKey.GetProductNameByIndex(i),
						Margin = new Thickness(5)
					};
					button.Click += Button_Click;

					selectionBar.Children.Add(button);
				}
			}
			selectionBar.Visibility = Visibility.Visible;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button clickedButton = sender as Button;

			if (clickedButton != null)
			{
				searchContent.Text = clickedButton.Content.ToString();
			}
		}

		private void searchContent_TextChanged(object sender, TextChangedEventArgs e)
		{
			selectionBar.Children.Clear();
			string searchText = searchContent.Text.Trim();
			if (searchText.Length > 0)
			{
				products = ProductListKey.GetHighestSamePrompts(searchText);

				if (products != null)
				{
					UpdateSearchSelection(products);
				}
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					Button button = new Button
					{
						Content = ProductListKey.GetProductNameByIndex(i),
						Margin = new Thickness(5)
					};
					button.Click += Button_Click;

					selectionBar.Children.Add(button);
				}
			}
			
		}

		private void UpdateSearchSelection(List<Product> products)
		{		
			for (int i = 0; i < products.Count; i++)
			{
				Button button = new Button
				{
					Content = products[i].Name,
					Margin = new Thickness(5)
				};
				button.Click += Button_Click;

				selectionBar.Children.Add(button);
			}
		}
	}
}