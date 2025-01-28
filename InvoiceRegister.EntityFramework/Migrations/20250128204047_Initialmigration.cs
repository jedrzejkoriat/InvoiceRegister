using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvoiceRegister.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

			migrationBuilder.CreateTable(
				name: "Invoices",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					ClientId = table.Column<int>(type: "int", nullable: false),
					InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
					IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					PaymentDueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					IsPaid = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Invoices", x => x.Id);

					table.ForeignKey(
						name: "FK_Invoices_Clients_ClientId",
						column: x => x.ClientId,
						principalTable: "Clients",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "InvoiceItems",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					InvoiceId = table.Column<int>(type: "int", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Amount = table.Column<int>(type: "int", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					VAT = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_InvoiceItems", x => x.Id);

					table.ForeignKey(
						name: "FK_InvoiceItems_Invoices_InvoiceId",
						column: x => x.InvoiceId,
						principalTable: "Invoices",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

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

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);

					table.ForeignKey(
						name: "FK_Payments_Invoices_InvoiceId",
						column: x => x.InvoiceId,
						principalTable: "Invoices",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "City", "Email", "NIP", "Name", "PostCode", "Street" },
                values: new object[,]
                {
                    { 1, "Warszawa", "company_A@localhost.com", "0123456789", "Company A", "02-691", "Cybernetyki 5" },
                    { 2, "Kraków", "company_B@localhost.com", "9876543210", "Company B", "31-021", "Floriańska 12" },
                    { 3, "Gdańsk", "company_C@localhost.com", "1234567891", "Company C", "80-831", "Długa 32" },
                    { 4, "Wrocław", "company_D@localhost.com", "2345678901", "Company D", "50-066", "Świdnicka 15" },
                    { 5, "Poznań", "company_E@localhost.com", "3456789012", "Company E", "61-888", "Półwiejska 20" },
                    { 6, "Łódź", "company_F@localhost.com", "4567890123", "Company F", "90-009", "Piotrkowska 76" },
                    { 7, "Katowice", "company_G@localhost.com", "5678901234", "Company G", "40-095", "Stawowa 10" },
                    { 8, "Lublin", "company_H@localhost.com", "6789012345", "Company H", "20-002", "Krakowskie Przedmieście 5" },
                    { 9, "Szczecin", "company_I@localhost.com", "7890123456", "Company I", "70-001", "Aleja Niepodległości 4" },
                    { 10, "Bydgoszcz", "company_J@localhost.com", "8901234567", "Company J", "85-009", "Dworcowa 25" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CompanyServices");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
