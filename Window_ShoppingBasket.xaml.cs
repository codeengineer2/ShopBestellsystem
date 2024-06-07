﻿using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
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
using System.Windows.Shapes;

namespace Shop_bestellsystem
{
    /// <summary>
    /// Interaktionslogik für Window_ShoppingBasket.xaml
    /// </summary>
    public partial class Window_ShoppingBasket : Window
    {
        ShoppingBasket shop;
        public List<(Product, int)> basketList;
        public List<Product> productListe;
        public int quantitys;

        public Window_ShoppingBasket(List<(Product, int)> basketList)
        {
            InitializeComponent();
            this.basketList = basketList;

            if (basketList == null || basketList.Count == 0)
            {
                MessageBox.Show("The basketList is empty or null.");
            }
            else
            {
                
                foreach (var item in basketList)
                {
                    this.productListe = basketList.Select(i => i.Item1).ToList();
                    this.quantitys = Convert.ToInt32(basketList.Select(i => i.Item2));
                    cartListView.ItemsSource = productListe;
                    

                    
                   

                    MessageBox.Show($"Product: {item.Item1}, Price: {item.Item1.Price}, Quantity: {item.Item2}");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string street1 = street.Text;
            string firstname1 = firstname.Text;
            string lastname1 = lastname.Text;
            string city1 = city.Text;
            int plz1 = Convert.ToInt32(plz.Text);
            string country1 = country.Text;
            string mail1 = mail.Text;
			string tel1 = tel.Text;
	        shop = new ShoppingBasket(street1, firstname1, lastname1, city1, plz1, country1, mail1, tel1 );

            shop = new ShoppingBasket(street1, firstname1, lastname1, city1, plz1, country1, mail1, tel1);
            shop.testing();
            this.Close();

            var Window_OrderConfirmation = new Window_OrderConfirmation(shop);
            Window_OrderConfirmation.ShowDialog();
        }
    }
}
