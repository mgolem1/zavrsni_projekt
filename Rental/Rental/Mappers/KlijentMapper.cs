using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.Mappers
{
    public class KlijentMapper
    {
        //mapiramo iz modela baze u nase modele iz aplikacije
        //citanje
        public static Klijent FromDatabase(DbModels.Klijent k)
        {
            var ko = new Klijent(k.Idklijent, k.Ime, k.Prezime, k.Email, k.Lozinka);
            return ko;
        }

        public static DbModels.Klijent ToDatabase(Klijent k)
        {
            return new DbModels.Klijent
            {
                Idklijent = k.IDKlijent.HasValue ? k.IDKlijent.Value : 0,
                Email = k.EMail,
                Ime = k.Ime,
                Lozinka = k.Lozinka,
                Prezime = k.Prezime
            };
        }
    }
}
