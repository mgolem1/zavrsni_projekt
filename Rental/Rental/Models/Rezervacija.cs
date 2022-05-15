using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Rezervacija
    {
        public int? IDRezervacija { get; set; }
        [Display(Name="Vrijeme preuzimanja")]
        public DateTime DatumOd { get; set; }
        [Display(Name = "Vrijeme povrata")]
        public DateTime DatumDo { get; set; }
        public Mjesto MjestoPreuzimanja { get; set; }
        public Mjesto MjestoPovrata { get; set; }
        public Vozilo Vozilo { get; set; }
        public Klijent Klijent { get; set; }
        public NacinPlacanja Nacin { get; set; }
        public string CijenaRez { get; set; }
        public Rezervacija (int? id, DateTime datumod,DateTime datumdo,Mjesto mjestoPre,Mjesto mjestoPov,Vozilo vozilo, Klijent klijent,NacinPlacanja nacin,string uc)
        {
            this.IDRezervacija = id;
            this.DatumOd = datumod;
            this.DatumDo = datumdo;
            this.MjestoPreuzimanja = mjestoPre;
            this.MjestoPovrata = mjestoPov;
            this.Vozilo = vozilo;
            this.Klijent = klijent;
            this.Nacin = nacin;
            this.CijenaRez = uc;
        }

    }
}
