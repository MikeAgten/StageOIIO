using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerProj.Migrations
{
    public partial class Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Tenant_tenantId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Customers_tenantId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "tenantId",
                table: "Customers",
                newName: "TenantId");

            migrationBuilder.AlterColumn<int>(
                name: "TenantId",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Customers",
                newName: "tenantId");

            migrationBuilder.AlterColumn<int>(
                name: "tenantId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_tenantId",
                table: "Customers",
                column: "tenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Tenant_tenantId",
                table: "Customers",
                column: "tenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
