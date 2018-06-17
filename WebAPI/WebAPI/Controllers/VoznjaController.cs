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
    public class VoznjaController : ApiController
    {
        // POST api/voznja
        public bool Post([FromBody]Voznja voznja)
        {

            if (Voznje.voznje != null)
            {
                foreach (Voznja kor in Voznje.voznje.Values)
                {
                    if (kor.Dolazak.Adresa.UlicaIBroj == voznja.Dolazak.Adresa.UlicaIBroj)
                    {
                        return false;
                    }
                }
                SomeType s = new SomeType();
                voznja.IdVoznje = s.GetHashCode();
                voznja.DTPorudzbine = DateTime.Now;
                if(voznja.MusterijaVoznja!=null)
                {
                    voznja.StatusVoznje = Enums.StatusVoznje.Kreirana;
                }else if(voznja.DispecerVoznja!=null)
                {
                    voznja.StatusVoznje = Enums.StatusVoznje.Formirana;
                }
                else
                {
                    voznja.StatusVoznje = Enums.StatusVoznje.Prihvacena;
                }
                voznja.Komentar = new Komentar();
                voznja.Odrediste = new Lokacija();
                Voznje.voznje.Add(voznja.IdVoznje, voznja);
                UpisTxt(voznja);
                return true;
            }

            if (Voznje.voznje == null)
            {
                Voznje.voznje = new Dictionary<int, Voznja>();  
                SomeType s = new SomeType();
                voznja.IdVoznje = s.GetHashCode();
                voznja.DTPorudzbine = DateTime.Now;
                if (voznja.MusterijaVoznja != null && voznja.StatusVoznje != Enums.StatusVoznje.Otkazana)
                {
                    voznja.StatusVoznje = Enums.StatusVoznje.Kreirana;
                }
                else if (voznja.DispecerVoznja != null)
                {
                    voznja.StatusVoznje = Enums.StatusVoznje.Formirana;
                }
                else
                {
                    voznja.StatusVoznje = Enums.StatusVoznje.Prihvacena;
                }
                voznja.Komentar = new Komentar();
                voznja.Odrediste = new Lokacija();
                Voznje.voznje.Add(voznja.IdVoznje, voznja);
                UpisTxt(voznja);
                return true;
            }
            return false;

        }

        private void UpisTxt(Voznja k)
        {
            FileStream stream = new FileStream(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Voznje.txt", FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = k.IdVoznje.ToString() + '|' + k.DTPorudzbine.ToString() + '|' + k.Dolazak.IdLok.ToString() + '|' + k.Dolazak.X.ToString() + '|' + k.Dolazak.Y.ToString() + '|' + k.Dolazak.Adresa.IdAdr.ToString() + '|' + k.Dolazak.Adresa.UlicaIBroj + '|' + k.Dolazak.Adresa.NaseljenoMjesto + '|' + k.Dolazak.Adresa.PozivniBroj + '|' + k.TipAutaVoznje + '|' + k.MusterijaVoznja + '|' + k.Odrediste.IdLok.ToString() + '|' + k.Odrediste.X.ToString() + '|' + k.Odrediste.Y.ToString() + '|' + k.Odrediste.Adresa.IdAdr.ToString() + '|' + k.Odrediste.Adresa.UlicaIBroj + '|' + k.Odrediste.Adresa.NaseljenoMjesto + '|' + k.Odrediste.Adresa.PozivniBroj + '|'  + k.VozacVoznja + '|' + k.Iznos.ToString() +'|' + k.DispecerVoznja + '|' +k.Komentar.Opis  + '|' + k.Komentar.DTObjave.ToString() + '|' + k.Komentar.KorImeKorisnikKomentar + '|' + k.Komentar.IdVoznjaKomentar.ToString() + '|' + k.Komentar.Ocjena.ToString() + '|' + k.StatusVoznje;
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


        // GET api/voznja
        public Dictionary<int,Voznja> Get()
        {
            return Voznje.voznje;
        }

        // GET api/values/5
        //public string Get(int id)
        //{

        //    return "value";
        //}



        // PUT api/voznja/5
        public bool Put(int id, [FromBody]Voznja korisnik)
        {
            foreach (Voznja kor in Voznje.voznje.Values)
            {
                if (kor.IdVoznje == id)
                {
                    korisnik.TipAutaVoznje = kor.TipAutaVoznje;
                    korisnik.IdVoznje = kor.IdVoznje;
                    korisnik.DTPorudzbine = DateTime.Now;
                    if (korisnik.MusterijaVoznja != null && kor.StatusVoznje != Enums.StatusVoznje.Otkazana)
                    {
                        korisnik.StatusVoznje = Enums.StatusVoznje.Kreirana;
                    }
                    else if (korisnik.DispecerVoznja != null)
                    {
                        korisnik.StatusVoznje = Enums.StatusVoznje.Formirana;
                    }
                    else if(korisnik.VozacVoznja!=null)
                    {
                        korisnik.StatusVoznje = Enums.StatusVoznje.Prihvacena;
                    } else
                    {
                        korisnik.StatusVoznje = kor.StatusVoznje;
                    }

                    if (kor.Komentar != null)
                    {
                        korisnik.Komentar = new Komentar();
                        korisnik.Komentar = kor.Komentar;
                    } else
                    {
                        korisnik.Komentar = new Komentar();
                    }
                    korisnik.Odrediste = new Lokacija();
                    Voznje.voznje.Remove(kor.IdVoznje);
                    Voznje.voznje.Add(korisnik.IdVoznje, korisnik);
                    UpisIzmjenaTxt(korisnik);
                    return true;
                }
            }
            return false;
        }

        private void UpisIzmjenaTxt(Voznja k)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Voznje.txt");
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.IdVoznje.ToString()))
                {
                    allString += k.IdVoznje.ToString() + '|' + k.DTPorudzbine.ToString() + '|' + k.Dolazak.IdLok.ToString() + '|' + k.Dolazak.X.ToString() + '|' + k.Dolazak.Y.ToString() + '|' + k.Dolazak.Adresa.IdAdr.ToString() + '|' + k.Dolazak.Adresa.UlicaIBroj + '|' + k.Dolazak.Adresa.NaseljenoMjesto + '|' + k.Dolazak.Adresa.PozivniBroj + '|' + k.TipAutaVoznje + '|' + k.MusterijaVoznja + '|' + k.Odrediste.IdLok.ToString() + '|' + k.Odrediste.X.ToString() + '|' + k.Odrediste.Y.ToString() + '|' + k.Odrediste.Adresa.IdAdr.ToString() + '|' + k.Odrediste.Adresa.UlicaIBroj + '|' + k.Odrediste.Adresa.NaseljenoMjesto + '|' + k.Odrediste.Adresa.PozivniBroj + '|' + k.VozacVoznja + '|' + k.Iznos.ToString() + '|' + k.DispecerVoznja + '|' + k.Komentar.Opis + '|' + k.Komentar.DTObjave.ToString() + '|' + k.Komentar.KorImeKorisnikKomentar + '|' + k.Komentar.IdVoznjaKomentar.ToString() + '|' + k.Komentar.Ocjena.ToString() + '|' + k.StatusVoznje;
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Voznje.txt", lines);

        }
    }
}
