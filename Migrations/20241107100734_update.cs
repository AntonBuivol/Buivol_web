using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buivol_web.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KasutajaId",
                table: "Tooded",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KasutajadId",
                table: "Tooded",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tooded_KasutajadId",
                table: "Tooded",
                column: "KasutajadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tooded_Kasutajad_KasutajadId",
                table: "Tooded",
                column: "KasutajadId",
                principalTable: "Kasutajad",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tooded_Kasutajad_KasutajadId",
                table: "Tooded");

            migrationBuilder.DropIndex(
                name: "IX_Tooded_KasutajadId",
                table: "Tooded");

            migrationBuilder.DropColumn(
                name: "KasutajaId",
                table: "Tooded");

            migrationBuilder.DropColumn(
                name: "KasutajadId",
                table: "Tooded");
        }
    }
}
