using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Vozaci
    {
        //public static Dictionary<int, Vozac> vozaci { get; set; } = new Dictionary<int, Vozac>();

        //public Vozaci() { }

        //public Vozaci(string path)
        //{


        //    FileStream stream = new FileStream(path, FileMode.Open);
        //    StreamReader sr = new StreamReader(stream);
        //    Enums.Pol pol;
        //    Enums.Uloga uloga;
        //    Lokacija pomLok;
        //    Automobil pomAuto;

        //    string line = "";
        //    while ((line = sr.ReadLine()) != null)
        //    {
        //        string[] tokens = line.Split('|');

        //        if (tokens[5].Equals("M"))
        //        {
        //            pol = Enums.Pol.M;
        //        }
        //        else
        //        {
        //            pol = Enums.Pol.Z;
        //        }
        //        if (tokens[9].Equals("Musterija"))
        //        {
        //            uloga = Enums.Uloga.Musterija;
        //        }
        //        else if (tokens[9].Equals("Dispecer"))
        //        {
        //            uloga = Enums.Uloga.Dispecer;
        //        }
        //        else
        //        {
        //            uloga = Enums.Uloga.Vozac;
        //        }
        //        Vozac v = new Vozac(Int32.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], pol, tokens[6], tokens[7], tokens[8], uloga);
        //        vozaci.Add(v.Id, v);
        //    }
        //    sr.Close();
        //    stream.Close();
        //}
    }
}