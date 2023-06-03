using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfPicoErp.Migrations
{
    /// <inheritdoc />
    public partial class Ivocie_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem");

            migrationBuilder.AddColumn<string>(
                name: "ExternalProductNumber",
                table: "Product",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InternalProductNumber",
                table: "Product",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "InvoiceItem",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "InvoiceItem",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "ExternalProductNumber",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "InternalProductNumber",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "InvoiceItem");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "InvoiceItem");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "InvoiceItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItem_Product_ProductId",
                table: "InvoiceItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
