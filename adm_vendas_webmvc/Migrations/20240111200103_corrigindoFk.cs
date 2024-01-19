using Microsoft.EntityFrameworkCore.Migrations;

namespace adm_vendas_webmvc.Migrations
{
    public partial class corrigindoFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellersId",
                table: "SalesRecord");

            migrationBuilder.RenameColumn(
                name: "SellersId",
                table: "SalesRecord",
                newName: "SellerModelId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "SalesRecord",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellersId",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellerModelId",
                table: "SalesRecord",
                column: "SellerModelId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecord_Seller_SellerModelId",
                table: "SalesRecord");

            migrationBuilder.RenameColumn(
                name: "SellerModelId",
                table: "SalesRecord",
                newName: "SellersId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "SalesRecord",
                newName: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_SalesRecord_SellerModelId",
                table: "SalesRecord",
                newName: "IX_SalesRecord_SellersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecord_Seller_SellersId",
                table: "SalesRecord",
                column: "SellersId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
