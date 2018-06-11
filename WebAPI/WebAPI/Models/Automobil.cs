using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAPI.Models.Enums;
namespace WebAPI.Models
{
    public class Automobil
    {
        public Vozac Vozac { get; set; }
        public string Registracija { get; set; }
        public string BrojVozila { get; set; }
        public TipAutomobila TipAuta { get; set; }
    }
}