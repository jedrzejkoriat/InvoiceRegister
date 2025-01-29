using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceRegister.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class DeleteCompanyService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyServices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VAT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyServices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CompanyServices",
                columns: new[] { "Id", "Name", "Price", "VAT" },
                values: new object[,]
                {
                    { 1, "Service 1", 5000m, 23 },
                    { 2, "Service 2", 7000m, 8 },
                    { 3, "Service 3", 3500m, 5 },
                    { 4, "Service 4", 1500m, 0 },
                    { 5, "Service 5", 3000m, 23 }
                });
        }
    }
}
