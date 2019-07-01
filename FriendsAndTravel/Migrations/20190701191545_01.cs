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
                keyValues: new object[] { "42be8f14-7c1b-4a67-bd0d-19d1e48226ab", "911cc9a5-82d9-4f3a-8f1c-05af0b9d0b1d" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "cd0ca137-196b-4959-8b8b-feee13fb2382", "8e87f91d-9aaf-4778-acbb-7641837a270f" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b870668d-24b3-4cb3-b9b9-9935fcd3cc0b", "ebbab970-d7b8-4698-985a-1e08df4bdb56", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55aad979-0689-4267-b76d-b76d30b2b6c1", "4682c920-6222-4ad3-9337-e9d8d4f2a76c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "55aad979-0689-4267-b76d-b76d30b2b6c1", "4682c920-6222-4ad3-9337-e9d8d4f2a76c" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b870668d-24b3-4cb3-b9b9-9935fcd3cc0b", "ebbab970-d7b8-4698-985a-1e08df4bdb56" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cd0ca137-196b-4959-8b8b-feee13fb2382", "8e87f91d-9aaf-4778-acbb-7641837a270f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "42be8f14-7c1b-4a67-bd0d-19d1e48226ab", "911cc9a5-82d9-4f3a-8f1c-05af0b9d0b1d", "User", "USER" });
        }
    }
}
