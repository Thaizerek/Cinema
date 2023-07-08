using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Uzytkownik:IdentityUser
    {
        public int UzytkownikId { get; set; }
        [Required]
        public string UzykownikImieNazwisko { get; set; }
        public string UzytkownikAdres { get; set; }
        public string UzytkownikHaslo { get; set; }
    }
}
