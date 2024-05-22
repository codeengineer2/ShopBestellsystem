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



namespace Shop_bestellsystem
{
    public class ShoppingBasket
    {
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

        public ShoppingBasket(string street, string firstname, string lastname, string city, int plz, string country) 
        {
         
            Street = street;
            Firstname = firstname;
            Lastname = lastname;
            City = city;
            Plz = plz;
            Country = country;

        }
        public ShoppingBasket(double deliverycost, double fullprice)
        {
            Deliverycost = deliverycost;
            Fullprice = fullprice;
        }
        public ShoppingBasket()
        {

        }

        public void testing()
        {
            string message = $"Street: {Street}\nFirstname: {Firstname}\nLastname: {Lastname}\nCity: {City}\nPlz: {Plz}\nCountry: {Country}";
            MessageBox.Show(message);
        }

        public void SerializetoPdf()
        {
            Document document = new Document();
            // add a page
            Page page = document.Pages.Add();

            // Define the text with placeholders replaced by actual values


            string header = "MV Krypto Sales&Marketing GMBH & CO KG\nMain Lumber Rd\nBahamas\n\n";
            
            string customerInfo = $"{Firstname}  {Lastname}\n{Street},\n{Plz} {City}\n{Country}\n";
            string billingInfo = $"Rechnungs-Nr: 129012    \nRechnungsdatum:{DateTime.Now}    \nLieferdatum: 24.05.2024   \nE-Mail: maxmusterman    \n";
            string positions = "\nPositionen:";



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

            // Save the PDF document
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, "output.pdf");
            document.Save(filePath);
        }

    }
}
