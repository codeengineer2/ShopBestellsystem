using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Reflection.Metadata;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Quality;
using PdfSharp.Snippets.Font;
using PdfSharp.Pdf.IO;


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






        public void Serializetotxt()
        {
            if (Capabilities.Build.IsCoreBuild)
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();
            var document = new PdfDocument();
            document.Info.Title = "Rechnung";
            document.Info.Author = "MV Krypto Sales&Marketing GMBH & CO KG";
            document.Info.Subject = "Rechnung des Auftrages";
            var page = document.AddPage();
            page.Size = PageSize.A4;
            page.Orientation = PageOrientation.Landscape;
            var gfx = XGraphics.FromPdfPage(page);
            var width = page.Width;
            var height = page.Height;
            gfx.DrawLine(XPens.Red, 0, 0, width, height);
            gfx.DrawLine(XPens.Red, width, 0, 0, height);
            var r = width / 5;
            gfx.DrawEllipse(new XPen(XColors.Red, 1.5), XBrushes.White, new XRect(width / 2 - r, height / 2 - r, 2 * r, 2 * r));
            var font = new XFont("Times New Roman", 20, XFontStyleEx.BoldItalic);
            gfx.DrawString("Hello, PDFsharp!", font, XBrushes.Black,
                new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
            var filename = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), ".pdf");
            document.Save(filename);
            // ...and start a viewer.
            // System.IO.Path.StartPdfViewer(filename);
        }
        /*
        Console.WriteLine("MV Krypto Sales&Marketing GMBH & CO KG");
        Console.WriteLine("Main Lumber Rd");
        Console.WriteLine("Bahamas");
        Console.WriteLine("{Firstname} {Lastname}");
        Console.WriteLine("{Street}, {Country}");
        Console.WriteLine("{Plz} {Stadt}");
        Console.WriteLine("Rechnungs-Nr:    {BestellundRechnungsnummer}");
        Console.WriteLine("Rechnungsdatum:    {Datum}");
        Console.WriteLine("Lieferdatum:    {Datum+Deliverytime}");
        Console.WriteLine("E-Mail:    {email}");
        Console.WriteLine("\nPositionen:");
        Console.WriteLine("{0,-10} {1,-30} {2,10} {3,10} {4,10}", "Pos.", "Bezeichnung", "Menge", "E-Preis", "Gesamt");
        */


    }

    }
}
