using Cinema.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CinemaContext>();

                context.Database.EnsureCreated();

                //aktorzy
                if (!context.Aktorzy.Any())
                {
                    //Przykłady..
                    context.Aktorzy.AddRange(new List<Aktorzy>()
                    {
                        new Aktorzy()
                        {
                            AktorImieNazwisko = "Actor 1",
                            AktorBiografia = "This is the Bio of the first actor",
                            AktorZdjecieURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Aktorzy()
                        {
                            AktorImieNazwisko = "Actor 2",
                            AktorBiografia = "This is the Bio of the second actor",
                            AktorZdjecieURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Aktorzy()
                        {
                            AktorImieNazwisko = "Actor 3",
                            AktorBiografia = "This is the Bio of the third actor",
                            AktorZdjecieURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Aktorzy()
                        {
                            AktorImieNazwisko = "Actor 4",
                            AktorBiografia = "This is the Bio of the fourth actor",
                            AktorZdjecieURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Aktorzy()
                        {
                            AktorImieNazwisko = "Actor 5",
                            AktorBiografia = "This is the Bio of the fifth actor",
                            AktorZdjecieURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //rezyserowie
                if (!context.Rezyserowie.Any())
                {
                    //Przykłady..
                    context.Rezyserowie.AddRange(new List<Rezyserowie>()
                    {
                        new Rezyserowie()
                        {
                            RezyserImieNazwisko = "Producer 1",
                            RezyserBiografia = "This is the Bio of the first actor",
                            RezyserZdjecieURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Rezyserowie()
                        {
                            RezyserImieNazwisko = "Producer 2",
                            RezyserBiografia = "This is the Bio of the second actor",
                            RezyserZdjecieURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Rezyserowie()
                        {
                            RezyserImieNazwisko = "Producer 3",
                            RezyserBiografia = "This is the Bio of the second actor",
                            RezyserZdjecieURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Rezyserowie()
                        {
                            RezyserImieNazwisko = "Producer 4",
                            RezyserBiografia = "This is the Bio of the second actor",
                            RezyserZdjecieURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Rezyserowie()
                        {
                            RezyserImieNazwisko = "Producer 5",
                            RezyserBiografia = "This is the Bio of the second actor",
                            RezyserZdjecieURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //filmy
                if (!context.Filmy.Any())
                {
                    //Przykłady..
                    context.Filmy.AddRange(new List<Filmy>()
                    {
                        new Filmy()
                        {
                            FilmNazwa = "Life",
                            FilmOpis = "This is the Life movie description",
                            FilmCena = 39.50,
                            FilmZdjecieURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            FilmDataStartu = DateTime.Now.AddDays(-10),
                            FilmDataKonca = DateTime.Now.AddDays(10),
                            RezyserId = 3,
                            FilmKategoria = FilmKategoria.Dokumentalny
                        },
                        new Filmy()
                        {
                            FilmNazwa = "The Shawshank Redemption",
                            FilmOpis = "This is the Shawshank Redemption description",
                            FilmCena = 29.50,
                            FilmZdjecieURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            FilmDataStartu = DateTime.Now,
                            FilmDataKonca = DateTime.Now.AddDays(3),
                            RezyserId = 1,
                            FilmKategoria = FilmKategoria.Akcji
                        },
                        new Filmy()
                        {
                            FilmNazwa = "Ghost",
                            FilmOpis = "This is the Ghost movie description",
                            FilmCena = 39.50,
                            FilmZdjecieURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            FilmDataStartu = DateTime.Now,
                            FilmDataKonca = DateTime.Now.AddDays(7),
                            RezyserId = 4,
                            FilmKategoria = FilmKategoria.Horror
                        },
                        new Filmy()
                        {
                            FilmNazwa = "Race",
                            FilmOpis = "This is the Race movie description",
                            FilmCena = 39.50,
                            FilmZdjecieURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            FilmDataStartu = DateTime.Now.AddDays(-10),
                            FilmDataKonca = DateTime.Now.AddDays(-5),
                            RezyserId = 2,
                            FilmKategoria = FilmKategoria.Dokumentalny
                        },
                        new Filmy()
                        {
                            FilmNazwa = "Scoob",
                            FilmOpis = "This is the Scoob movie description",
                            FilmCena = 39.50,
                            FilmZdjecieURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            FilmDataStartu = DateTime.Now.AddDays(-10),
                            FilmDataKonca = DateTime.Now.AddDays(-2),
                            RezyserId = 3,
                            FilmKategoria = FilmKategoria.Komiksowy
                        },
                        new Filmy()
                        {
                            FilmNazwa = "Cold Soles",
                            FilmOpis = "This is the Cold Soles movie description",
                            FilmCena = 39.50,
                            FilmZdjecieURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            FilmDataStartu = DateTime.Now.AddDays(3),
                            FilmDataKonca = DateTime.Now.AddDays(20),
                            RezyserId = 5,
                            FilmKategoria = FilmKategoria.Dramat
                        }
                    });
                    context.SaveChanges();
                }
                /*//filmy aktorzy
                if (!context.Film_Aktorzy.Any())
                {
                    //Przykłady..
                    context.Film_Aktorzy.AddRange(new List<Film_Aktorzy>()
                    {
                        new Film_Aktorzy()
                        {
                            AktorId = 1,
                            FilmId = 1
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 3,
                            FilmId = 1
                        },

                         new Film_Aktorzy()
                        {
                            AktorId = 1,
                            FilmId = 2
                        },
                         new Film_Aktorzy()
                        {
                            AktorId = 4,
                            FilmId = 2
                        },

                        new Film_Aktorzy()
                        {
                            AktorId = 1,
                            FilmId = 3
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 2,
                            FilmId = 3
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 5,
                            FilmId = 3
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 2,
                            FilmId = 4
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 3,
                            FilmId = 4
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 4,
                            FilmId = 4
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 2,
                            FilmId = 5
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 3,
                            FilmId = 5
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 4,
                            FilmId = 5
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 5,
                            FilmId = 5
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 3,
                            FilmId = 6
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 4,
                            FilmId = 6
                        },
                        new Film_Aktorzy()
                        {
                            AktorId = 5,
                            FilmId = 6
                        },
                    });
                    context.SaveChanges(); */
                }
            }
        }
    }

