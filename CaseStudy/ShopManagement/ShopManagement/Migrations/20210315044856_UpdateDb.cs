using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopManagement.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "appIdentityUserId",
                table: "carts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carts_appIdentityUserId",
                table: "carts",
                column: "appIdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_AppIdentityUser_appIdentityUserId",
                table: "carts",
                column: "appIdentityUserId",
                principalTable: "AppIdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_AppIdentityUser_appIdentityUserId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_appIdentityUserId",
                table: "carts");

            migrationBuilder.DropColumn(
                name: "appIdentityUserId",
                table: "carts");
        }
    }
}
