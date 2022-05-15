using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rental.DbModels
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            Vozilo = new HashSet<Vozilo>();
        }

        public int Idkategorija { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Vozilo> Vozilo { get; set; }
    }
}
