using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndTravel.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a01a4241-800e-4d50-ae98-dd94f8b090ae", "0aa20c0e-6a97-44b5-9c1f-417ff6cc2162" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e7f73dc2-2672-43e5-a0a8-2751a2ad4ceb", "3c001f9a-3ab4-40b4-a78d-67860e25e825" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c0bcbdba-0895-4f14-b4b9-ed21d677024e", "3c8ed07e-75bb-471d-a831-7d0beda69515", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2991f08f-3794-4392-b530-c616e1cd628d", "9cb2c896-acdf-48c1-a750-5f76aa57d5d0", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2991f08f-3794-4392-b530-c616e1cd628d", "9cb2c896-acdf-48c1-a750-5f76aa57d5d0" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c0bcbdba-0895-4f14-b4b9-ed21d677024e", "3c8ed07e-75bb-471d-a831-7d0beda69515" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a01a4241-800e-4d50-ae98-dd94f8b090ae", "0aa20c0e-6a97-44b5-9c1f-417ff6cc2162", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e7f73dc2-2672-43e5-a0a8-2751a2ad4ceb", "3c001f9a-3ab4-40b4-a78d-67860e25e825", "User", "USER" });
        }
    }
}
