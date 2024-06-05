using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
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
        private byte[] imageData;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public int DeliveryTime
        {
            get { return deliveryTime; }
            set { deliveryTime = value; }
        }

        public Product(int id, string name, string description, double price, int quantity, int deliveryTime, byte[] imageData)
        {
            this.id = id;
            this.Name = name;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
            this.deliveryTime = deliveryTime;
            this.imageData = imageData;
           
            
        }

        public void Visualize(WrapPanel wrapper)
        {
            ProductTemplate template = new ProductTemplate
            {
                Width = 300,
                Height = 150,
                Margin = new Thickness(50, 30, 0, 0),
                Description = this.description,
                Price = this.price,
                DeliveryTime = this.deliveryTime,
                Quantity = this.quantity,
                ImageSource = LoadImage(this.imageData)
                
            };
            wrapper.Children.Add(template);
     
        }
      
        public void Devisualize(WrapPanel wrapper)
        {
            ProductTemplate templateToRemove = null;
            foreach (UIElement element in wrapper.Children)
            {
                if (element is ProductTemplate template && template.Description == this.description)
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

        public void ReworkVisualization(WrapPanel wrapper)
        {
            bool templateExists = false;
            foreach (UIElement element in wrapper.Children)
            {
                if (element is ProductTemplate template && template.Description == this.description)
                {
                    templateExists = true;
                    break;
                }
            }

            if (!templateExists)
            {
                Visualize(wrapper);
            }
        }


        private BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                return null;
            }

            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                bitmap.BeginInit();                bitmap.StreamSource = ms;

                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            return bitmap;
        }
    }
}