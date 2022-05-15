using Newtonsoft.Json.Linq;
using Rental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.DtoMappers
{
    public class VoziloDto
    {
        public static Vozilo FromJson(JObject json)
        {


            var id = json["IDVozilo"].ToObject<int>();

            var Model = json["Model"].ToObject<string>();
            var kategorija = json["kategorija"].ToObject<int>();
            var Cijena = json["Cijena"].ToObject<int>();
            var Dostupan = json["Dostupan"].ToObject<bool>();
            var Registracija = json["Registracija"].ToObject<string>();

            return new Vozilo(id, Model,
                new Kategorija(kategorija, "")
                , Cijena,Registracija);
        }
    }
}
