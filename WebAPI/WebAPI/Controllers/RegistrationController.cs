using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    public class RegistrationController : ApiController
    {
       

        public bool Post([FromBody]Korisnik korisnik)
        {

           foreach (Korisnik kor in Korisnici.korisnici.Values)
           {
               if (kor.KorisnickoIme == korisnik.KorisnickoIme )
                {
                    return false;
                }
           }
           Korisnici.korisnici = new Dictionary<int, Korisnik>();
           SomeType s = new SomeType();
           korisnik.Id = s.GetHashCode();
           korisnik.Uloga = Enums.Uloga.Musterija;
           Korisnici.korisnici.Add(korisnik.Id,korisnik);
           HttpContext.Current.Application["korisnici"] = Korisnici.korisnici;
           UpisTxt(korisnik);
           return true;
            

            
        }

        private void UpisTxt(Korisnik k)
        {
            FileStream stream = new FileStream(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Korisnici.txt", FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga;
                tw.WriteLine(upis);   
             }
            stream.Close();
        }

        public class SomeType
        {
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        public static int GetHashCode2()
        {
            return Int32.MaxValue.GetHashCode();
        }
    }
}
