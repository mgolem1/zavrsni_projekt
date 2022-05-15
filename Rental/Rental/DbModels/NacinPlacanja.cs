using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rental.DbModels
{
    public partial class NacinPlacanja
    {
        public NacinPlacanja()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int IdnacinPlacanja { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
