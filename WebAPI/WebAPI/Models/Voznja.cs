using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class Voznja
    {
        public int IdVoznje { get; set; }
        public DateTime DTPorudzbine { get; set; }
        public Lokacija Dolazak { get; set; }

        public TipAutomobila TipAutaVoznje { get; set; }

        public string MusterijaVoznja { get; set; }
        
        public Lokacija Odrediste { get; set; }

        public string DispecerVoznja { get; set; }

        public string VozacVoznja { get; set; }
        public double Iznos { get; set; }
        public Komentar Komentar { get; set; }
        public StatusVoznje StatusVoznje { get; set; }

        public Voznja() { }
        public Voznja(int idvoznje,DateTime dtporudzbine,Lokacija dolazak,TipAutomobila tipAutomobila,string musterija,Lokacija odrediste, string vozac,double iznos, string dispecer,Komentar komentar,StatusVoznje statusVoznje)
        {
            this.IdVoznje = idvoznje;
            this.DTPorudzbine = dtporudzbine;
            this.Dolazak = dolazak;
            if (tipAutomobila.Equals("Kombi"))
            {
                this.TipAutaVoznje = TipAutomobila.Kombi;
            }
            else
            {
                this.TipAutaVoznje = TipAutomobila.Putnicki;
            }

            this.MusterijaVoznja = musterija;
            this.Odrediste = odrediste;
            this.DispecerVoznja = dispecer;
            this.VozacVoznja = vozac;
            this.Iznos = iznos;
            this.Komentar = komentar;

            if (statusVoznje.ToString().Equals("Formirana"))
            {
                this.StatusVoznje = StatusVoznje.Formirana;
            }
            else if (statusVoznje.ToString().Equals("Kreirana"))
            {
                this.StatusVoznje = StatusVoznje.Kreirana;
            }
            else if (statusVoznje.ToString().Equals("Neuspjesna"))
            {
                this.StatusVoznje = StatusVoznje.Neuspjesna;
            }
            else if (statusVoznje.ToString().Equals("Obradjena"))
            {
                this.StatusVoznje = StatusVoznje.Obradjena;
            }
            else if (statusVoznje.ToString().Equals("Otkazana"))
            {
                this.StatusVoznje = StatusVoznje.Otkazana;
            }
            else if (statusVoznje.ToString().Equals("Prihvacena"))
            {
                this.StatusVoznje = StatusVoznje.Prihvacena;
            }
            else if (statusVoznje.ToString().Equals("Uspjesna"))
            {
                this.StatusVoznje = StatusVoznje.Uspjesna;
            }
            else
            {
                this.StatusVoznje = StatusVoznje.Utoku;
            }
           
        }

    }
}