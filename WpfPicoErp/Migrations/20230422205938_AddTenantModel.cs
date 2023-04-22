using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfPicoErp.Migrations
{
    /// <inheritdoc />
    public partial class AddTenantModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Invoice",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    TaxId = table.Column<string>(type: "TEXT", nullable: true),
                    BankName = table.Column<string>(type: "TEXT", nullable: true),
                    BankAccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    BankRoutingNumber = table.Column<string>(type: "TEXT", nullable: true),
                    BIC = table.Column<string>(type: "TEXT", nullable: true),
                    IBAN = table.Column<string>(type: "TEXT", nullable: true),
                    LogoPath = table.Column<string>(type: "TEXT", nullable: true),
                    SignaturePath = table.Column<string>(type: "TEXT", nullable: true),
                    InvoiceFooterText = table.Column<string>(type: "TEXT", nullable: true),
                    CEOFirstName = table.Column<string>(type: "TEXT", nullable: true),
                    CEOLastName = table.Column<string>(type: "TEXT", nullable: true),
                    CEOTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ChamberOfCommerceName = table.Column<string>(type: "TEXT", nullable: true),
                    ChamberOfCommerceId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenant", x => x.TenantId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_TenantId",
                table: "Invoice",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Tenant_TenantId",
                table: "Invoice",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Tenant_TenantId",
                table: "Invoice");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_TenantId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Invoice");
        }
    }
}
