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
        public Lokacija LokacijaDolaska { get; set; }

        public Korisnik Musterija { get; set; }
        
        public Lokacija Odrediste { get; set; }

        public Korisnik Dispecer { get; set; }

        public Vozac Vozac { get; set; }
        public int Iznos { get; set; }
        public Komentar Komentar { get; set; }
        public StatusVoznje StatusVoznje { get; set; }

    }
}