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
                keyValues: new object[] { "c1534b7f-93a5-40e6-b749-0e6b899fc4d8", "b7593384-df5e-43de-ba76-db5bb90da4af" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f0c32a61-81be-4814-a048-a6a4a8e51283", "edb2a72c-6d6d-4878-9335-bdc8a2509bdb" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2535d614-67fe-4adb-9da7-af8c6f1762a5", "ddefce1c-926c-4b46-8129-f2f5a6bc9195", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3430601-4a02-4d5b-adbe-c653be8760ef", "a482e7ea-8a1a-4268-b9ab-a975413fd8b4", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2535d614-67fe-4adb-9da7-af8c6f1762a5", "ddefce1c-926c-4b46-8129-f2f5a6bc9195" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d3430601-4a02-4d5b-adbe-c653be8760ef", "a482e7ea-8a1a-4268-b9ab-a975413fd8b4" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1534b7f-93a5-40e6-b749-0e6b899fc4d8", "b7593384-df5e-43de-ba76-db5bb90da4af", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0c32a61-81be-4814-a048-a6a4a8e51283", "edb2a72c-6d6d-4878-9335-bdc8a2509bdb", "User", "USER" });
        }
    }
}
