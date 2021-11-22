using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class MigrationSUB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kupon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<string>(nullable: true),
                    WydarzenieId = table.Column<int>(nullable: false),
                    Srodki = table.Column<float>(nullable: false),
                    ObstawionyKurs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupon_AspNetUsers_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kupon_Wydarzenie_WydarzenieId",
                        column: x => x.WydarzenieId,
                        principalTable: "Wydarzenie",
                        principalColumn: "Id",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kupon_UzytkownikId",
                table: "Kupon",
                column: "UzytkownikId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupon_WydarzenieId",
                table: "Kupon",
                column: "WydarzenieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
