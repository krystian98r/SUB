using Microsoft.EntityFrameworkCore.Migrations;

namespace SUB.Migrations
{
    public partial class MigrationSUB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupon_AspNetUsers_UzytkownikId",
                table: "Kupon");

            migrationBuilder.AlterColumn<string>(
                name: "UzytkownikId",
                table: "Kupon",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kupon_AspNetUsers_UzytkownikId",
                table: "Kupon",
                column: "UzytkownikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kupon_AspNetUsers_UzytkownikId",
                table: "Kupon");

            migrationBuilder.AlterColumn<string>(
                name: "UzytkownikId",
                table: "Kupon",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Kupon_AspNetUsers_UzytkownikId",
                table: "Kupon",
                column: "UzytkownikId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
