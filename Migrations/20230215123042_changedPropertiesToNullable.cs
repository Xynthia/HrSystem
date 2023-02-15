using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.Migrations
{
    /// <inheritdoc />
    public partial class changedPropertiesToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Declaratie_DeclaratieId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Vakantie_VakantieId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "VakantieId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Team",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Rol",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DeclaratieId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Declaratie_DeclaratieId",
                table: "Users",
                column: "DeclaratieId",
                principalTable: "Declaratie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Vakantie_VakantieId",
                table: "Users",
                column: "VakantieId",
                principalTable: "Vakantie",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Declaratie_DeclaratieId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Vakantie_VakantieId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "VakantieId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Team",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rol",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeclaratieId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Declaratie_DeclaratieId",
                table: "Users",
                column: "DeclaratieId",
                principalTable: "Declaratie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Vakantie_VakantieId",
                table: "Users",
                column: "VakantieId",
                principalTable: "Vakantie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
