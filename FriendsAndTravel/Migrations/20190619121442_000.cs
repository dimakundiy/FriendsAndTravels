using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndTravel.Migrations
{
    public partial class _000 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7c4b697e-f149-4ccc-8554-b08ecd8f3232", "5551fb1f-4fd7-4f3c-b15c-1829426c39ea" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bd5d31e6-179b-4e12-a9a5-c3b7140a7847", "80f11260-765e-440a-9a03-799bf5a3fad2" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "50fa0ee8-dc76-417a-a94a-5a6563ac5111", "f30ffda5-e576-41cb-b164-555765fdb6a3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "538be936-2395-4c0e-adcc-04bea3435b03", "57f59a08-9247-47d6-9017-3d504f5d72e0", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "50fa0ee8-dc76-417a-a94a-5a6563ac5111", "f30ffda5-e576-41cb-b164-555765fdb6a3" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "538be936-2395-4c0e-adcc-04bea3435b03", "57f59a08-9247-47d6-9017-3d504f5d72e0" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c4b697e-f149-4ccc-8554-b08ecd8f3232", "5551fb1f-4fd7-4f3c-b15c-1829426c39ea", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bd5d31e6-179b-4e12-a9a5-c3b7140a7847", "80f11260-765e-440a-9a03-799bf5a3fad2", "User", "USER" });
        }
    }
}
