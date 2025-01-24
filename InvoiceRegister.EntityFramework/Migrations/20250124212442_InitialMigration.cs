using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvoiceRegister.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
