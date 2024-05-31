using Aspose.Pdf.Plugins;
using DocumentFormat.OpenXml.Vml;
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

namespace Shop_bestellsystem
{
    public class ProductList
    {
        private List<Product> products = new List<Product>();
        public MySqlConnection Connection { get; set; }
        public string connectionString;

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
