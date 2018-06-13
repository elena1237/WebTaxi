using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class Voznja
    {
        public string Id { get; set; }
        public DateTime DTPorudzbe { get; set; }
        public Lokacija Dolazak { get; set; }

        public TipAutomobila TipAuta { get; set; }

        public Korisnik Musterija { get; set; }
        
        public Lokacija Odrediste { get; set; }

        public Dispecer Dispecer { get; set; }

        public Vozac Vozac { get; set; }
        public double Iznos { get; set; }
        public Komentar Komentar { get; set; }
        public StatusVoznje StatusVoznje { get; set; }

    }
}