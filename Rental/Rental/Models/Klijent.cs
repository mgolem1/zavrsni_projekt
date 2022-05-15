using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Klijent
    {
        public int? IDKlijent { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Neispravan email!")]
        [Required]
        public string EMail { get; set; }
        public string Lozinka { get; set; }


        
        public Klijent(int? id,string ime,string prezime, string email,string lozinka)
        {
            IDKlijent = id;
            Ime = ime;
            Prezime = prezime;
            EMail = email;
            Lozinka = lozinka;

        }

    }
}
