using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Vozilo
    {

        public int IDVozilo { get; set; }
        public string Model { get; set; }
        public Kategorija kategorija { get; set; }
        public int Cijena { get; set; }

        public string Registracija { get; set; }

        public Vozilo(int id, string model, Kategorija kat,int cijena,string reg)
        {
            this.IDVozilo = id;
            this.Model = model;
            this.kategorija = kat;
            this.Cijena = cijena;

            this.Registracija = reg;
        }
    }
}

