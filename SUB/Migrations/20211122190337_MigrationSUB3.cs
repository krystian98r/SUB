using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class MigrationSUB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Srodki",
                table: "Kupon",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Srodki",
                table: "Kupon",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
