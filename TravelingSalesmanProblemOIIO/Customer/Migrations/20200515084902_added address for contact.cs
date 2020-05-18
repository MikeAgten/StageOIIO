using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerProj.Migrations
{
    public partial class addedaddressforcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Contacts",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Contacts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Contacts");
        }
    }
}
