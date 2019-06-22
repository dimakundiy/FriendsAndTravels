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
                keyValues: new object[] { "c5202d18-0341-4f3d-87b2-95033e1449d4", "d5899a53-a950-43bc-b489-d3d1b8b05ccb" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "db097475-9a7d-42c9-98c2-cdf684b42810", "982d6837-42c1-4d03-80d0-dc375bf5a428" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f283118f-8f9d-457a-9b48-7160c2a9bfb1", "bd9fcd4e-2d75-4492-8216-8108d99852ef", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5d705bc-4d6a-4968-9a13-61cf01b7d4c8", "57625fc5-f2e2-4cb5-a040-d89aa3c27058", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b5d705bc-4d6a-4968-9a13-61cf01b7d4c8", "57625fc5-f2e2-4cb5-a040-d89aa3c27058" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f283118f-8f9d-457a-9b48-7160c2a9bfb1", "bd9fcd4e-2d75-4492-8216-8108d99852ef" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db097475-9a7d-42c9-98c2-cdf684b42810", "982d6837-42c1-4d03-80d0-dc375bf5a428", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c5202d18-0341-4f3d-87b2-95033e1449d4", "d5899a53-a950-43bc-b489-d3d1b8b05ccb", "User", "USER" });
        }
    }
}
