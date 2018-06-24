using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozaci
    {
        public static Dictionary<int, Vozac> vozaci { get; set; } = new Dictionary<int, Vozac>();

        public Vozaci() { }

        public Vozaci(string path)
        {

            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);
            Enums.Pol pol;
            Enums.Uloga uloga;
            Enums.TipAutomobila tip;
            Lokacija pomLok;
            Automobil pomAuto;
            Adresa pomAdresa;

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');

                if (tokens[5].Equals("M"))
                {
                    pol = Enums.Pol.M;
                }
                else
                {
                    pol = Enums.Pol.Z;
                }
                if (tokens[9].Equals("Musterija"))
                {
                    uloga = Enums.Uloga.Musterija;
                }
                else if (tokens[9].Equals("Dispecer"))
                {
                    uloga = Enums.Uloga.Dispecer;
                }
                else
                {
                    uloga = Enums.Uloga.Vozac;
                }
                if (tokens[21].Equals("Kombi"))
                {
                    tip = Enums.TipAutomobila.Kombi;
                }
                else
                {
                    tip = Enums.TipAutomobila.Putnicki;
                }
                pomAdresa = new Adresa(Int32.Parse(tokens[13]),tokens[14], tokens[15], tokens[16]);
                pomLok = new Lokacija(Int32.Parse(tokens[10]),Double.Parse(tokens[11]),Double.Parse(tokens[12]),pomAdresa);
                pomAuto = new Automobil(Int32.Parse(tokens[17]), tokens[18], tokens[19], Int32.Parse(tokens[20]), tip);
                Vozac v = new Vozac(Int32.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], pol, tokens[6], tokens[7], tokens[8], uloga,pomLok,pomAuto,bool.Parse(tokens[22]),bool.Parse(tokens[23]));
                vozaci.Add(v.Id, v);
            }
            sr.Close();
            stream.Close();
        }
    }
}