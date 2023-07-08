using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Cinema.Data
{
    public class CinemaContext : IdentityDbContext
    {
        public CinemaContext (DbContextOptions<CinemaContext> options)
            : base(options)
        {
        }

        public DbSet<Cinema.Models.Aktorzy> Aktorzy { get; set; }

        public DbSet<Cinema.Models.Filmy> Filmy { get; set; }

        public DbSet<Cinema.Models.Rezyserowie> Rezyserowie { get; set; }
    }
}
