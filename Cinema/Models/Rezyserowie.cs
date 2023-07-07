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

        [Display(Name = "Zdjęcie")]
        public string RezyserZdjecieURL { get; set; }
        [Display(Name = "Imię i Nazwisko")]
        public string RezyserImieNazwisko { get; set; }
        [Display(Name = "Biografia Reżysera")]
        public string RezyserBiografia { get; set; }

        //Relacje:
        public List<Filmy> Filmy { get; set; }
    }
}
