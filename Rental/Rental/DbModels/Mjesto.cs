using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rental.DbModels
{
    public partial class Mjesto
    {
        public Mjesto()
        {
            RezervacijaMjestoPovrataNavigation = new HashSet<Rezervacija>();
            RezervacijaMjestoPreuzimanjaNavigation = new HashSet<Rezervacija>();
        }

        public int Idmjesto { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Rezervacija> RezervacijaMjestoPovrataNavigation { get; set; }
        public virtual ICollection<Rezervacija> RezervacijaMjestoPreuzimanjaNavigation { get; set; }
    }
}
