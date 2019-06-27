using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndTravel.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "32353012-a8b1-4426-bc71-3d7f0891f982", "cdbce65e-14ae-4004-ac69-44500002c9f1" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "43c43161-e7b0-4f8e-b46c-e3d0f6b48c88", "83828962-b737-496b-875e-4b17b5bada5c" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdc0c520-1dcd-4181-9b87-58c80b2ccdd0", "3368a2db-de93-4e40-837b-1210dfa77db5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d891e6a-88c3-4100-9547-45df023b3d4f", "ecee66a0-428e-47ff-b1ed-31b93f767e9c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2d891e6a-88c3-4100-9547-45df023b3d4f", "ecee66a0-428e-47ff-b1ed-31b93f767e9c" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "fdc0c520-1dcd-4181-9b87-58c80b2ccdd0", "3368a2db-de93-4e40-837b-1210dfa77db5" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "32353012-a8b1-4426-bc71-3d7f0891f982", "cdbce65e-14ae-4004-ac69-44500002c9f1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "43c43161-e7b0-4f8e-b46c-e3d0f6b48c88", "83828962-b737-496b-875e-4b17b5bada5c", "User", "USER" });
        }
    }
}
