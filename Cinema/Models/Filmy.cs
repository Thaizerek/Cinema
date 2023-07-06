using Cinema.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Filmy
    {
        [Key]
        public int FilmId { get; set; }

        public string FilmNazwa { get; set; }
        public string FilmOpis { get; set; }
        public double FilmCena { get; set; }
        public string FilmZdjecieURL { get; set; }
        public DateTime FilmDataStartu { get; set; }
        public DateTime FilmDataKonca { get; set; }
        public FilmKategoria FilmKategoria { get; set; }

        // Relacje:
       // public List<Film_Aktorzy> Film_Aktorzy { get; set; }

        public int RezyserId { get; set; }
       // [ForeignKey("RezyserId")]
       // public Rezyserowie Rezyser { get; set; }

    }
}
