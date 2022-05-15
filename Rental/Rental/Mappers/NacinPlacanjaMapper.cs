using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.Mappers
{
    public class NacinPlacanjaMapper
    {
        public static NacinPlacanja FromDatabase(DbModels.NacinPlacanja nacin)
        {
            return new NacinPlacanja(nacin.IdnacinPlacanja, nacin.Naziv);
        }
    }
}
