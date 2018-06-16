using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebAPI.Models
{
    public class Enums
    {
      public enum Pol { M, Z}
      public enum Uloga { Dispecer, Musterija, Vozac}
      public enum TipAutomobila { Putnicki, Kombi}
      public enum StatusVoznje { Kreirana, Formirana, Obradjena, Prihvacena, Otkazana, Neuspjesna, Uspjesna, Utoku}
    }
}