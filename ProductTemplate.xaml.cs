using Newtonsoft.Json.Linq;
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
    public partial class ProductTemplate : UserControl
    {
        public static readonly DependencyProperty AliasProperty = DependencyProperty.Register("Alias", typeof(string), typeof(ProductTemplate), new PropertyMetadata(string.Empty));
        public string Alias
        {
            get { return (string)GetValue(AliasProperty); }
            set { SetValue(AliasProperty, value); }
        }

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(ProductTemplate), new PropertyMetadata(string.Empty));
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly DependencyProperty PriceProperty = DependencyProperty.Register("Price", typeof(double), typeof(ProductTemplate), new PropertyMetadata(0.0));
        public double Price
        {
            get { return (double)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        public static readonly DependencyProperty DeliveryTimeProperty = DependencyProperty.Register("DeliveryTime", typeof(int), typeof(ProductTemplate), new PropertyMetadata(0));
        public int DeliveryTime
        {
            get { return (int)GetValue(DeliveryTimeProperty); }
            set { SetValue(DeliveryTimeProperty, value); }
        }

        public static readonly DependencyProperty QuantityProperty = DependencyProperty.Register("Quantity", typeof(int), typeof(ProductTemplate), new PropertyMetadata(0));
        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        public BitmapImage ImageSource
        {
            get { return (BitmapImage)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(BitmapImage), typeof(ProductTemplate), new PropertyMetadata(null, OnImageSourceChanged));
        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ProductTemplate;
            if (control != null && e.NewValue is BitmapImage newImage)
            {
                control.ProductImage.Source = newImage;
            }
        }

		public event RoutedEventHandler ButtonClicked;

		public ProductTemplate()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int quantitySpinBox = spinBox.Number;
            ButtonClicked?.Invoke(this, new RoutedEventArgs());
        }
    }
}