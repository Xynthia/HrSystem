using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedKeuring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GoedKeuring",
                table: "Vakantie",
                newName: "Keuring");

            migrationBuilder.RenameColumn(
                name: "GoedKeuring",
                table: "Declaratie",
                newName: "Keuring");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Keuring",
                table: "Vakantie",
                newName: "GoedKeuring");

            migrationBuilder.RenameColumn(
                name: "Keuring",
                table: "Declaratie",
                newName: "GoedKeuring");
        }
    }
}
