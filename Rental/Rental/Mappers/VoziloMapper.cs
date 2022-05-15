using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.Mappers
{
    public class VoziloMapper
    {
        public static Vozilo FromDatabase(DbModels.Vozilo vozilo)
        {
            return new Vozilo(vozilo.Idvozilo, vozilo.Model, KategorijaMapper.FromDatabase(vozilo.KategorijaNavigation), vozilo.Cijena, vozilo.Registracija);
        }

        public static DbModels.Vozilo ToDatabase(Vozilo k)
        {
            return new DbModels.Vozilo
            {
                Idvozilo = k.IDVozilo,
                Model = k.Model,
                Kategorija = k.kategorija.IDKategorija,

                Registracija = k.Registracija,
                Cijena = k.Cijena
            };
        }
    }
}
