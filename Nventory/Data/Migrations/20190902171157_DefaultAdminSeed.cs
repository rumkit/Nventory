using Microsoft.EntityFrameworkCore.Migrations;

namespace Nventory.Data.Migrations
{
    public partial class DefaultAdminSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA", "0dcc8842-de6d-45c7-8ccf-d6c8923eaa86", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "646166C4-5E06-4976-AB63-6B0957E06F5F", 0, "b16f7229-c6f2-4446-84a3-9a6bd6117fb7", "admin@example.com", true, false, null, "admin@example.com", "admin", "AQAAAAEAACcQAAAAEG+Y4hOsJd2XpDKoQWwHQ4bURWeS+jxmh4VhaD0MFiF0fHyaQUO5dDC3XS/QUUlZAg==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "646166C4-5E06-4976-AB63-6B0957E06F5F", "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "646166C4-5E06-4976-AB63-6B0957E06F5F", "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "646166C4-5E06-4976-AB63-6B0957E06F5F");
        }
    }
}
