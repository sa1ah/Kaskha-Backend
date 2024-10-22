using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kashkha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_products_ProductId",
                table: "Favorites",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_products_ProductId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites");
        }
    }
}
