using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace Shop_bestellsystem
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private double price;
        private int quantity;
        private int deliveryTime;

        public Product(int id, string name, string description, double price, int quantity, int deliveryTime)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
            this.deliveryTime = deliveryTime;
        }

        public void Visualize(WrapPanel wrapper)
        {
            ProductTemplate template = new ProductTemplate
            {
                Width = 300,
                Height = 150,
                Margin = new Thickness(50, 30, 0, 0)
            };

            wrapper.Children.Add(template);
        }


        public void Devisualize(WrapPanel wrapper)
        {
            ProductTemplate templateToRemove = null;
            foreach (UIElement element in wrapper.Children)
            {
                if (element is ProductTemplate template && template.Name == this.name)
                {
                    templateToRemove = template;
                    break;
                }
            }

            if (templateToRemove != null)
            {
                wrapper.Children.Remove(templateToRemove);
            }
        }


    }
}
