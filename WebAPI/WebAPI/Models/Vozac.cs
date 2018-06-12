using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class Vozac  : Korisnik
    {
        public Vozac() { }
        public Lokacija Lokacija { get; set; }
        public Automobil Automobil { get; set; }

    }
}