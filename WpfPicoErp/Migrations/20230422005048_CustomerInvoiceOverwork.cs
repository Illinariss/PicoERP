using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfPicoErp.Migrations
{
    /// <inheritdoc />
    public partial class CustomerInvoiceOverwork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Customer",
                newName: "PreferredContactMethod");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Customer",
                newName: "ContactPerson");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Customer",
                newName: "CompanyName");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Invoice",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAttention",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCustomerName",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingPostalCode",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCity",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPostalCode",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyUstIdNr",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Invoice",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "GrossTotal",
                table: "Invoice",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "Invoice",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PaymentTermsId",
                table: "Invoice",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAttention",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingCity",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingCustomerName",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingPostalCode",
                table: "Invoice",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TaxTotal",
                table: "Invoice",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountId",
                table: "Customer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillingAddressId",
                table: "Customer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SepaDirectDebit",
                table: "Customer",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ShippingAddressId",
                table: "Customer",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Adress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankName = table.Column<string>(type: "TEXT", nullable: true),
                    AccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    SortCode = table.Column<string>(type: "TEXT", nullable: true),
                    Iban = table.Column<string>(type: "TEXT", nullable: true),
                    Bic = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", nullable: true),
                    UploadDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTerm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentDueDays = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    HasDiscount = table.Column<bool>(type: "INTEGER", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "TEXT", nullable: false),
                    DiscountDueDays = table.Column<int>(type: "INTEGER", nullable: false),
                    HasInstallments = table.Column<bool>(type: "INTEGER", nullable: false),
                    NumberOfInstallments = table.Column<int>(type: "INTEGER", nullable: false),
                    LatePaymentInterestRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    LatePaymentInterestPeriod = table.Column<int>(type: "INTEGER", nullable: false),
                    HasCollectionProcess = table.Column<bool>(type: "INTEGER", nullable: false),
                    CollectionProcessDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTerm", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PaymentTermsId",
                table: "Invoice",
                column: "PaymentTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BankAccountId",
                table: "Customer",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BillingAddressId",
                table: "Customer",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ShippingAddressId",
                table: "Customer",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_CustomerId",
                table: "Document",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Adress_BillingAddressId",
                table: "Customer",
                column: "BillingAddressId",
                principalTable: "Adress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Adress_ShippingAddressId",
                table: "Customer",
                column: "ShippingAddressId",
                principalTable: "Adress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_BankAccounts_BankAccountId",
                table: "Customer",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                table: "Invoice",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_PaymentTerm_PaymentTermsId",
                table: "Invoice",
                column: "PaymentTermsId",
                principalTable: "PaymentTerm",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Adress_BillingAddressId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Adress_ShippingAddressId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_BankAccounts_BankAccountId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_PaymentTerm_PaymentTermsId",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "Adress");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "PaymentTerm");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_PaymentTermsId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Customer_BankAccountId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_BillingAddressId",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ShippingAddressId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BillingAddress",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BillingAttention",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BillingCustomerName",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BillingPostalCode",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CompanyCity",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CompanyPostalCode",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "CompanyUstIdNr",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "GrossTotal",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "PaymentTermsId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ShippingAttention",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ShippingCity",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ShippingCustomerName",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ShippingPostalCode",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "TaxTotal",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "BankAccountId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "BillingAddressId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SepaDirectDebit",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ShippingAddressId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "PreferredContactMethod",
                table: "Customer",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "ContactPerson",
                table: "Customer",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Customer",
                newName: "City");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Invoice",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Customer",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Customer_CustomerId",
                table: "Invoice",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
