using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rental.DbModels
{
    public partial class Klijent
    {
        public Klijent()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Idklijent { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Neispravan email!")]
        [Required]
        public string Email { get; set; }
        public string Lozinka { get; set; }

        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
