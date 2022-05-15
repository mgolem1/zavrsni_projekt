using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rental.DbModels
{
    public partial class Vozilo
    {
        public Vozilo()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Idvozilo { get; set; }
        [Display(Name = "Model automobila")]
        public string Model { get; set; }
        public int Kategorija { get; set; }
        [Display(Name = "Cijena po danu")]
        public int Cijena { get; set; }
        public string Registracija { get; set; }

        [Display(Name = "Kategorija")]
        public virtual Kategorija KategorijaNavigation { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
