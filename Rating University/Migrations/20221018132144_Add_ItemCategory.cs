using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rating_University.Migrations
{
    public partial class Add_ItemCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ItemCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCategories_AspNetUsers_CategoryId",
                table: "ItemCategories",
                column: "CategoryId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCategories_AspNetUsers_CategoryId",
                table: "ItemCategories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ItemCategories");
        }
    }
}
