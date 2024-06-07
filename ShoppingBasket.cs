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
using System.Collections.ObjectModel;
using System.Windows.Controls;
using MySqlX.XDevAPI.Common;



namespace Shop_bestellsystem
{
    public class ShoppingBasket
    {
        List<(Product produkt, int number)> basketList;
        public List<Product> productListe;


        public int artnum;
        public int anz;
        public string productname;
        public double singleprice;
        public int deliverytime;
        public double fullprice;
        public double deliverycost;
        public string street;
        public string firstname;
        public string lastname;
        public string city;
        public int plz;
        public string country;
        public string mail;
        public string tel;
        
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
                else
                {
                    MessageBox.Show("Bitte eine Gültige Adresse eingeben!");
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
		public ShoppingBasket(List<Product> productListe)
		{
            this.productListe = productListe;

        }

        public double deliverprice()
        {
            double singleprice = 0;
            foreach (Product item in productListe)
            {
                singleprice += item.Quantity * item.Price;
            }
            deliverycost += singleprice*0.09;
            return Math.Round(deliverycost, 2);
        }
        public double gespreis()
        {
            double singleprice = 0;
            foreach (Product item in productListe)
            {
                singleprice += item.Quantity * item.Price;
            }
            fullprice += singleprice;
            fullprice += deliverprice();
            return Math.Round(fullprice, 2);
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

            //AddProduct();

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
      
            // Add text fragments to the page
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));



            //page.Paragraphs.Add(new TextFragment(header));
            //page.Paragraphs.Add(new TextFragment(customerInfo));
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

            foreach (var item in basketList)
            {
                Row productRow = productTable.Rows.Add();
                productRow.Cells.Add($"{item.produkt.ID}");
                productRow.Cells.Add($"{item.produkt.Quantity}");
                productRow.Cells.Add($"{item.produkt.Name}");
                productRow.Cells.Add($"{item.produkt.Price}");
                productRow.Cells.Add($"{item.produkt.DeliveryTime}"); 
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
