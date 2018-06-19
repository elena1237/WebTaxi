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
                    korisnik.DTPorudzbine = kor.DTPorudzbine;
                    if (korisnik.MusterijaVoznja != null && korisnik.VozacVoznja==null)
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
                        korisnik.StatusVoznje = Enums.StatusVoznje.Obradjena;
                        foreach (Vozac v in Vozaci.vozaci.Values)
                        {
                            if (v.KorisnickoIme == korisnik.VozacVoznja)
                            {
                                v.Zauzet = true;
                                UpisIzmjenaTxtVozac(v);
                            }
                        }
                        korisnik.MusterijaVoznja = kor.MusterijaVoznja;
                        korisnik.Komentar = kor.Komentar;
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

        private void UpisIzmjenaTxtVozac(Vozac k)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Vozaci.txt");
            string allString = "";
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(k.Id.ToString()))
                {
                    allString += k.Id.ToString() + '|' + k.KorisnickoIme + '|' + k.Lozinka + '|' + k.Ime + '|' + k.Prezime + '|' + k.Pol + '|' + k.JMBG + '|' + k.KontaktTelefon + '|' + k.Email + '|' + k.Uloga + '|' + k.Lokacija.IdLok.ToString() + '|' + k.Lokacija.X.ToString() + '|' + k.Lokacija.Y.ToString() + '|' + k.Lokacija.Adresa.IdAdr.ToString() + '|' + k.Lokacija.Adresa.UlicaIBroj + '|' + k.Lokacija.Adresa.NaseljenoMjesto + '|' + k.Lokacija.Adresa.PozivniBroj + '|' + k.Automobil.IdVozaca.ToString() + '|' + k.Automobil.Godiste + '|' + k.Automobil.Registracija + '|' + k.Automobil.BrojVozila.ToString() + '|' + k.Automobil.TipAuta + '|' + k.Zauzet.ToString();
                    lines[i] = allString;
                }
            }
            System.IO.File.WriteAllLines(@"C:\Users\user\Desktop\WebTaxi\WebAPI\WebAPI\App_Data\Vozaci.txt", lines);

        }
    }
}
