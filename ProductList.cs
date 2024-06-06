using Aspose.Pdf.Plugins;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml.Linq;
using static Google.Protobuf.Reflection.UninterpretedOption.Types;

namespace Shop_bestellsystem
{
    public class ProductList
    {
        private List<Product> products = new List<Product>();
        private MySqlConnection Connection { get; set; }
        private string connectionString;

        public ProductList()
        {
            string server = "193.203.168.53";
            string database = "u964104866_Shop";
            string UID = "u964104866_MVdevelopment";
            string password = ConfigurationManager.AppSettings["Password"];
            string port = "3306";

            connectionString = $"Server={server};Port={port};Database={database};UserID={UID};Password={password};";

            Connection = new MySqlConnection(connectionString);

            try
            {
                Connection.Open();
                string query = "SELECT * FROM Products;";

                MySqlCommand command = new MySqlCommand(query, Connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] imageData = reader["picture"] as byte[];
                        Product product = new Product(
                            reader.GetInt32("ID"),
                            reader.GetString("name"),
                            reader.GetString("description"),
                            reader.GetDouble("price"),
                            reader.GetInt32("quantity"),
                            reader.GetInt32("deliveryTime"),
                            imageData
                        );
                        products.Add(product);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + connectionString);
            }
            finally
            {
                Connection.Close();
            }
        }

		public void Filter(string prompt, WrapPanel wrapper, RoutedEventHandler buttonClickHandler)
		{
			string correctPrompt = prompt.ToLower();

			foreach (Product product in products)
			{
				string productName = product.Name.ToLower();

				if (correctPrompt.Length > productName.Length)
				{
					product.Devisualize(wrapper);
				}
				else if (productName == correctPrompt)
				{
					product.ReworkVisualization(wrapper, buttonClickHandler);
				}
				else
				{
					if (correctPrompt.Length >= (productName.Length / 2))
					{
						bool checker = true;
						for (int i = 0; i < correctPrompt.Length; i++)
						{
							if (correctPrompt[i] != productName[i])
							{
								checker = false;
								break;
							}
						}

						if (checker)
						{
							product.ReworkVisualization(wrapper, buttonClickHandler);
						}
						else
						{
							product.Devisualize(wrapper);
						}
					}
					else
					{
						product.Devisualize(wrapper);
					}
				}
			}
		}


		public void Visualize(WrapPanel wrapper, RoutedEventHandler buttonClickHandler)
        {
            foreach(Product p in products)
            {
                p.Visualize(wrapper, buttonClickHandler);
            }
        }

		public void Reset(WrapPanel wrapper, RoutedEventHandler buttonClickHandler)
		{
			foreach(Product product in products)
			{
				product.ReworkVisualization(wrapper, buttonClickHandler);
			}
		}

		public Product FindProductByAlias(string alias)
        {
            foreach(Product product in products)
            {
                if (product.Name == alias)
                {
                    return product;
                }
            }
            return null;
        }

	}
}
