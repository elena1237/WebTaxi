using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class KorisnikController : ApiController
    {
        // PUT api/korisnik/5
        
        public bool Put(int id, [FromBody]Korisnik korisnik)
        {
            if (korisnik.Uloga == Enums.Uloga.Musterija)
            {
                foreach (Korisnik kor in Korisnici.korisnici.Values)
                {
                    if (kor.Id == id)
                    {
                        Korisnici.korisnici.Remove(kor.Id);
                        Korisnici.korisnici.Add(korisnik.Id, korisnik);
                        UpisIzmjenaTxt(korisnik);
                        return true;
                    }
                }
                return false;
            }
            else if (korisnik.Uloga == Enums.Uloga.Dispecer)
            {
                foreach (Dispecer kor in Dispeceri.dispeceri.Values)
                {
                    if (kor.Id == id)
                    {
                        Dispeceri.dispeceri.Remove(kor.Id);
                        Dispecer d = new Dispecer(korisnik.Id, korisnik.KorisnickoIme, korisnik.Lozinka, korisnik.Ime, korisnik.Prezime, korisnik.Pol, korisnik.JMBG, korisnik.KontaktTelefon, korisnik.Email, korisnik.Uloga);
                        Dispeceri.dispeceri.Add(d.Id, d);
                        UpisIzmjenaDispTxt(korisnik);
                        return true;
                    }
                }
                return false;
            }
            else 
            {
               
                return false;
            }
            
        }




        private void UpisIzmjenaTxt(Korisnik k)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Korisnici.txt");
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.Id.ToString()))
                {
                    allString += k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga;
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Korisnici.txt", lines);

        }


        private void UpisIzmjenaDispTxt(Korisnik k)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Dispeceri.txt");
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.Id.ToString()))
                {
                    allString += k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga;
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Dispeceri.txt", lines);
        }

        // POST api/korisnik
        public bool Post([FromBody]Korisnik korisnik)
        {

            foreach (Korisnik kor in Korisnici.korisnici.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }

            Korisnici.korisnici = new Dictionary<int, Korisnik>();
            SomeType s = new SomeType();
            korisnik.Id = s.GetHashCode();
            korisnik.Uloga = Enums.Uloga.Musterija;
            Korisnici.korisnici.Add(korisnik.Id, korisnik);
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
