using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebAPI.Models.Enums;

namespace WebAPI.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string JMBG { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public Uloga Uloga { get; set; }
        public bool Banovan { get; set; }
        //public List<Voznja> listaVoznji {get;set; }
        
        public Korisnik() { Banovan = false; }
        public Korisnik(int i,string k, string l,string ime,string p,Pol po,string jmbg,string kont,string ema,Uloga ul)
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
            //listaVoznji = new List<Voznja>();

        }
    }

    
}