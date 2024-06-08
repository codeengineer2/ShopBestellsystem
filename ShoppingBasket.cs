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
using Org.BouncyCastle.Bcpg.OpenPgp;



namespace Shop_bestellsystem
{
    public class ShoppingBasket
    {
        
        public List<Product> productListe;
        public bool korrektinput = true;

   
        private double fullprice;
        private double deliverycost;
        private string street;
        private string firstname;
        private string lastname;
        private string city;
        private string plz;
        private string country;
        private string mail;

        
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
                if (value.Length > 0 && value.Length <= 35)
                {
                    street = value;
                }
                else
                {
                    korrektinput = false;
                    streetnew.Text = "Bitte korrekte Adresse angeben";
                    Loggerclass.logger.Error($"Inkorrekte Adresse - zu kurz oder zu Lang -- Länge: {value.Length}");
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
                if (value.Length > 0 && value.Length <= 20)
                {
                    firstname = value;
                }
                else
                {
                    korrektinput = false;
                    firstnamenew.Text = "Bitte korrekten Vornamen angeben";
                    Loggerclass.logger.Error($"Inkorrekter Vorname - Vorname zu kurz oder zu Lang -- Länge: {value.Length}");
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
                if (value.Length >0 && value.Length <= 20)
                {
                    lastname = value;
                }
                else
                {
                    korrektinput = false;
                    lastnamenew.Text = "Bitte korrekten Nachnamen angeben";
                    Loggerclass.logger.Error($"Inkorrekter Nachname - Nachname zu kurz oder zu Lang -- Länge: {value.Length}");
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
                if (value.Length >0 && value.Length <= 25)
                {
                    city = value;
                }
                else
                {
                    korrektinput = false;
                    citynew.Text = "Stadt eingeben";
                    Loggerclass.logger.Error($"Inkorrekte Stadt - Stadt zu kurz oder zu Lang -- Länge: {value.Length}");
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
                    Loggerclass.logger.Error($"Inkorrekte Postleitzahl - PLZ-Format: 0000  -- Länge: {value.Length}, PLZ: {value}");
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
                    Loggerclass.logger.Error($"Inkorrekter Staat - Es muss Österreich oder Austria eingeben werden -- Staat(value): {value}");
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
                if (value.Length > 0 && value.Length <= 35)
                {
                    mail = value;
                }
                else
                {
                    korrektinput = false;
                    mailnew.Text = "Bitte korrekte E-Mail Adresse angeben";
                    Loggerclass.logger.Error($"Inkorrekte E-Mail Adresse - E-Mail Adresse zu kurz oder zu Lang -- Länge: {value.Length}");
                }
            }
        }
       

        public ShoppingBasket(TextBox street1, TextBox firstname1, TextBox lastname1, TextBox city1, TextBox plz1, TextBox country1, TextBox mail1) 
        {
         
            streetnew = street1;
            firstnamenew = firstname1;
            lastnamenew = lastname1;
            citynew = city1;
            plznew = plz1;
            countrynew = country1;
            mailnew = mail1;
            
            Street = streetnew.Text;
            Firstname = firstnamenew.Text;
            Lastname = lastnamenew.Text;
            City = citynew.Text;
            Plz = plznew.Text;
            Country = countrynew.Text;
            Mail = mailnew.Text;
            
            

        }
        public ShoppingBasket(string street, string firstname, string lastname, string city, string plz, string country, string mail, List<Product> productListe)
        {

            Street = street;
            Firstname = firstname;
            Lastname = lastname;
            City = city;
            Plz = plz;
            Country = country;
            Mail = mail;
            
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
            Loggerclass.logger.Information($"Preis von allen Produkte zusammen berechnet: {singleprice}");
            return singleprice;
        }

        public double deliveryprice()
        {
            
            deliverycost = bruttoprice() * 0.09;
            Loggerclass.logger.Information($"Lieferkosten berechnet: {Math.Round(deliverycost, 2)}");
            return Math.Round(deliverycost, 2);
        }
        public double gespreis()
        {

            fullprice = bruttoprice() + deliveryprice();
            Loggerclass.logger.Information($"Preis von allen Produkte zusammen mit Lieferkosten berechnet: {Math.Round(fullprice, 2)}");
            return Math.Round(fullprice, 2);
        }
		
        public string lieferdatum()
        {
            DateTime today = DateTime.Today;
            List<int> deltimes = new List<int>();
            foreach (var time in productListe)
            {
                deltimes.Add(time.DeliveryTime);
            }
            int maxdeltime = deltimes.Max();

            DateTime deliverdatum = today.AddDays(maxdeltime);
            
            string formattodeliverydatum = deliverdatum.ToString("dd.MM.yyyy");
            Loggerclass.logger.Information($"Lieferdatum: {formattodeliverydatum}");
            return formattodeliverydatum;
        }
		

        public void SerializetoPdf()
        {
			Document document = new Document();
            Loggerclass.logger.Information($"PDF: Dokument erstellt!");
            Aspose.Pdf.Page page = document.Pages.Add();
            Loggerclass.logger.Information($"PDF: Seite hinzugefügt!");
            DateTime today = DateTime.Today;
            string formattoday = today.ToString("dd.MM.yyyy");


            Random random = new Random();
            int bestellnummer = random.Next(10535, 100000);
            string header = "MV Development Sudios GMBH & CO KG\nMain Lumber Rd\nBahamas\n\n";
            
            string customerInfo = $"{Firstname}  {Lastname}\n{Street}\n{Plz} {City}\n{Country}\n";
            string billingInfo = $"Rechnungs-Nr: {bestellnummer}    \nRechnungsdatum: {formattoday}\nLieferdatum: {lieferdatum()}\n \nE-mail: {Mail}\n";
        

            Table table = new Table();
            Loggerclass.logger.Information($"PDF: Tabelle erstellt");
            table.ColumnWidths = "65% 35%";

            Row row = table.Rows.Add();

            Cell leftCell = row.Cells.Add(header);
            leftCell.Paragraphs[0].Margin = new MarginInfo { Left = 0 }; // Abstand zum linken Rand

     
            Cell rightCell = row.Cells.Add(customerInfo);
            rightCell.Paragraphs[0].Margin = new MarginInfo { Left = 20 };

            page.Paragraphs.Add(table);
      
            
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));



           
            page.Paragraphs.Add(new TextFragment(billingInfo));
           



            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment("Produkte:"));
            page.Paragraphs.Add(new TextFragment(""));

            Table productTable = new Table();
            productTable.ColumnWidths = "18% 33% 20% 9% 20%"; 

            Row headerRow = productTable.Rows.Add();
            headerRow.Cells.Add("Artikelnummer");
            headerRow.Cells.Add("Produkt");
            headerRow.Cells.Add("Preis");
            headerRow.Cells.Add("Anzahl");
            headerRow.Cells.Add("Lieferzeit");

          

            foreach (var item in productListe)
            {
                Row productRow = productTable.Rows.Add();
                productRow.Cells.Add($"{item.ID}");
                productRow.Cells.Add($"{item.Name}");
                productRow.Cells.Add($"{item.Price}€");
                productRow.Cells.Add($"{item.Quantity}");
                productRow.Cells.Add($"{item.DeliveryTime} Tage"); 
            }
            Loggerclass.logger.Information($"Warenkorb in PDF Tabelle hinzugefügt!");
       
            page.Paragraphs.Add(productTable);
            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment($"Lieferkosten: {deliveryprice()}€"));
            page.Paragraphs.Add(new TextFragment($"Gesamtpreis : {gespreis()}€"));
          

            page.Paragraphs.Add(new TextFragment(""));
            page.Paragraphs.Add(new TextFragment(""));
            //string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
            //string imagePath = Path.Combine(projectPath, "src", "assets", "e-commerce-1606962_1280.png");
            string imagePath = "C:\\Users\\maxim\\OneDrive - HTL-Rankweil\\HTL Rankweil\\2.Klasse\\POS1\\C#\\Shop_bestellsystem\\src\\assets\\e-commerce-1606962_1280.png";


            Loggerclass.logger.Information($"Image Path erstellt {imagePath}");
            Aspose.Pdf.Image image = new Aspose.Pdf.Image
            {
                File = imagePath
            };

           
            image.FixWidth = 400; 
            image.FixHeight = 250;
            page.Paragraphs.Add(image);
            Loggerclass.logger.Information($"Bild in Rechnung hinzugefügt");
            // Zugriff auf die zweite Seite des Dokuments
            Aspose.Pdf.Page secondPage = document.Pages.Add();
            Loggerclass.logger.Information($"Zweite Seite erstellt");

            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment(""));

            secondPage.Paragraphs.Add(new TextFragment("AGB:"));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment(""));

            secondPage.Paragraphs.Add(new TextFragment("§1: Alle Inhalte und Dargestellten Produkte können weder gekauft noch beansprucht werden."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§2: Kein Vorgang (wie z.B. Bestellbuttons, Rechnung) in der Anwendung bestätigt einen Zahlungspflichtigen Kauf."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§3: Keiner der abgebildeten Inhalte in der Kategorie \"Shop\" darf als Produkt oder Gutschrift angesehen werden."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§4: Durch die Nutzung der Anwendung wird kein Rechtsgeschäft mit den Entwicklern oder Betreibern der Anwendung eingegangen."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§5: Die \"Rechnung\" stellt nur eine unverbindliche Information dar und begründet keine Zahlungs- oder Lieferverpflichtungen."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§6: Die Entwickler und Betreiber haften nicht für die Korrektheit und Gültigkeit der dargestellten Inhalte, die von externen Dienstleistern stammen."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§7: Die Firmenadresse und der Firmenname sind frei erfunden und wurden nur zu Projektzwecken verwendet, um eine vernünftige Anwendung darzustellen."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§8: Die Entwickler und Betreiber behalten sich das Recht vor, die AGB jederzeit zu ändern. Änderungen werden den Nutzern rechtzeitig mitgeteilt. Die weitere Nutzung der Anwendung nach Bekanntgabe der Änderungen gilt als Zustimmung zu den neuen AGB."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§9: Gerichtsstand und anwendbares Recht: Es gilt das Recht der Republik Österreich"));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("Nutzungsbedingungen:"));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§1: Jegliche kommerzielle und nicht-kommerzielle Veröffentlichung der Anwendung ist ohne ausdrückliche Zustimmung aller Betreiber und Entwickler untersagt."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§2: Weitergabe des Programms kann ohne ausdrückliche Zustimmeung aller Entwickler und Betreiber als Vertragsbruch gesehen werden."));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§3: Personenbezogene Daten wie(Name, Adresse usw.) werden nicht an externe Anbieter weitergeleitetet"));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§4: Bei Downloaden der Rechnung werden ihre Daten automatisch in die Rechnung Reinkopiert und Lokal auf ihren Rechner Heruntergeladen"));
            secondPage.Paragraphs.Add(new TextFragment(""));
            secondPage.Paragraphs.Add(new TextFragment("§5: Mit dem Erhalt der Rechnung Akzeptieren Sie jegliche Nutzungsbedingungen und AGBs"));

            Loggerclass.logger.Information($"Nutzungsbedingungen sowie AGBs hinzugefügt!");




            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string filePath = Path.Combine(downloadsPath, $"bill_{bestellnummer}.pdf");
            Loggerclass.logger.Information($"Speicherpfad erstellt");

            document.Save(filePath);
            Loggerclass.logger.Information($"Datei abgespeichert in {filePath}");
        }


    }
}
