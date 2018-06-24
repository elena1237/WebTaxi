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
    public class MusterijaController : ApiController
    {
        //PUT api/musterija/5
        public bool Put(int id, [FromBody]Musterija korisnik)
        {
            foreach (Musterija kor in Musterije.musterije.Values)
            {
                if (kor.Id == id)
                {
                    if(korisnik.KorisnickoIme==null)
                    {
                        korisnik.KorisnickoIme = kor.KorisnickoIme;
                    }
                    if (korisnik.Lozinka == null)
                    {
                        korisnik.Lozinka = kor.Lozinka;
                    }
                    if (korisnik.Ime == null)
                    {
                        korisnik.Ime = kor.Ime;
                    }
                    if (korisnik.Prezime == null)
                    {
                        korisnik.Prezime = kor.Prezime;
                    }
                    korisnik.Pol = kor.Pol;
                    if (korisnik.JMBG == null)
                    {
                        korisnik.JMBG = kor.JMBG;
                    }
                    if (korisnik.Email == null)
                    {
                        korisnik.Email = kor.Email;
                    }
                    if (korisnik.KontaktTelefon == null)
                    {
                        korisnik.KontaktTelefon = kor.KontaktTelefon;
                    }
                    korisnik.Uloga = kor.Uloga;

                    Musterije.musterije.Remove(kor.Id);
                    Musterije.musterije.Add(korisnik.Id, korisnik);
                    UpisIzmjenaTxt(korisnik);
                    return true;
                }
            }
            return false;
        }


        private void UpisIzmjenaTxt(Musterija k)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Musterije.txt");
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.Id.ToString()))
                {
                    allString += k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga + '|' + k.Banovan.ToString();
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Musterije.txt", lines);

        }


        // GET api/musterija
        public Dictionary<int, Musterija> Get()
        {
            return Musterije.musterije;
        }

        // GET api/musterija/5
        public Musterija Get(int id)
        {
            return Musterije.musterije[id];
        }

        // POST api/musterija
        public bool Post([FromBody]Musterija korisnik)
        {

            foreach (Musterija kor in Musterije.musterije.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }
            foreach (Vozac kor in Vozaci.vozaci.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }

            foreach (Dispecer kor in Dispeceri.dispeceri.Values)
            {
                if (kor.KorisnickoIme == korisnik.KorisnickoIme)
                {
                    return false;
                }
            }

            Musterije.musterije = new Dictionary<int, Musterija>();
            SomeType s = new SomeType();
            korisnik.Id = s.GetHashCode();
            korisnik.Uloga = Enums.Uloga.Musterija;
            Musterije.musterije.Add(korisnik.Id, korisnik);
            UpisTxt(korisnik);
            return true;

        }

        private void UpisTxt(Musterija k)
        {
            FileStream stream = new FileStream(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Musterije.txt", FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga + '|' + k.Banovan.ToString();
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
