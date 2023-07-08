using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    [Authorize]
    public class Aktorzy
    {
        [Key]
        public int AktorId { get; set; }

        [Display(Name = "Zdjęcie")]
        [Required(ErrorMessage = "Zdjęcie jest wymagane ")]
        public string AktorZdjecieURL { get; set; }
        [Display(Name = "Imię i nazwisko aktora")]
        [Required(ErrorMessage = "Imię i nazwisko jest wymagane ")]
        public string AktorImieNazwisko { get; set; }
        [Display(Name = "Biografia aktora")]
        [Required(ErrorMessage = "biografia jest wymagana ")]
        public string AktorBiografia { get; set; }

        //Relacje:
        // public List<Film_Aktorzy> Film_Aktorzy { get; set; }
    }
}
