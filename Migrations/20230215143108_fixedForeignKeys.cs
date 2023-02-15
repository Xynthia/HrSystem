using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.Migrations
{
    /// <inheritdoc />
    public partial class fixedForeignKeys : Migration
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_DeclaratieId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_VakantieId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeclaratieId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VakantieId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Vakantie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Declaratie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Team",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rol",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vakantie_UserId",
                table: "Vakantie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Declaratie_UserId",
                table: "Declaratie",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Declaratie_User_UserId",
                table: "Declaratie",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vakantie_User_UserId",
                table: "Vakantie",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Declaratie_User_UserId",
                table: "Declaratie");

            migrationBuilder.DropForeignKey(
                name: "FK_Vakantie_User_UserId",
                table: "Vakantie");

            migrationBuilder.DropIndex(
                name: "IX_Vakantie_UserId",
                table: "Vakantie");

            migrationBuilder.DropIndex(
                name: "IX_Declaratie_UserId",
                table: "Declaratie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Vakantie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Declaratie");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

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

            migrationBuilder.AddColumn<int>(
                name: "DeclaratieId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VakantieId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeclaratieId",
                table: "Users",
                column: "DeclaratieId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VakantieId",
                table: "Users",
                column: "VakantieId");

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
    }
}
