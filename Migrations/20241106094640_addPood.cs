﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Buivol_web.Migrations
{
    /// <inheritdoc />
    public partial class addPood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ToodeId = table.Column<int>(type: "int", nullable: false),
                    KasutajaId = table.Column<int>(type: "int", nullable: false),
                    KasutajadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pood_Kasutajad_KasutajadId",
                        column: x => x.KasutajadId,
                        principalTable: "Kasutajad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pood_Tooded_ToodeId",
                        column: x => x.ToodeId,
                        principalTable: "Tooded",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pood_KasutajadId",
                table: "Pood",
                column: "KasutajadId");

            migrationBuilder.CreateIndex(
                name: "IX_Pood_ToodeId",
                table: "Pood",
                column: "ToodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pood");
        }
    }
}