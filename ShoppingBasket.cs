using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

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
            /*Verkäufer*/
            Console.WriteLine("MV Krypto Sales&Marketing GMBH & CO KG");
            Console.WriteLine("Main Lumber Rd");
            Console.WriteLine("Bahamas");
            /*Käufer*/
            Console.WriteLine("{Firstname} {Lastname}");
            Console.WriteLine("{Street}, {Country}");
            Console.WriteLine("{Plz} {Stadt}");
            /*Rechnung*/
            Console.WriteLine("Rechnungs-Nr:    {BestellundRechnungsnummer}");
            Console.WriteLine("Rechnungsdatum:    {Datum}");
            Console.WriteLine("Lieferdatum:    {Datum+Deliverytime}");
            Console.WriteLine("E-Mail:    {email}");
            Console.WriteLine("\nPositionen:");
            Console.WriteLine("{0,-10} {1,-30} {2,10} {3,10} {4,10}", "Pos.", "Bezeichnung", "Menge", "E-Preis", "Gesamt");



        }

    }
}
