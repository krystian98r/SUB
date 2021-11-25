using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class SUBMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataUtworzenia",
                table: "Zgloszenie",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUtworzenia",
                table: "Kupon",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUtworzenia",
                table: "Zgloszenie");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataUtworzenia",
                table: "Kupon",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
