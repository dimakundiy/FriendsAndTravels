using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendsAndTravel.Migrations
{
    public partial class _100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "826652c8-a55a-45c6-8b25-b8413885cf76", "103745d0-21f7-41a6-bfd5-0cbf290c3cb6" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ec0afcdc-5cc3-464b-ad58-1a9864394fd8", "86f676f6-b4e8-4360-9dc2-8de68d7333de" });

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 5242880);

            migrationBuilder.AddColumn<byte[]>(
                name: "PhotoAsBytes",
                table: "Photos",
                maxLength: 5242880,
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e80f1f24-baf0-4eda-a628-18f4828a0c80", "26b50b3c-3c69-4da3-8dbb-55e8bc442e7e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "df4f96e0-6d8e-4fb9-9c21-66c4a0df55e8", "56804dc8-1576-4c7d-b065-75f04be60e81", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "df4f96e0-6d8e-4fb9-9c21-66c4a0df55e8", "56804dc8-1576-4c7d-b065-75f04be60e81" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e80f1f24-baf0-4eda-a628-18f4828a0c80", "26b50b3c-3c69-4da3-8dbb-55e8bc442e7e" });

            migrationBuilder.DropColumn(
                name: "PhotoAsBytes",
                table: "Photos");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Photos",
                maxLength: 5242880,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "826652c8-a55a-45c6-8b25-b8413885cf76", "103745d0-21f7-41a6-bfd5-0cbf290c3cb6", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ec0afcdc-5cc3-464b-ad58-1a9864394fd8", "86f676f6-b4e8-4360-9dc2-8de68d7333de", "User", "USER" });
        }
    }
}
