using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETickets.Migrations
{
    /// <inheritdoc />
    public partial class editProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_purchasedProducts_PurchasedProductId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_purchasedProducts_products_ProductId",
                table: "purchasedProducts");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropIndex(
                name: "IX_purchasedProducts_ProductId",
                table: "purchasedProducts");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PurchasedProductId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PurchasedProductId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "purchasedProducts",
                newName: "ApplicatinName");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "purchasedProducts",
                newName: "numOfTicets");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "purchasedProducts",
                newName: "MoviePrice");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "purchasedProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "purchasedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovieName",
                table: "purchasedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductPrice",
                table: "purchasedProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_purchasedProducts_ApplicationUserId",
                table: "purchasedProducts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_purchasedProducts_MovieId",
                table: "purchasedProducts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_purchasedProducts_AspNetUsers_ApplicationUserId",
                table: "purchasedProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchasedProducts_Movies_MovieId",
                table: "purchasedProducts",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchasedProducts_AspNetUsers_ApplicationUserId",
                table: "purchasedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_purchasedProducts_Movies_MovieId",
                table: "purchasedProducts");

            migrationBuilder.DropIndex(
                name: "IX_purchasedProducts_ApplicationUserId",
                table: "purchasedProducts");

            migrationBuilder.DropIndex(
                name: "IX_purchasedProducts_MovieId",
                table: "purchasedProducts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "purchasedProducts");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "purchasedProducts");

            migrationBuilder.DropColumn(
                name: "MovieName",
                table: "purchasedProducts");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "purchasedProducts");

            migrationBuilder.RenameColumn(
                name: "numOfTicets",
                table: "purchasedProducts",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "MoviePrice",
                table: "purchasedProducts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ApplicatinName",
                table: "purchasedProducts",
                newName: "UserId");

            migrationBuilder.AddColumn<int>(
                name: "PurchasedProductId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_purchasedProducts_ProductId",
                table: "purchasedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PurchasedProductId",
                table: "AspNetUsers",
                column: "PurchasedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_purchasedProducts_PurchasedProductId",
                table: "AspNetUsers",
                column: "PurchasedProductId",
                principalTable: "purchasedProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchasedProducts_products_ProductId",
                table: "purchasedProducts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
