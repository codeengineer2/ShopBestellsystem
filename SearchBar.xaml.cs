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
        public string Content;
        public SearchBar()
        {
            InitializeComponent();
        }

        private void Searching(object sender, MouseButtonEventArgs e)
        {
            this.Content = searchContent.Text;
        }
    }
}
