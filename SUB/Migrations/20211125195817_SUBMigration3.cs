using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class SUBMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataUtworzenia",
                table: "Kupon",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUtworzenia",
                table: "Kupon");
        }
    }
}
