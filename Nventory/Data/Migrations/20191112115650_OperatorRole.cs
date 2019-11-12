using Microsoft.EntityFrameworkCore.Migrations;

namespace Nventory.Data.Migrations
{
    public partial class OperatorRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA",
                column: "ConcurrencyStamp",
                value: "299a088e-474d-49e5-8e2b-3e1d54380867");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "090BF443-C00C-4748-A860-E6DE80EBDEED", "6363ddd8-307b-440a-b616-d250761273ba", "Operator", "OPERATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "646166C4-5E06-4976-AB63-6B0957E06F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e5260626-a22b-41fe-9bcc-fb5a9aa10ecd", "AQAAAAEAACcQAAAAEHf6o+1Bz6h0fQJSZ7Z+WL+X5o3u8lsUYDqr5LFtMtZ3femeOx/nuDtNnjgSyfOdWg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "090BF443-C00C-4748-A860-E6DE80EBDEED");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA",
                column: "ConcurrencyStamp",
                value: "385e4074-77ab-4b26-9ab9-c0511cd2f3ed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "646166C4-5E06-4976-AB63-6B0957E06F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7f58a677-9c2d-426f-a760-b96b19608701", "AQAAAAEAACcQAAAAEI3n5S6CdEtQqNkQlIUyAHYKtQ86yTUDC9eHXeYiKhZUBXBuJdFHcQ8bxCOZY+xM1w==" });
        }
    }
}
