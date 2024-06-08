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
using DocumentFormat.OpenXml.Office.CoverPageProps;
using System.Windows.Media.Media3D;
using System.Runtime.ConstrainedExecution;



namespace Shop_bestellsystem
{
    public class ShoppingBasket
    {
        
        public List<Product> productListe;
        public bool korrektinput = true;

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
        private string plz;
        private string country;
        private string mail;
        private string tel;
        
        public int Artnum { get; set; }
        public int Anz { get; set; }

        public string Productname { get; set; }
        public double Singleprice { get; set; }
        public int Deliverytime { get; set; }
        public double Fullprice { get; set; }
        public double Deliverycost { get; set; }
        public TextBox streetnew;
        public TextBox firstnamenew;
        public TextBox lastnamenew;
        public TextBox citynew;
        public TextBox plznew;
        public TextBox countrynew;
        public TextBox mailnew;
        public TextBox telnew;

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
                    korrektinput = false;
                    streetnew.Text = "Bitte korrekte Adresse angeben";
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
                else
                {
                    korrektinput = false;
                    firstnamenew.Text = "Bitte korrekten Vornamen angeben";
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
                else
                {
                    korrektinput = false;
                    lastnamenew.Text = "Bitte korrekten Nachnamen angeben";
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
                else
                {
                    korrektinput = false;
                    citynew.Text = "Stadt eingeben";
                }
            }
        }
        
        public string Plz 
        {
            get
            {
                return plz;
            }
            set
            {
                if (value.Length == 4)
                {
                    plz = value;
                }
                else
                {
                    korrektinput = false;
                    plznew.Text = "AT-Format: 0000";
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
                else
                {
                    korrektinput = false;
                    countrynew.Text = "Bitte Österreich Angeben";
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
                else
                {
                    korrektinput = false;
                    mailnew.Text = "Bitte korrekte E-Mail Adresse angeben";
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
                else
                {
                    korrektinput = false;
                    telnew.Text = "Bitte korrekte Telefonnummer angeben";
                }
            }
        }

        public ShoppingBasket(TextBox street1, TextBox firstname1, TextBox lastname1, TextBox city1, TextBox plz1, TextBox country1, TextBox mail1, TextBox tel1) 
        {
         
            streetnew = street1;
            firstnamenew = firstname1;
            lastnamenew = lastname1;
            citynew = city1;
            plznew = plz1;
            countrynew = country1;
            mailnew = mail1;
            telnew = tel1;
            Street = streetnew.Text;
            Firstname = firstnamenew.Text;
            Lastname = lastnamenew.Text;
            City = citynew.Text;
            Plz = plznew.Text;
            Country = countrynew.Text;
            Mail = mailnew.Text;
            Tel = telnew.Text;
            

        }
        public ShoppingBasket(string street, string firstname, string lastname, string city, string plz, string country, string mail, string tel, List<Product> productListe)
        {

            Street = street;
            Firstname = firstname;
            Lastname = lastname;
            City = city;
            Plz = plz;
            Country = country;
            Mail = mail;
            Tel = tel;
            this.productListe = productListe;
        }

        public ShoppingBasket(List<Product> productListe)
		{
            this.productListe = productListe;

        }
        public double bruttoprice()
        {
            double singleprice = 0;
            foreach (Product item in productListe)
            {
                singleprice += item.Quantity * item.Price;
            }
            return singleprice;
        }

        public double deliveryprice()
        {
            
            deliverycost = bruttoprice() * 0.09;
            return Math.Round(deliverycost, 2);
        }
        public double gespreis()
        {

            fullprice = bruttoprice() + deliveryprice();
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

            DateTime today = DateTime.Today;
            List<int> deltimes = new List<int>();
            foreach (var time in productListe)
            {
                deltimes.Add(time.DeliveryTime);
            }
            int maxdeltime = deltimes.Max();

            DateTime deliverdatum = today.AddDays(maxdeltime);
            string formattoday = today.ToString("dd.MM.yyyy");
            string formattodeliverydatum = deliverdatum.ToString("dd.MM.yyyy");


            string header = "MV Development Sudios GMBH & CO KG\nMain Lumber Rd\nBahamas\n\n";
            
            string customerInfo = $"{Firstname}  {Lastname}\n{Street}\n{Plz} {City}\n{Country}\n";
            string billingInfo = $"Rechnungs-Nr: 129012    \nRechnungsdatum: {formattoday}\nLieferdatum: {formattodeliverydatum}\n \nE-mail: {Mail}\nTelefonnummer: {Tel}\n";
        

            //AddProduct();

            // Erstellen Sie eine Tabelle mit zwei Spalten und einer Zeile
            Table table = new Table();
            table.ColumnWidths = "65% 35%";

            // Fügen Sie eine Zeile zur Tabelle hinzu
            Row row = table.Rows.Add();

            // Füge die Daten auf der linken Seite hinzu
            Cell leftCell = row.Cells.Add(header);
            leftCell.Paragraphs[0].Margin = new MarginInfo { Left = 0 }; // Abstand zum linken Rand

            // Fügen Sie die Kundendaten in die rechte Zelle ein
            Cell rightCell = row.Cells.Add(customerInfo);
            rightCell.Paragraphs[0].Margin = new MarginInfo { Left = 20 };

            page.Paragraphs.Add(table);
      
            // Add text fragments to the page
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));



            //page.Paragraphs.Add(new TextFragment(header));
            //page.Paragraphs.Add(new TextFragment(customerInfo));
            page.Paragraphs.Add(new TextFragment(billingInfo));
           



            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("Produkte:"));
            page.Paragraphs.Add(new TextFragment(""));

            Table productTable = new Table();
            productTable.ColumnWidths = "18% 33% 20% 9% 20%"; // Anpassung der Spaltenbreiten

            Row headerRow = productTable.Rows.Add();
            headerRow.Cells.Add("Artikelnummer");
            headerRow.Cells.Add("Produkt");
            headerRow.Cells.Add("Preis");
            headerRow.Cells.Add("Anzahl");
            headerRow.Cells.Add("Lieferzeit");

            // Beispielhaftes Hinzufügen von Produktpositionen

            foreach (var item in productListe)
            {
                Row productRow = productTable.Rows.Add();
                productRow.Cells.Add($"{item.ID}");
                productRow.Cells.Add($"{item.Name}");
                productRow.Cells.Add($"{item.Price}");
                productRow.Cells.Add($"{item.Quantity}");
                productRow.Cells.Add($"{item.DeliveryTime}"); 
            }

            // Fügen Sie die Produkttabelle zur Seite hinzu
            page.Paragraphs.Add(productTable);
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment($"Lieferkosten: {deliveryprice()}"));
            page.Paragraphs.Add(new TextFragment($"Gesamtpreis : {gespreis()}"));
            // Speichern Sie das aktualisierte Dokument
            // Speichern

            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));
            string imagePath = "C:\\Users\\maxim\\OneDrive - HTL-Rankweil\\HTL Rankweil\\2.Klasse\\POS1\\C#\\Shop_bestellsystem\\src\\assets\\e-commerce-1606962_1280.png";

            // Erstellen Sie eine Bildinstanz
            Aspose.Pdf.Image image = new Aspose.Pdf.Image
            {
                File = imagePath
            };

           
            image.FixWidth = 500; 
            image.FixHeight = 400; 

            
            page.Paragraphs.Add(image);
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));


            page.Paragraphs.Add(new TextFragment("AGB:"));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));


            page.Paragraphs.Add(new TextFragment("§1: Alle Inhalte und Dargestellten Produkte können weder gekauft noch beansprucht werden."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§2: Kein Vorgang (wie z.B. Bestellbuttons, Rechnung) in der Anwendung bestätigt einen Zahlungspflichtigen Kauf."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§3: Keiner der abgebildeten Inhalte in der Kategorie \"Shop\" darf als Produkt oder Gutschrift angesehen werden."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§4: Durch die Nutzung der Anwendung wird kein Rechtsgeschäft mit den Entwicklern oder Betreibern der Anwendung eingegangen."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§5: Die \"Rechnung\" stellt nur eine unverbindliche Information dar und begründet keine Zahlungs- oder Lieferverpflichtungen."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§6: Die Entwickler und Betreiber haften nicht für die Korrektheit und Gültigkeit der dargestellten Inhalte, die von externen Dienstleistern stammen."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§7: Die Firmenadresse und der Firmenname sind frei erfunden und wurden nur zu Projektzwecken verwendet, um eine vernünftige Anwendung darzustellen."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§8: Die Entwickler und Betreiber behalten sich das Recht vor, die AGB jederzeit zu ändern. Änderungen werden den Nutzern rechtzeitig mitgeteilt. Die weitere Nutzung der Anwendung nach Bekanntgabe der Änderungen gilt als Zustimmung zu den neuen AGB."));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§9: Gerichtsstand und anwendbares Recht: Es gilt das Recht der Republik Österreich"));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("Nutzungsbedingungen:"));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("§1: Jegliche kommerzielle und nicht-kommerzielle Veröffentlichung der Anwendung ist ohne ausdrückliche Zustimmung aller Betreiber und Entwickler untersagt."));
            





            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, "output.pdf");


            document.Save(filePath);
        }


    }
}
