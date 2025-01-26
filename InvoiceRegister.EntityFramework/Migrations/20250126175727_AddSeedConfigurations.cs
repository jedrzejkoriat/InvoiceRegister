using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceRegister.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "InvoiceItems",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "VAT",
                table: "InvoiceItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                table: "Clients",
                columns: new[] { "Id", "City", "NIP", "Name", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Warszawa", "0123456789", "Firma A", "02-691", "Cybernetyki 5" },
                    { 2, "Kraków", "9876543210", "Firma B", "31-021", "Floriańska 12" },
                    { 3, "Gdańsk", "1234567891", "Firma C", "80-831", "Długa 32" },
                    { 4, "Wrocław", "2345678901", "Firma D", "50-066", "Świdnicka 15" },
                    { 5, "Poznań", "3456789012", "Firma E", "61-888", "Półwiejska 20" },
                    { 6, "Łódź", "4567890123", "Firma F", "90-009", "Piotrkowska 76" },
                    { 7, "Katowice", "5678901234", "Firma G", "40-095", "Stawowa 10" },
                    { 8, "Lublin", "6789012345", "Firma H", "20-002", "Krakowskie Przedmieście 5" },
                    { 9, "Szczecin", "7890123456", "Firma I", "70-001", "Aleja Niepodległości 4" },
                    { 10, "Bydgoszcz", "8901234567", "Firma J", "85-009", "Dworcowa 25" }
                });

            migrationBuilder.InsertData(
                table: "CompanyServices",
                columns: new[] { "Id", "Name", "Price", "VAT" },
                values: new object[,]
                {
                    { 1, "Usługa 1", 5000m, 23 },
                    { 2, "Usługa 2", 7000m, 8 },
                    { 3, "Usługa 3", 3500m, 5 },
                    { 4, "Usługa 4", 1500m, 0 },
                    { 5, "Usługa 5", 3000m, 23 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyServices");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "InvoiceItems",
                newName: "UnitPrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "VAT",
                table: "InvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
