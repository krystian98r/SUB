using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wydarzenie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gospodarz = table.Column<string>(nullable: true),
                    Gosc = table.Column<string>(nullable: true),
                    ZwyciestwoGospodarz = table.Column<float>(nullable: false),
                    ZwyciestwoGosc = table.Column<float>(nullable: false),
                    Remis = table.Column<float>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    WynikWydarzenia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydarzenie", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wydarzenie");
        }
    }
}
