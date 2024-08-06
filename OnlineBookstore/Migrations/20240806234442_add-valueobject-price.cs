using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineBookstore.Migrations
{
    public partial class addvalueobjectprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price_Amount",
                table: "Books",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Price_Currency",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Amount",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                table: "Books");
        }
    }
}
