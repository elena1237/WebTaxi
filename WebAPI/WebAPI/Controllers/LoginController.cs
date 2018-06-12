using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LoginController : ApiController
    {
        
        public bool Post([FromBody]Korisnik korisnik)
        {
              foreach (Korisnik kor in Korisnici.korisnici.Values)
              {
                   if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                   {
                        return true;
                   }

              }
              foreach (Dispecer d in Dispeceri.dispeceri.Values)
              {
                  if (d.KorisnickoIme == korisnik.KorisnickoIme)
                  {
                       return true;
                  }

              }

             return false;
  
        }
        

    }
}
