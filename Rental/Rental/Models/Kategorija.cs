using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Models
{
    public class Kategorija
    {
        
        public int IDKategorija { get; set; }
  
        public string Naziv { get; set; }
        public Kategorija(int id, string naziv)
        {
            IDKategorija = id;
            Naziv = naziv;
        }

    }
}
