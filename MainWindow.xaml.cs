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
        public MainWindow()
        {
            InitializeComponent();
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

		private void MenuItemBasket_Click(object sender, RoutedEventArgs e)
		{
			var basketWindow = new Window_ShoppingBasket();
			basketWindow.ShowDialog();
		}

	}
}