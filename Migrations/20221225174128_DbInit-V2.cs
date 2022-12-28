using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigCorp.Migrations
{
    /// <inheritdoc />
    public partial class DbInitV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductLine_ProductLineid",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stock_Stockid",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Stockid",
                table: "Product",
                newName: "stockid");

            migrationBuilder.RenameColumn(
                name: "ProductLineid",
                table: "Product",
                newName: "productLineid");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Stockid",
                table: "Product",
                newName: "IX_Product_stockid");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductLineid",
                table: "Product",
                newName: "IX_Product_productLineid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductLine_productLineid",
                table: "Product",
                column: "productLineid",
                principalTable: "ProductLine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stock_stockid",
                table: "Product",
                column: "stockid",
                principalTable: "Stock",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductLine_productLineid",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Stock_stockid",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "stockid",
                table: "Product",
                newName: "Stockid");

            migrationBuilder.RenameColumn(
                name: "productLineid",
                table: "Product",
                newName: "ProductLineid");

            migrationBuilder.RenameIndex(
                name: "IX_Product_stockid",
                table: "Product",
                newName: "IX_Product_Stockid");

            migrationBuilder.RenameIndex(
                name: "IX_Product_productLineid",
                table: "Product",
                newName: "IX_Product_ProductLineid");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductLine_ProductLineid",
                table: "Product",
                column: "ProductLineid",
                principalTable: "ProductLine",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Stock_Stockid",
                table: "Product",
                column: "Stockid",
                principalTable: "Stock",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
