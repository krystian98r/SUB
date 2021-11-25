using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class SUBMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoriaPortfela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfelId = table.Column<int>(nullable: false),
                    Srodki = table.Column<double>(nullable: false),
                    Zdarzenie = table.Column<string>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaPortfela", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaPortfela_Portfel_PortfelId",
                        column: x => x.PortfelId,
                        principalTable: "Portfel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaPortfela_PortfelId",
                table: "HistoriaPortfela",
                column: "PortfelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriaPortfela");
        }
    }
}
