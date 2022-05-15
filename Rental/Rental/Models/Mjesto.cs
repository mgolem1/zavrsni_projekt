using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Mjesto
    {
        public int IDMjesto { get; set; }
        public string Naziv { get; set; }
        public Mjesto(int IdMjesto, string naziv)
        {
            this.IDMjesto = IdMjesto;
            this.Naziv = naziv;
        }
        public IEnumerable<SelectListItem> RezervacijaMjestoPovrata { get; set; }
        public IEnumerable<SelectListItem> RezervacijaMjestoPreuzimanja { get; set; }
    }
}

