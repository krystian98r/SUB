using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class ModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portfel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Srodki = table.Column<double>(nullable: false),
                    KodPortfela = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PortfelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Portfel_PortfelId",
                        column: x => x.PortfelId,
                        principalTable: "Portfel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kupon",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId1 = table.Column<string>(nullable: true),
                    UzytkownikId = table.Column<int>(nullable: true),
                    WydarzenieId = table.Column<int>(nullable: false),
                    Srodki = table.Column<double>(nullable: false),
                    ObstawionyKurs = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kupon_AspNetUsers_UzytkownikId1",
                        column: x => x.UzytkownikId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kupon_Wydarzenie_WydarzenieId",
                        column: x => x.WydarzenieId,
                        principalTable: "Wydarzenie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zgloszenie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UzytkownikId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Tresc = table.Column<string>(nullable: false),
                    Kategoria = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zgloszenie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zgloszenie_AspNetUsers_UzytkownikId",
                        column: x => x.UzytkownikId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PortfelId",
                table: "AspNetUsers",
                column: "PortfelId");

            migrationBuilder.CreateIndex(
                name: "IX_Kupon_UzytkownikId1",
                table: "Kupon",
                column: "UzytkownikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Kupon_WydarzenieId",
                table: "Kupon",
                column: "WydarzenieId");

            migrationBuilder.CreateIndex(
                name: "IX_Zgloszenie_UzytkownikId",
                table: "Zgloszenie",
                column: "UzytkownikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kupon");

            migrationBuilder.DropTable(
                name: "Zgloszenie");

            migrationBuilder.DropTable(
                name: "Wydarzenie");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Portfel");
        }
    }
}
