using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.DtoMappers
{
    public class RezervacijaDto
    {
        public static Rezervacija FromJson(JObject json)
        {
            int? id = null;
            if (json["IDRezervacija"] != null)
            {
                id = json["IDRezervacija"].ToObject<int?>();
            }
            //var id= json["id"].ToObject<int?>();

            var DatumOd = json["DatumOd"].ToObject<DateTime>();
            var DatumDo = json["DatumDo"].ToObject<DateTime>();
            var MjestoPreuzimanja = json["MjestoPreuzimanja"].ToObject<int>();
            var MjestoPovrata = json["MjestoPovrata"].ToObject<int>();
            var Vozilo = json["Vozilo"].ToObject<int>();
            var Klijent = json["Klijent"].ToObject<int>();
            var Nacin = json["Nacin"].ToObject<int>();
            var CijenaRez = json["CijenaRez"].ToObject<string>();

            return new Rezervacija(id, DatumOd, DatumDo,
                new Mjesto(MjestoPreuzimanja, ""),
                 new Mjesto(MjestoPovrata, ""),
                  new Vozilo(Vozilo, "", null, 0, ""),
                   new Klijent(Klijent, "", "", "", ""),
                    new NacinPlacanja(Nacin, ""),CijenaRez); 
        }
    }
}
