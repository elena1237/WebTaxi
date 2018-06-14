using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAPI.Models.Enums;
namespace WebAPI.Models
{
    public class Automobil
    {
        public int IdVozaca { get; set; }
        public string Godiste { get; set; }
        public string Registracija { get; set; }
        public int BrojVozila { get; set; }
        public TipAutomobila TipAuta { get; set; }

        public Automobil() { }
        public Automobil(int idVozaca,string godiste,string registracija,int brvozila,TipAutomobila tip)
        {
            this.IdVozaca = idVozaca;
            this.Godiste = godiste;
            this.Registracija = registracija;
            this.BrojVozila = brvozila;
            this.TipAuta = tip;
        }
    }
}