using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class Voznja1Controller : ApiController
    {
        // PUT api/voznja1/5
        public bool Put(int id, [FromBody]Voznja korisnik)
        {
            foreach (Voznja kor in Voznje.voznje.Values)
            {
                if (kor.IdVoznje == id)
                {
                    korisnik.TipAutaVoznje = kor.TipAutaVoznje;
                    korisnik.IdVoznje = kor.IdVoznje;
                    korisnik.DTPorudzbine = DateTime.Now;
                    if (korisnik.MusterijaVoznja != null && korisnik.StatusVoznje == Enums.StatusVoznje.Kreirana)
                    {
                        korisnik.StatusVoznje = Enums.StatusVoznje.Otkazana;
                        korisnik.Dolazak = new Lokacija();
                        korisnik.Dolazak.IdLok = kor.Dolazak.IdLok;
                        korisnik.Dolazak.X = kor.Dolazak.X;
                        korisnik.Dolazak.Y = kor.Dolazak.Y;
                        korisnik.Dolazak.Adresa.IdAdr = kor.Dolazak.Adresa.IdAdr;
                        korisnik.Dolazak.Adresa.UlicaIBroj = kor.Dolazak.Adresa.UlicaIBroj;
                        korisnik.Dolazak.Adresa.NaseljenoMjesto = kor.Dolazak.Adresa.NaseljenoMjesto;
                        korisnik.Dolazak.Adresa.PozivniBroj = kor.Dolazak.Adresa.PozivniBroj;
                        korisnik.Odrediste = new Lokacija();
                    }
                    else if (korisnik.DispecerVoznja != null)
                    {
                        korisnik.StatusVoznje = Enums.StatusVoznje.Otkazana;
                    }
                    else if (korisnik.VozacVoznja != null)
                    {
                        korisnik.StatusVoznje = Enums.StatusVoznje.Otkazana;
                    } else
                    {
                        return false;
                    }
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
