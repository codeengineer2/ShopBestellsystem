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
		#region variables
		private ProductList productList = new ProductList();
		private List<(Product, int)> basketList = new List<(Product, int)>();
		#endregion

		#region constructors
		public MainWindow()
        {
            var useragreements = new UserAgreementWindow();
            useragreements.ShowDialog();
			if (!useragreements.isvalid)
			{
				this.Close();
			}

            InitializeComponent();
            Loggerclass.logger.Information("MainWindow initialized.");
			Main.Content = new Shop(this.productList, this.basketList);
		}
		#endregion

		#region methods
		private void GetActualBasket()
		{
			if (Main.Content is Shop shopPage)
			{
				this.basketList = shopPage.BasketList;
				Loggerclass.logger.Information($"The current page is a Shop page. Basket items count: {basketList.Count}");
			}
			else
			{
				Loggerclass.logger.Information("The current page is not a Shop page.");
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
				Loggerclass.logger.Error(ex, "An error occurred while dragging the window.");
			}
            
        }

		private void MinimizeWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				Loggerclass.logger.Information("Window minimized.");
				WindowState = WindowState.Minimized;
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred while minimizing the window.");
			}
		}

		/*
         
		private void MaximizeWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
			try
			{
				if (WindowState == WindowState.Maximized) 
				{
					Loggerclass.logger.Information("Window restored from maximized state.");
					WindowState = WindowState.Normal;
				}
				else
				{
					Loggerclass.logger.Information("Window maximized.");
					WindowState = WindowState.Maximized;
				}
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred while changing window state.");
			}
		}

        */

		private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Loggerclass.logger.Information("Application closed.");
			this.Close();
		}

		private void menuItemBasket_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Loggerclass.logger.Information("Basket menu item clicked.");
				GetActualBasket();

				var basketWindow = new Window_ShoppingBasket(this.basketList);
				basketWindow.ShowDialog();
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred in menuItemBasket_Click.");
			}
		}

		private void menuItemShop_Click(object sender, RoutedEventArgs e)
        {
			try
			{
				Loggerclass.logger.Information("Shop menu item clicked.");
				GetActualBasket();
				ResetMenuItemsBackgroundColors();

				SolidColorBrush menuItemBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A8F88"));
				MenuItem clickedMenuItem = (MenuItem)sender;
				clickedMenuItem.Background = menuItemBackgroundColor;

				Main.Content = new Shop(this.productList, this.basketList);
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred in menuItemBasket_Click.");
			}
		}

		private void menuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Loggerclass.logger.Information("About menu item clicked.");
				GetActualBasket();
				ResetMenuItemsBackgroundColors();

				SolidColorBrush menuItemBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A8F88"));
				MenuItem clickedMenuItem = (MenuItem)sender;
				clickedMenuItem.Background = menuItemBackgroundColor;

				Main.Content = new About();
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred in menuItemAbout_Click.");
			}
		}

		private void menuItemContact_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Loggerclass.logger.Information("Contact menu item clicked.");
				GetActualBasket();
				ResetMenuItemsBackgroundColors();

				SolidColorBrush menuItemBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9A8F88"));
				MenuItem clickedMenuItem = (MenuItem)sender;
				clickedMenuItem.Background = menuItemBackgroundColor;

				Main.Content = new Contact();
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred in menuItemContact_Click.");
			}
		}

		private void menuItemInsights_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Loggerclass.logger.Information("Insights menu item clicked.");
				GetActualBasket();

				var Statistik = new Statistik_Userzahlen();
				var Statistik_userdauer = new Statistik_userdauer();

				Statistik.ShowDialog();
				Statistik_userdauer.ShowDialog();
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred in menuItemInsights_Click.");
			}
		}

		private void menuItemExit_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Loggerclass.logger.Information("Exit menu item clicked.");
				this.Close();
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred in menuItemExit_Click.");
			}
		}

		private void ResetMenuItemsBackgroundColors()
		{
			try
			{
				Loggerclass.logger.Information("Resetting menu items background colors.");

				SolidColorBrush menuBackgroundColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B8AEA6"));

				foreach (var item in menu.Items)
				{
					if (item is MenuItem menuItem)
					{
						menuItem.Background = menuBackgroundColor;
					}
				}
			}
			catch (Exception ex)
			{
				Loggerclass.logger.Error(ex, "An error occurred while resetting menu items background colors.");
			}
		}
		#endregion
	}
}