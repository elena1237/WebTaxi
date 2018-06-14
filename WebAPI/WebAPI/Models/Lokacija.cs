using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Lokacija
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Adresa Adresa { get; set; }

        public Lokacija() { }
        public Lokacija(int id,double x,double y,Adresa adresa)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.Adresa = adresa;
        }

    }
}