using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Declaratie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AanvraagDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documenten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoedKeuring = table.Column<bool>(type: "bit", nullable: false),
                    Bedrag = table.Column<int>(type: "int", nullable: false),
                    Btw = table.Column<int>(type: "int", nullable: false),
                    Categorie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declaratie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vakantie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeginDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EindDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AanvraagDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoedKeuring = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vakantie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikersNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoorNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchterNaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wachtwoord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Team = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    VakantieId = table.Column<int>(type: "int", nullable: false),
                    DeclaratieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Declaratie_DeclaratieId",
                        column: x => x.DeclaratieId,
                        principalTable: "Declaratie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Vakantie_VakantieId",
                        column: x => x.VakantieId,
                        principalTable: "Vakantie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeclaratieId",
                table: "Users",
                column: "DeclaratieId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VakantieId",
                table: "Users",
                column: "VakantieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Declaratie");

            migrationBuilder.DropTable(
                name: "Vakantie");
        }
    }
}
