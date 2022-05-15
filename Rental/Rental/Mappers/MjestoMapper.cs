using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.Mappers
{
    public class MjestoMapper
    {
        public static Mjesto FromDatabase(DbModels.Mjesto mjesto)
        {
            return new Mjesto(mjesto.Idmjesto, mjesto.Naziv);
        }
    }
}
