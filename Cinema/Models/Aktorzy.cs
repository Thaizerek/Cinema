using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Aktorzy
    {
        [Key]
        public int AktorId { get; set; }

        [Display(Name = "Zdjęcie")]
        public string AktorZdjecieURL { get; set; }
        [Display(Name = "Imię i nazwisko aktora")]
        public string AktorImieNazwisko { get; set; }
        [Display(Name = "Biografia aktora")]
        public string AktorBiografia { get; set; }

        //Relacje:
        // public List<Film_Aktorzy> Film_Aktorzy { get; set; }
    }
}
