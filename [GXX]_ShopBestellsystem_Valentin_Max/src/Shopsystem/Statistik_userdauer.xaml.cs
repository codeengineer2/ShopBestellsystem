using LiveCharts.Wpf;
using LiveCharts;
using MySql.Data.MySqlClient;
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
using System.Security.Cryptography;
using System.Security.Policy;
using Org.BouncyCastle.Crypto;
using System.Xml.Linq;
using System.Configuration;

namespace Shop_bestellsystem
{
    /// <summary>
    /// Interaktionslogik für Statistik_userdauer.xaml
    /// </summary>
    public partial class Statistik_userdauer : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public MySqlConnection Connection { get; set; }
        public string connectionString;
        


        public Statistik_userdauer()
        {
            InitializeComponent();

          
            string server = "193.203.168.53";
            string database = "u964104866_Shop";
            string UID = "u964104866_MVdevelopment";
            string password = ConfigurationManager.AppSettings["Password"];
            string port = "3306";


            connectionString = $"Server={server};Port={port};Database={database};UserID={UID};Password={password};";

            Connection = new MySqlConnection(connectionString);
            // Daten für das Diagramm abrufen
            List<double> userdauer = Getuserdauer();
            List<double> avguserdauer = Getavguserdauer();

            // Daten zum Diagramm hinzufügen
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                    {
                        Title = "AVG over all",
                        Values = new ChartValues<double>(avguserdauer)

                    },
                    new LineSeries
                    {
                        Title = "AVG per year",
                        Values = new ChartValues<double>(userdauer)


                    }
                };


            Labels = new[] { "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024" };
            Formatter = value => value.ToString("N");
            this.Background = new SolidColorBrush(Colors.AliceBlue);

            DataContext = this;
            // Set the title
            this.Title = "Usage time per shopping experience";
        }

        public List<double> Getavguserdauer()
        {
            List<double> userdauer = new List<double>();


            try
            {
                Connection.Open();
                string query = "SELECT AVG(udauer) AS userdauer FROM statistik_users";

                MySqlCommand command = new MySqlCommand(query, Connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (var i = 0; i <= 8; i++)
                        {
                            userdauer.Add(Math.Round(Convert.ToDouble(reader["userdauer"]), 2));

                        }
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

            return userdauer;
        }
        public List<double> Getuserdauer()
        {
            List<double> avguserdauer = new List<double>();


            try
            {
                Connection.Open();
                string query = "SELECT AVG(udauer) AS avguserdauer FROM statistik_users GROUP BY jahr";

                MySqlCommand command = new MySqlCommand(query, Connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        avguserdauer.Add(Math.Round(Convert.ToDouble(reader["avguserdauer"]), 2));
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

            return avguserdauer;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void MinimizeWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }


        private void CloseWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}








