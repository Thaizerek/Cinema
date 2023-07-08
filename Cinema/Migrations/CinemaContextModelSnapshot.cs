﻿// <auto-generated />
using System;
using Cinema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cinema.Migrations
{
    [DbContext(typeof(CinemaContext))]
    partial class CinemaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cinema.Models.Aktorzy", b =>
                {
                    b.Property<int>("AktorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AktorBiografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AktorImieNazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AktorZdjecieURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AktorId");

                    b.ToTable("Aktorzy");
                });

            modelBuilder.Entity("Cinema.Models.Filmy", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("FilmCena")
                        .HasColumnType("float");

                    b.Property<DateTime>("FilmDataKonca")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FilmDataStartu")
                        .HasColumnType("datetime2");

                    b.Property<int>("FilmKategoria")
                        .HasColumnType("int");

                    b.Property<string>("FilmNazwa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmZdjecieURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RezyserId")
                        .HasColumnType("int");

                    b.Property<int?>("RezyserowieRezyserId")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("RezyserowieRezyserId");

                    b.ToTable("Filmy");
                });

            modelBuilder.Entity("Cinema.Models.Rezyserowie", b =>
                {
                    b.Property<int>("RezyserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RezyserBiografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RezyserImieNazwisko")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RezyserZdjecieURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RezyserId");

                    b.ToTable("Rezyserowie");
                });

            modelBuilder.Entity("Cinema.Models.Filmy", b =>
                {
                    b.HasOne("Cinema.Models.Rezyserowie", null)
                        .WithMany("Filmy")
                        .HasForeignKey("RezyserowieRezyserId");
                });

            modelBuilder.Entity("Cinema.Models.Rezyserowie", b =>
                {
                    b.Navigation("Filmy");
                });
#pragma warning restore 612, 618
        }
    }
}
