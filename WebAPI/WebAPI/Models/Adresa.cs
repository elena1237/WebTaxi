using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Adresa
    {
        public int IdAdr { get; set; }
        public string UlicaIBroj { get; set; }
        public string NaseljenoMjesto { get; set; }
        public string PozivniBroj { get; set; }

        public Adresa() { }

        public Adresa(int idAdr,string ulicabroj,string naseljenomesto,string pozivnibroj)
        {
            IdAdr = idAdr;
            UlicaIBroj = ulicabroj;
            NaseljenoMjesto = naseljenomesto;
            PozivniBroj = pozivnibroj;
        }
    }
}