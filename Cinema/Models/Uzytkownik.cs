using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Uzytkownik
    {
        public int UzytkownikId { get; set; }
        public string UzykownikImieNazwisko { get; set; }
        public string UzytkownikAdres { get; set; }
        public string UzytkownikHaslo { get; set; }
    }
}
