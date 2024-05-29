using Aspose.Pdf.Plugins;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml.Linq;

namespace Shop_bestellsystem
{
    public class ProductList
    {
        private List<Product> products = new List<Product>();

        public ProductList()
        {
            
        }

        public void Visualize(WrapPanel wrapper)
        {
            foreach(Product p in products)
            {
                p.Visualize(wrapper);
            }
        }

        public void Reset(WrapPanel wrapper)
        {
            Visualize(wrapper);
        }
    }
}
