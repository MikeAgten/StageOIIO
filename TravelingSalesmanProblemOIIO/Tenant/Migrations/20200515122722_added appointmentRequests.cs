using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenantProj.Migrations
{
    public partial class addedappointmentRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    AppointmentId = table.Column<int>(nullable: true),
                    CreatedDateUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentRequests");
        }
    }
}
