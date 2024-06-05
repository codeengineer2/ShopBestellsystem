using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf;
using System.IO;
using Aspose.Pdf.Text;
using Aspose.Pdf.Plugins;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;



namespace Shop_bestellsystem
{
    public class ShoppingBasket
    {
        private int artnum;
        private int anz;
        private string productname;
        private double singleprice;
        private int deliverytime;
        private double fullprice;
        private double deliverycost;
        private string street;
        private string firstname;
        private string lastname;
        private string city;
        private int plz;
        private string country;
        private string mail;
        private string tel;
        
        public ObservableCollection<Product> BasketList = new ObservableCollection<Product>();
        
        public int Artnum { get; set; }
        public int Anz { get; set; }

        public string Productname { get; set; }
        public double Singleprice { get; set; }
        public int Deliverytime { get; set; }
        public double Fullprice { get; set; }
        public double Deliverycost { get; set; }
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 20)
                {
                    street = value;
                }
            }
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 15)
                {
                    firstname = value;
                }
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                if (value.Length >0 && value.Length <= 15)
                {
                    lastname = value;
                }
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (value.Length >0 && value.Length <= 15)
                {
                    city = value;
                }
            }
        }
        
        public int Plz 
        {
            get
            {
                return plz;
            }
            set
            {
                if (value.ToString().Length == 4)
                {
                    plz = value;
                }
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (value.ToLower() == "austria" || value.ToLower() == "österreich")
                {
                    country = "Austria";
                }
            }
        }
        public string Mail
        {
            get
            {
                return mail;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 25)
                {
                    mail = value;
                }
            }
        }
        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                if (value.Length > 0 && value.Length <= 18)
                {
                    tel = value;
                }
            }
        }

        public ShoppingBasket(string street, string firstname, string lastname, string city, int plz, string country, string mail, string tel) 
        {
         
            Street = street;
            Firstname = firstname;
            Lastname = lastname;
            City = city;
            Plz = plz;
            Country = country;
            Mail = mail;
            Tel = tel;

        }
        public ShoppingBasket(double deliverycost, double fullprice)
        {
            Deliverycost = deliverycost;
            Fullprice = fullprice;
        }
        public ShoppingBasket()
        {
        }

        public void AddProduct()
        {
            BasketList.Add(new Product(1, "Birne", "Birne", 0.8, 20, 12, null));
            BasketList.Add(new Product(2, "Apfel", "Apfel", 0.2, 20, 12, null));
        }
        public void AddListView(ListView listView1)
        {
            AddProduct();
            /*foreach (var item in BasketList)
            {
                //var ls = new ListViewItem();
                //ls.Content = $"{item.Item1}, {item.Item2}";
                listView1.Items.Add(item);

            }*/
        }

        public void testing()
        {
            string message = $"Street: {Street}\nFirstname: {Firstname}\nLastname: {Lastname} \nE-mail: {Mail}\nTelefonnummer: {Tel}\nCity: {City}\nPlz: {Plz}\nCountry: {Country}";
            MessageBox.Show(message);
        }
        
        public void SerializetoPdf()
        {
            Document document = new Document();
            // Fügt eine Seite hinzu
            Aspose.Pdf.Page page = document.Pages.Add();




            string header = "MV Krypto Sales&Marketing GMBH & CO KG\nMain Lumber Rd\nBahamas\n\n";
            
            string customerInfo = $"{Firstname}  {Lastname}\n{Street},\n{Plz} {City}\n{Country}\n";
            string billingInfo = $"Rechnungs-Nr: 129012    \nRechnungsdatum:{DateTime.Today}\n \nE-mail: {Mail}\nTelefonnummer: {Tel}\n";
            string positions = "\nPositionen:";

            AddProduct();

            // Erstellen Sie eine Tabelle mit zwei Spalten und einer Zeile
            Table table = new Table();
            table.ColumnWidths = "50% 50%";

            // Fügen Sie eine Zeile zur Tabelle hinzu
            Row row = table.Rows.Add();

            // Füge die Daten auf der linken Seite hinzu
            Cell leftCell = row.Cells.Add(header);
            leftCell.Paragraphs[0].Margin = new MarginInfo { Left = 10 }; // Abstand zum linken Rand

            // Fügen Sie die Kundendaten in die rechte Zelle ein
            Cell rightCell = row.Cells.Add(customerInfo);
            rightCell.Paragraphs[0].Margin = new MarginInfo { Left = 10 };

            page.Paragraphs.Add(table);
            
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));

            
           
            page.Paragraphs.Add(new TextFragment(billingInfo));
            page.Paragraphs.Add(new TextFragment(positions));
            
            
            
            
            Table productTable = new Table();
            productTable.ColumnWidths = "10% 40% 10% 20% 20%"; // Anpassung der Spaltenbreiten

            Row headerRow = productTable.Rows.Add();
            headerRow.Cells.Add("Artikelnummer");
            headerRow.Cells.Add("Anzahl");
            headerRow.Cells.Add("Produkt");
            headerRow.Cells.Add("Preis");
            headerRow.Cells.Add("Lieferzeit");

            // Beispielhaftes Hinzufügen von Produktpositionen

            foreach (Product item in BasketList)
            {
                Row productRow = productTable.Rows.Add();
                productRow.Cells.Add($"{item.ID}");
                productRow.Cells.Add($"{item.Quantity}");
                productRow.Cells.Add($"{item.Name}");
                productRow.Cells.Add($"{item.Price}");
                productRow.Cells.Add($"{item.DeliveryTime}"); 
            }

            // Fügen Sie die Produkttabelle zur Seite hinzu
            page.Paragraphs.Add(productTable);
            // Speichern Sie das aktualisierte Dokument
            // Speichern
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, "output.pdf");


            document.Save(filePath);
        }
       

    }
}
