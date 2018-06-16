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
            }


            Voznje.voznje = new Dictionary<int, Voznja>();  ////////////////
            SomeType s = new SomeType();
            voznja.IdVoznje = s.GetHashCode();
            voznja.DTPorudzbine = DateTime.Now;
            voznja.Komentar = new Komentar();
            voznja.Odrediste = new Lokacija();
            Voznje.voznje.Add(voznja.IdVoznje, voznja);
            UpisTxt(voznja);
            return true;

        }

        private void UpisTxt(Voznja k)
        {
            FileStream stream = new FileStream(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Voznje.txt", FileMode.Append);
            using (StreamWriter tw = new StreamWriter(stream))
            {
                string upis = k.IdVoznje.ToString() + '|' + k.DTPorudzbine.ToString() + '|' + k.Dolazak.IdLok.ToString() + '|' + k.Dolazak.X.ToString() + '|' + k.Dolazak.Y.ToString() + '|' + k.Dolazak.Adresa.IdAdr.ToString() + '|' + k.Dolazak.Adresa.UlicaIBroj + '|' + k.Dolazak.Adresa.NaseljenoMjesto + '|' + k.Dolazak.Adresa.PozivniBroj + '|' + k.TipAutaVoznje + '|' + k.MusterijaVoznja + '|' + k.Odrediste.IdLok.ToString() + '|' + k.Odrediste.X.ToString() + '|' + k.Odrediste.Y.ToString() + '|' + k.Odrediste.Adresa.IdAdr.ToString() + '|' + k.Odrediste.Adresa.UlicaIBroj + '|' + k.Odrediste.Adresa.NaseljenoMjesto + '|' + k.Odrediste.Adresa.PozivniBroj + '|'  + k.VozacVoznja + '|' + k.Iznos.ToString() +'|' + k.DispecerVoznja + '|' +k.Komentar.Opis  + '|' + k.Komentar.DTObjave.ToString() + '|' + k.Komentar.KorImeKorisnikKomentar + '|' + k.Komentar.IdVoznjaKomentar.ToString() + '|' + k.Komentar.Ocjena.ToString() + '|' + k.StatusVoznje + '\n';
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


        // GET api/voznja/5
        public Dictionary<int,Voznja> Get()
        {
            return Voznje.voznje;
        }
    }
}
