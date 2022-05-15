using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Rental.DbModels
{
    public partial class Rezervacija
    {
        public int Idrezervacija { get; set; }
        [Display(Name = "Vrijeme preuzimanja")]
        public DateTime DatumOd { get; set; }
        [Display(Name = "Vrijeme povrata")]
        public DateTime DatumDo { get; set; }


        public int MjestoPreuzimanja { get; set; }

        public int MjestoPovrata { get; set; }

        public int Vozilo { get; set; }

        public int Klijent { get; set; }

        public int Nacin { get; set; }

        [Display(Name = "Ukupna cijena rezervacije")]
        public string CijenaRez { get; set; }

        [Display(Name = "Klijent")]
        public virtual Klijent KlijentNavigation { get; set; }
        [Display(Name = "Mjesto preuzimanja")]
        public virtual Mjesto MjestoPreuzimanjaNavigation { get; set; }
        [Display(Name = "Mjesto povrata")]
        public virtual Mjesto MjestoPovrataNavigation { get; set; }

        [Display(Name = "Nacin placanja prilikom preuzimanja")]
        public virtual NacinPlacanja NacinNavigation { get; set; }
        [Display(Name = "Vozilo")]
        public virtual Vozilo VoziloNavigation { get; set; }
    }
}
