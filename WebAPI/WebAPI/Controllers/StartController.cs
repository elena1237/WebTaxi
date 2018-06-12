using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class StartController : ApiController
    {
        public Korisnik Post([FromBody]string vrednost)
        {
            

            foreach (var k in Korisnici.korisnici.Values)
            {
                if(k.KorisnickoIme==vrednost)
                {
                    return k;
                }
            }

            foreach(var d in Dispeceri.dispeceri.Values)
            {
                if (d.KorisnickoIme == vrednost)
                {
                    return d;
                }
            }

            return null;

        }
    }
}
