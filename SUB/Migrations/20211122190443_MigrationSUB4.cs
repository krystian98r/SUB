using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class MigrationSUB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ZwyciestwoGospodarz",
                table: "Wydarzenie",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ZwyciestwoGosc",
                table: "Wydarzenie",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Remis",
                table: "Wydarzenie",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ZwyciestwoGospodarz",
                table: "Wydarzenie",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "ZwyciestwoGosc",
                table: "Wydarzenie",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Remis",
                table: "Wydarzenie",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
