using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class Musterija : Korisnik
    {
        public Musterija() { }
        

        public Musterija(int i, string k, string l, string ime, string p, Pol po, string jmbg, string kont, string ema, Uloga ul,bool banovan)
        {
            this.Id = i;
            this.KorisnickoIme = k;
            this.Lozinka = l;
            this.Ime = ime;
            this.Prezime = p;
            if (po.Equals("M"))
            {
                this.Pol = Pol.M;
            }
            else
            {
                this.Pol = Pol.Z;
            }
            this.JMBG = jmbg;
            this.KontaktTelefon = kont;
            this.Email = ema;

            if (ul.ToString().Equals("Musterija"))
            {
                this.Uloga = Uloga.Musterija;
            }
            else if (ul.ToString().Equals("Dispecer"))
            {
                this.Uloga = Uloga.Dispecer;
            }
            else
            {
                this.Uloga = Uloga.Vozac;
            }
            this.Banovan = banovan;
        }

    }
}