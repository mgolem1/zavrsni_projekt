using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class NacinPlacanja
    {
        public int IDNacinPlacanja { get; set; }
        public string Naziv { get; set; }
        public NacinPlacanja(int IDNacin, string naziv)
        {
            this.IDNacinPlacanja = IDNacin;
            this.Naziv = naziv;
        }
    }
}
