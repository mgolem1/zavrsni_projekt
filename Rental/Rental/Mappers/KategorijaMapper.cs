using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.Mappers
{
    public class KategorijaMapper
    {
        public static Kategorija FromDatabase(DbModels.Kategorija kategorija)
        {
            return new Kategorija(kategorija.Idkategorija, kategorija.Naziv);
        }
    }
}
