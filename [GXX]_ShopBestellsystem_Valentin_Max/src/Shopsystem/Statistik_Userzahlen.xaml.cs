using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using Aspose.Pdf.Plugins;
using System.Windows.Controls.Primitives;
using System.Collections;
using QuestPDF;
using DocumentFormat.OpenXml.CustomProperties;
using System.Configuration;
using System.Windows.Media;
using System.Windows.Input;



namespace Shop_bestellsystem
{
    /// <summary>
    /// Interaktionslogik für Statistik_Userzahlen.xaml
    /// </summary>
    public partial class Statistik_Userzahlen : Window
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
        public MySqlConnection Connection { get; set; }
        public string connectionString;
       

        public Statistik_Userzahlen()
        {
            InitializeComponent();


            string server = "193.203.168.53";
            string database = "u964104866_Shop";
            string UID = "u964104866_MVdevelopment";
            string password = ConfigurationManager.AppSettings["Password"];

            string port = "3306";


            connectionString = $"Server={server};Port={port};Database={database};UserID={UID};Password={password};";

            Connection = new MySqlConnection(connectionString);

            List<double> userCounts = GetData();

            SeriesCollection = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "User numbers",
                        Values = new ChartValues<double>(userCounts)
                    }
                };

            Labels = new[] { "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024" };
            Formatter = value => value.ToString("N");
            this.Background = new SolidColorBrush(Colors.AliceBlue);

            DataContext = this;
        }

        public List<double> GetData()
        {
            List<double> userCounts = new List<double>();
            try
            {
                Connection.Open();
                string query = "SELECT COUNT(*) AS jahre FROM statistik_users GROUP BY jahr";

                MySqlCommand command = new MySqlCommand(query, Connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userCounts.Add(Convert.ToDouble(reader["jahre"]));
                    }
                }
                MessageBox.Show($"{userCounts}");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + connectionString);
            }
            finally
            {
                Connection.Close();
            }

            return userCounts;
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


