using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinema.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktorzy",
                columns: table => new
                {
                    AktorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AktorZdjecieURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktorImieNazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktorBiografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktorzy", x => x.AktorId);
                });

            migrationBuilder.CreateTable(
                name: "Rezyserowie",
                columns: table => new
                {
                    RezyserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezyserZdjecieURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RezyserImieNazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RezyserBiografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezyserowie", x => x.RezyserId);
                });

            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmNazwa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmOpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmCena = table.Column<double>(type: "float", nullable: false),
                    FilmZdjecieURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmDataStartu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmDataKonca = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmKategoria = table.Column<int>(type: "int", nullable: false),
                    RezyserId = table.Column<int>(type: "int", nullable: false),
                    RezyserowieRezyserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.FilmId);
                    table.ForeignKey(
                        name: "FK_Filmy_Rezyserowie_RezyserowieRezyserId",
                        column: x => x.RezyserowieRezyserId,
                        principalTable: "Rezyserowie",
                        principalColumn: "RezyserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_RezyserowieRezyserId",
                table: "Filmy",
                column: "RezyserowieRezyserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktorzy");

            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Rezyserowie");
        }
    }
}
