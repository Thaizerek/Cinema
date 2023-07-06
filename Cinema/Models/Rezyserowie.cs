using Cinema.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Rezyserowie
    {
        [Key]
        public int RezyserId { get; set; }

        public string RezyserZdjecieURL { get; set; }
        public string RezyserImieNazwisko { get; set; }
        public string RezyserBiografia { get; set; }

        //Relacje:
        public List<Filmy> Filmy { get; set; }
    }
}
