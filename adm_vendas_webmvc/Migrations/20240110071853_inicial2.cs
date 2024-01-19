using Microsoft.EntityFrameworkCore.Migrations;

namespace adm_vendas_webmvc.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartamentsId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_DepartamentsId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "DepartamentsId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentModelId",
                table: "Seller",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DepartmentModelId",
                table: "Seller",
                column: "DepartmentModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartmentModelId",
                table: "Seller",
                column: "DepartmentModelId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Department_DepartmentModelId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_DepartmentModelId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "DepartmentModelId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentsId",
                table: "Seller",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_DepartamentsId",
                table: "Seller",
                column: "DepartamentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Department_DepartamentsId",
                table: "Seller",
                column: "DepartamentsId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
