using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Voznje
    {
        public static Dictionary<int, Voznja> voznje { get; set; } = new Dictionary<int, Voznja>();

        public Voznje() { }

        public Voznje(string path)
        {

            FileStream stream = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(stream);

            Enums.StatusVoznje status;
            Enums.TipAutomobila tip;
            Lokacija pomLokDolazak;
            Lokacija pomLokOdrediste;
            Komentar pomKomentar;
            Adresa pomAdresa;
            Adresa pomAdresa1;



            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string[] tokens = line.Split('|');

                if (tokens[9].Equals("Kombi"))
                {
                    tip = Enums.TipAutomobila.Kombi;
                }
                else
                {
                    tip = Enums.TipAutomobila.Putnicki;
                }

                if (tokens[26].Equals("Formirana"))
                {
                    status = Enums.StatusVoznje.Formirana;
                }
                else if (tokens[26].Equals("Kreirana"))
                {
                    status = Enums.StatusVoznje.Kreirana;
                }
                else if (tokens[66].Equals("Neuspjesna"))
                {
                    status = Enums.StatusVoznje.Neuspjesna;
                }
                else if (tokens[26].Equals("Obradjena"))
                {
                    status = Enums.StatusVoznje.Obradjena;
                }
                else if (tokens[26].Equals("Otkazana"))
                {
                    status = Enums.StatusVoznje.Otkazana;
                }
                else if (tokens[26].Equals("Prihvacena"))
                {
                    status = Enums.StatusVoznje.Prihvacena;
                }
                else if (tokens[26].Equals("Uspjesna"))
                {
                    status = Enums.StatusVoznje.Uspjesna;
                }
                else
                {
                    status = Enums.StatusVoznje.Utoku;
                }

                pomAdresa = new Adresa(Int32.Parse(tokens[5]), tokens[6], tokens[7], tokens[8]);
                pomLokDolazak = new Lokacija(Int32.Parse(tokens[2]), Double.Parse(tokens[3]), Double.Parse(tokens[4]), pomAdresa);
                pomAdresa1 = new Adresa(Int32.Parse(tokens[14]), tokens[15], tokens[16], tokens[17]);
                pomLokOdrediste = new Lokacija(Int32.Parse(tokens[11]), Double.Parse(tokens[12]), Double.Parse(tokens[13]), pomAdresa1);
                pomKomentar = new Komentar(tokens[21], DateTime.Parse(tokens[22]), tokens[23], Int32.Parse(tokens[24]), Int32.Parse(tokens[25]));
                Voznja v = new Voznja(Int32.Parse(tokens[0]), DateTime.Parse(tokens[1]), pomLokDolazak, tip, tokens[10], pomLokOdrediste, tokens[18], Double.Parse(tokens[19]), tokens[20], pomKomentar, status);
                voznje.Add(v.IdVoznje, v);
            }
            sr.Close();
            stream.Close();
        }
    }
}