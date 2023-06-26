using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuctionSystem.Infrastructure.Migrations
{
    public partial class AddImageUrlColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Auctions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Auctions");
        }
    }
}
