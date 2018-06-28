using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        
        public bool Post([FromBody]Korisnik korisnik)
        {
            if (String.IsNullOrEmpty(korisnik.KorisnickoIme) || String.IsNullOrEmpty(korisnik.Lozinka))
            {
                return false;
            }

            Regex r1 = new Regex("[0-9a-zA-Z]{3,}"); //korisnicko ime 
            Regex r2 = new Regex("[0-9a-zA-Z]{4,}"); //lozinka
            if (!r1.IsMatch(korisnik.KorisnickoIme) || !r2.IsMatch(korisnik.Lozinka))
            {
                return false;
            }




            foreach (Musterija kor in Musterije.musterije.Values)
              {
                   if (kor.KorisnickoIme == korisnik.KorisnickoIme && kor.Lozinka==korisnik.Lozinka)
                   {
                        return true;
                   }

              }
              foreach (Dispecer d in Dispeceri.dispeceri.Values)
              {
                  if (d.KorisnickoIme == korisnik.KorisnickoIme && d.Lozinka == korisnik.Lozinka)
                  {
                       return true;
                  }

              }
              foreach (Vozac v in Vozaci.vozaci.Values)
              {
                  if (v.KorisnickoIme == korisnik.KorisnickoIme && v.Lozinka == korisnik.Lozinka)
                  {
                      return true;
                  }
              }



            return false;
  
        }
        

    }
}
