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
    /// Interaktionslogik für SpinBox.xaml
    /// </summary>
    public partial class SpinBox : UserControl
    {
        public static readonly DependencyProperty QuantityProperty = DependencyProperty.Register("Quantity", typeof(int), typeof(SpinBox), new PropertyMetadata(0));
        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }

        private int minNumber = 0;
        private int maxNumber = 0;
        private int number = 0;

        public SpinBox()
        {
            InitializeComponent();
            this.minNumber = 1;
            this.number = this.minNumber;
            this.maxNumber = this.Quantity;
        }

        private void ArrowUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(number != maxNumber)
            {
                number += 1;
                UpdateContent(number);
            }
        }

        private void ArrowDown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (number != minNumber)
            {
                number -= 1;
                UpdateContent(number);
            }
        }

        private void UpdateContent(int number)
        {
            Content.Text = number.ToString();
        }
    }
}
