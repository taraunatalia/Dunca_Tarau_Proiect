using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunca_Tarau_Proiect.Migrations
{
    public partial class Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "Tour",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tour_CountryID",
                table: "Tour",
                column: "CountryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tour_Country_CountryID",
                table: "Tour",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tour_Country_CountryID",
                table: "Tour");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Tour_CountryID",
                table: "Tour");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "Tour");
        }
    }
}
