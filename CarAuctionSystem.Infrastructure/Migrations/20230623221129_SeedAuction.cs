using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAuctionSystem.Infrastructure.Migrations
{
    public partial class SeedAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_AspNetUsers_SellerId",
                table: "Auctions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("29a76321-1b13-432b-ac4d-2783aa025546"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "Auctions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("5af6e6e8-4756-42dd-9acf-c965842f0fc4"), 0, "458c6fe1-fd20-4083-a786-fa525d20ab86", "emiliqn.slav@gmail.com", false, false, null, "EMILIQN.SLAV@GMAIL.COM", "EMILIQN.SLAV@GMAIL.COM", "AQAAAAEAACcQAAAAEFcdP04h/YqN4Cy/hWN8w1N3EDMTSioqFMzqo3ul0AEUuaVkTMbcY3ARZAFnMy7kfg==", null, false, null, false, "emiliqn.slav@gmail.com" });

            migrationBuilder.InsertData(
                table: "Auctions",
                columns: new[] { "Id", "CarBodyId", "DrivetrainId", "EndDate", "EngineDetails", "ExteriorColor", "FuelId", "InteriorColor", "MakeId", "Mileage", "Model", "ModelYear", "SellerId", "StartDate", "TransmissionId", "Vin" },
                values: new object[] { 1, 4, 2, new DateTime(2023, 6, 26, 22, 11, 29, 146, DateTimeKind.Utc).AddTicks(3150), "2.7L Inline-5", "Brilliant silver metallic", 2, "Black/Antracite", 32, 250000, "C270 CDI", 2004, null, new DateTime(2023, 6, 23, 22, 11, 29, 146, DateTimeKind.Utc).AddTicks(3146), 2, "WDB2030161A714562" });

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_AspNetUsers_SellerId",
                table: "Auctions",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auctions_AspNetUsers_SellerId",
                table: "Auctions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5af6e6e8-4756-42dd-9acf-c965842f0fc4"));

            migrationBuilder.DeleteData(
                table: "Auctions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "Auctions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("29a76321-1b13-432b-ac4d-2783aa025546"), 0, "470f59ba-6e3b-482b-bafa-8b2d5c63f45c", "emiliqn.slav@gmail.com", false, false, null, "EMILIQN.SLAV@GMAIL.COM", "EMILIQN.SLAV@GMAIL.COM", "AQAAAAEAACcQAAAAEH8lpW8S3yc/BOtKFLURBbkRpdAg/H8L0L1f+KetySCKzky0N3zAua2Z452Bthcg+w==", null, false, null, false, "emiliqn.slav@gmail.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Auctions_AspNetUsers_SellerId",
                table: "Auctions",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
