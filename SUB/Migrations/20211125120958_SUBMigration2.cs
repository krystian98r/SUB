using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class SUBMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StanPortfela",
                table: "HistoriaPortfela",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StanPortfela",
                table: "HistoriaPortfela");
        }
    }
}
