using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf;
using System.IO;
using Aspose.Pdf.Text;



namespace Shop_bestellsystem
{
    public class ShoppingBasket
    {
        public double fullprice;
        public double deliverycost;
        public string deliverytime;
        public string street;
        public string country;
        public string firstname;
        public string lastname;
        public string stadt;
        public int plz;
        public int artnum;

        public double Fullprice { get; set; }
        public double Deliverycost { get; set; }
        public string Deliverytime { get; set; }

        public string Street { get; set; }

        public string Country { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Stadt { get; set; }
        public int Plz { get; set; }
        public int Artnum { get; set; }

        public ShoppingBasket()
        {

        }




        public void SerializetoPdf()
        {
            Document document = new Document();
            // add a page
            Page page = document.Pages.Add();
            // add text to the new page
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("MV Krypto Sales&Marketing GMBH & CO KG"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Main Lumber Rd"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Bahamas"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(""));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(""));
;
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("{Firstname} {Lastname}"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("{Street}, {Country}"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("{Plz} {Stadt}"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(""));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(""));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(""));

            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Rechnungs-Nr:    {BestellundRechnungsnummer}"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Rechnungsdatum:    {Datum}"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Lieferdatum:    {Datum+Deliverytime}"));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(""));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("E-Mail:    {email}"));

            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("\nPositionen:"));

            // save PDF document
            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            // Erstellen Sie den vollständigen Pfad zur Datei
            string filePath = Path.Combine(downloadsPath, "output.pdf");
            document.Save(filePath);
        }
        /*
        
        */


    }

}

