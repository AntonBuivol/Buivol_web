using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buivol_web.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KasutajaId",
                table: "Tooded");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KasutajaId",
                table: "Tooded",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
