using Microsoft.EntityFrameworkCore.Migrations;

namespace Nventory.Data.Migrations
{
    public partial class operator_role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA",
                column: "ConcurrencyStamp",
                value: "5ada1ddd-82fc-4590-ade2-8c3826ae5e20");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "646166C4-5E06-4976-AB63-6B0957E06F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7fbcc0bf-c84a-45ea-adea-1242a1021dc5", "AQAAAAEAACcQAAAAEHnsOvUUOlNndHFXLn1iPvzynKU+AKhnuj+jd0p+4dGp/kFMIeTY5wy//gS/ZEqCiA==" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1C25992F-BFB2-47CF-94AC-8EF5D18BC2D3", "FE0ACD1C-47AC-4E90-8E4A-DB0CF1F6D738", "operator", "OPERATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA",
                column: "ConcurrencyStamp",
                value: "c0a323d2-2ecf-401e-8cc5-ee6a9ff6d9a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "646166C4-5E06-4976-AB63-6B0957E06F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9df0b2cf-4d9a-40d4-b760-6604593ef9c6", "AQAAAAEAACcQAAAAEHuJAWH3ajUBeu0+/2Y2pSszQCmaH0GJCNp3g/oaXdPf4vBpBZmVKKE9YZ53Sj28LQ==" });

            migrationBuilder.DeleteData(
               table: "AspNetRoles",
               keyColumn: "Id",
               keyValue: "1C25992F-BFB2-47CF-94AC-8EF5D18BC2D3");
        }
    }
}
