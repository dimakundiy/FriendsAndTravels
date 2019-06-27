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
                keyValues: new object[] { "73b8a760-641b-4b28-ba16-54378f1fa5b4", "f4d86ac1-a8f4-4240-b67c-0bc1ff46c5a4" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "aab4fbaf-8c49-4520-bdd5-82bf5b9bb3ee", "a72e98f9-c334-4191-9a56-0e2146acd562" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e3830262-105c-402c-acde-38c3cb493cde", "855be11c-78ce-499a-b338-e17eddc40f5b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9da3a8e9-9d38-4929-af5e-794e9cff543b", "c1211ef0-91a7-4933-aafe-cfea09332353", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "9da3a8e9-9d38-4929-af5e-794e9cff543b", "c1211ef0-91a7-4933-aafe-cfea09332353" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e3830262-105c-402c-acde-38c3cb493cde", "855be11c-78ce-499a-b338-e17eddc40f5b" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73b8a760-641b-4b28-ba16-54378f1fa5b4", "f4d86ac1-a8f4-4240-b67c-0bc1ff46c5a4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aab4fbaf-8c49-4520-bdd5-82bf5b9bb3ee", "a72e98f9-c334-4191-9a56-0e2146acd562", "User", "USER" });
        }
    }
}
