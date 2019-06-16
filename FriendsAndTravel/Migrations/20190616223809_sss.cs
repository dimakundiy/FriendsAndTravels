using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndTravel.Migrations
{
    public partial class sss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "24cb4065-f9f0-4800-bf30-5beb8f0dc606", "8a996952-6652-42e1-b909-dc52e0058fc9" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6288596f-f3ca-49b5-a039-c7b532724cf7", "3fcc12e8-0238-4c99-914b-3ebc1bc0c1c3" });

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PhotoAsBytes",
                table: "Photos");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Photos",
                maxLength: 5242880,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f009327-d907-493d-a0c7-5c4df15552f4", "534884a9-351a-4755-8101-ebde82ac1346", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7165ed3b-807d-4258-852d-746f61afe21f", "d5b44030-5a1e-496e-951b-059b7bad0db2", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2f009327-d907-493d-a0c7-5c4df15552f4", "534884a9-351a-4755-8101-ebde82ac1346" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7165ed3b-807d-4258-852d-746f61afe21f", "d5b44030-5a1e-496e-951b-059b7bad0db2" });

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Photos");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoAsBytes",
                table: "Photos",
                maxLength: 5242880,
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24cb4065-f9f0-4800-bf30-5beb8f0dc606", "8a996952-6652-42e1-b909-dc52e0058fc9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6288596f-f3ca-49b5-a039-c7b532724cf7", "3fcc12e8-0238-4c99-914b-3ebc1bc0c1c3", "User", "USER" });
        }
    }
}
