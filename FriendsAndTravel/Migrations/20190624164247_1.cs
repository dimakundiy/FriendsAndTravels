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
                keyValues: new object[] { "133071c0-4690-4cda-844e-25ec9730d4a0", "1006b5b7-a94a-43e2-9466-da3843efcc05" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2ccaa859-fc21-49c7-85be-5f44305b3af0", "0ea8d0c7-317c-4c0e-9860-c5cde6baa79c" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3999cb1-0ff1-4dfc-ba2a-158e93b944e6", "d11f54d3-30c8-426f-8a9f-35a8a1ee0efa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26aef1ab-278a-457a-b2a8-30616bd6e471", "c0b44dab-8e2a-4735-a670-cfafd4bd81e5", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "26aef1ab-278a-457a-b2a8-30616bd6e471", "c0b44dab-8e2a-4735-a670-cfafd4bd81e5" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "c3999cb1-0ff1-4dfc-ba2a-158e93b944e6", "d11f54d3-30c8-426f-8a9f-35a8a1ee0efa" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ccaa859-fc21-49c7-85be-5f44305b3af0", "0ea8d0c7-317c-4c0e-9860-c5cde6baa79c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "133071c0-4690-4cda-844e-25ec9730d4a0", "1006b5b7-a94a-43e2-9466-da3843efcc05", "User", "USER" });
        }
    }
}
