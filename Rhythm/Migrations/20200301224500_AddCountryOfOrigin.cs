using Microsoft.EntityFrameworkCore.Migrations;

namespace Rhythm.Migrations
{
    public partial class AddCountryOfOrigin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountyOfOrigin",
                table: "Bands");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Bands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Bands");

            migrationBuilder.AddColumn<string>(
                name: "CountyOfOrigin",
                table: "Bands",
                type: "text",
                nullable: true);
        }
    }
}
