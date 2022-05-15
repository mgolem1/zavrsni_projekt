using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rental.Models;

namespace Rental.DtoMappers
{
    public class KlijentDto
    {
        public static Klijent FromJson(JObject json)
        {

            
            int? id = null;
            if (json["IDKlijent"] != null)
            {
                id = json["IDKlijent"].ToObject<int?>();
            }

            var Ime = json["Ime"].ToObject<string>();
            var Prezime = json["Prezime"].ToObject<string>();
            var EMail = json["EMail"].ToObject<string>();
            var lozinka = json["lozinka"].ToObject<string>();
            var uloga = json["uloga"].ToObject<string>();

            return new Klijent(id, Ime, Prezime, EMail, lozinka);
        }
    }
}
