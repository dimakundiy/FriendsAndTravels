using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndTravel.Migrations
{
    public partial class dddkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "554ebe55-e98b-45e6-9e8f-00c5e5763263", "23bc7392-4f87-410b-8509-f7d8ab8b33a4" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c1784aa0-331f-49b0-b871-770bdf2cd1e2", "6abf30e5-ffb6-4367-9714-bdff4b6c1f5e" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "24cb4065-f9f0-4800-bf30-5beb8f0dc606", "8a996952-6652-42e1-b909-dc52e0058fc9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6288596f-f3ca-49b5-a039-c7b532724cf7", "3fcc12e8-0238-4c99-914b-3ebc1bc0c1c3", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "24cb4065-f9f0-4800-bf30-5beb8f0dc606", "8a996952-6652-42e1-b909-dc52e0058fc9" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "6288596f-f3ca-49b5-a039-c7b532724cf7", "3fcc12e8-0238-4c99-914b-3ebc1bc0c1c3" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1784aa0-331f-49b0-b871-770bdf2cd1e2", "6abf30e5-ffb6-4367-9714-bdff4b6c1f5e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "554ebe55-e98b-45e6-9e8f-00c5e5763263", "23bc7392-4f87-410b-8509-f7d8ab8b33a4", "User", "USER" });
        }
    }
}
