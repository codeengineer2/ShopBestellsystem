using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductList productList = new ProductList();
		List<(Product, int)> basketList = new List<(Product, int)>();

		public MainWindow()
        {
            InitializeComponent();
			Main.Content = new Shop(productList, basketList);
		}

		private void GetActualBasket()
		{
			if (Main.Content is Shop shopPage)
			{
				this.basketList = shopPage.basketList;
				int number = basketList.Count;
				MessageBox.Show($"{number} The current page is a Shop page.");
			}
			else
			{
				MessageBox.Show("The current page is not a Shop page.");
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
			}catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

		private void MinimizeWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
            WindowState = WindowState.Minimized;
		}

        /*
         
		private void MaximizeWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
            if (WindowState == WindowState.Maximized) 
            {
                WindowState = WindowState.Normal;
            }
            else
            {
				WindowState = WindowState.Maximized;
			}
		}

        */

		private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
            this.Close();
		}

		private void menuItemBasket_Click(object sender, RoutedEventArgs e)
		{
			GetActualBasket();
			ResetMenuItemsBackgroundColors();
			
			SolidColorBrush menuItemBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A8F88"));
			MenuItem clickedMenuItem = (MenuItem)sender;

			clickedMenuItem.Background = menuItemBackgroundColor;
            var basketWindow = new Window_ShoppingBasket();
			basketWindow.ShowDialog();
            
		}

        private void menuItemShop_Click(object sender, RoutedEventArgs e)
        {
			GetActualBasket();
			ResetMenuItemsBackgroundColors();

			SolidColorBrush menuItemBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A8F88"));
			MenuItem clickedMenuItem = (MenuItem)sender;

			clickedMenuItem.Background = menuItemBackgroundColor;

			Main.Content = new Shop(productList, basketList);
		}

		private void menuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			GetActualBasket();
			ResetMenuItemsBackgroundColors();

			SolidColorBrush menuItemBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A8F88"));
			MenuItem clickedMenuItem = (MenuItem)sender;

            clickedMenuItem.Background = menuItemBackgroundColor;

			Main.Content = new About();
		}

		private void menuItemContact_Click(object sender, RoutedEventArgs e)
		{
			GetActualBasket();
			ResetMenuItemsBackgroundColors();

			SolidColorBrush menuItemBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A8F88"));
			MenuItem clickedMenuItem = (MenuItem)sender;

			clickedMenuItem.Background = menuItemBackgroundColor;

			Main.Content = new Contact();
        }

		private void menuItemInsights_Click(object sender, RoutedEventArgs e)
		{
			GetActualBasket();
			var Statistik = new Statistik_Userzahlen();
            var Statistik_userdauer = new Statistik_userdauer();

            Statistik.ShowDialog();
            Statistik_userdauer.ShowDialog();
        }

        private void menuItemExit_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ResetMenuItemsBackgroundColors()
		{
			SolidColorBrush menuBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8AEA6"));

			foreach (var item in menu.Items)
			{
				if (item is MenuItem menuItem)
				{
					menuItem.Background = menuBackgroundColor;
				}
			}
		}
	}
}