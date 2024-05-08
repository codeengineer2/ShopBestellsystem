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
        public string deliverycost;
        public string deliverytime;
        public string street;
        public string country;
        public string firstname;
        public string lastname;
        public string stadt;
        public int plz;
        public int artnum;

        public double Fullprice { get; set; }
        public string Deliverycost { get; set; }
        public string Deliverytime { get; set; }

        public string Street { get; set; }

        public string Country { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Stadt { get; set; }
        public int Plz { get; set; }
        public int Artnum { get; set; }





        private List<string> _liste = new List<string>();

        public void AddItem()
        {
            _liste.Add("0", "2", "Mercedes CLA Coupe 220d");
        }
        


    }
}
