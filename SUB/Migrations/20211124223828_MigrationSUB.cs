using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class MigrationSUB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
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
