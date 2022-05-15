using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.Mappers
{
    public class RezervacijaMapper
    {
        public static Rezervacija FromDatabase(DbModels.Rezervacija rezervacija)
        {
            return new Rezervacija(
                rezervacija.Idrezervacija,
                rezervacija.DatumOd,
                rezervacija.DatumDo,
                MjestoMapper.FromDatabase(rezervacija.MjestoPreuzimanjaNavigation),
                MjestoMapper.FromDatabase(rezervacija.MjestoPovrataNavigation),
                VoziloMapper.FromDatabase(rezervacija.VoziloNavigation),
                KlijentMapper.FromDatabase(rezervacija.KlijentNavigation),
                NacinPlacanjaMapper.FromDatabase(rezervacija.NacinNavigation),rezervacija.CijenaRez) ;
        }

        public static DbModels.Rezervacija ToDatabase(Rezervacija rez)
        {
            return new DbModels.Rezervacija
            {
                DatumOd = rez.DatumOd,
                DatumDo = rez.DatumDo,
                MjestoPreuzimanja = rez.MjestoPreuzimanja.IDMjesto,
                MjestoPovrata = rez.MjestoPovrata.IDMjesto,
                Vozilo = rez.Vozilo.IDVozilo,
                Klijent= (int)rez.Klijent.IDKlijent,
                Nacin = rez.Nacin.IDNacinPlacanja
            };
        }
    }
}
