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
        public Korisnik Post([FromBody]string vrednost)  //da provjeri ko je ulogovan
        {
 
            foreach (var k in Musterije.musterije.Values)
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

            foreach (var v in Vozaci.vozaci.Values)
            {
                if (v.KorisnickoIme == vrednost)
                {
                    return v;
                }
            }

            return null;

        }
    }
}
