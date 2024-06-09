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
		#region variables
		#region private
		private int _id;
        private string _name;
        private string _description;
        private double _price;
        private int _quantity;
        private int _deliveryTime;
        private byte[] imageData;
        #endregion

        #region public
        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public double Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        public int Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        public int DeliveryTime
        {
            get { return this._deliveryTime; }
            set { this._deliveryTime = value; }
        }
		#endregion
		#endregion

		#region constructors
		public Product(int id, string name, string description, double price, int quantity, int deliveryTime, byte[] imageData)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
            this.DeliveryTime = deliveryTime;
            this.imageData = imageData;

			Loggerclass.logger.Information("New product created: {@Product}", this);
		}
		#endregion

		#region methods
		public void Visualize(WrapPanel wrapper, RoutedEventHandler buttonClickHandler)
		{
			Loggerclass.logger.Debug("Visualizing product: {@Product}", this);

			ProductTemplate template = new ProductTemplate
			{
				Width = 300,
				Height = 150,
				Margin = new Thickness(60, 50, 0, 0),
				Description = this.Description,
                Alias = this.Name,
				Price = this.Price,
				DeliveryTime = this.DeliveryTime,
				Quantity = this.Quantity,
				ImageSource = LoadImage(this.imageData)
			};
			template.ButtonClicked += buttonClickHandler;

			wrapper.Children.Add(template);
		}

		public void Devisualize(WrapPanel wrapper)
        {
			Loggerclass.logger.Debug("Devisualizing product: {@Product}", this);

			ProductTemplate templateToRemove = null;
            foreach (UIElement element in wrapper.Children)
            {
                if (element is ProductTemplate template && template.Alias == this.Name)
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

        public void ReworkVisualization(WrapPanel wrapper, RoutedEventHandler buttonClickHandler)
        {
			Loggerclass.logger.Debug("Reworking visualization for product: {@Product}", this);

			bool templateExists = false;
            foreach (UIElement element in wrapper.Children)
            {
                if (element is ProductTemplate template && template.Alias == this.Name)
                {
                    templateExists = true;
                    break;
                }
            }
            if (!templateExists)
            {
                Visualize(wrapper, buttonClickHandler);
            }
        }

        private BitmapImage LoadImage(byte[] imageData)
        {
			Loggerclass.logger.Debug("Loading image for product: {@Product}", this);

			if (imageData == null || imageData.Length == 0)
            {
                return null;
            }

            BitmapImage bitmap = new BitmapImage();
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
            }
            return bitmap;
        }
		#endregion
	}
}