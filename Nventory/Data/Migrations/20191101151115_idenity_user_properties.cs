using Microsoft.EntityFrameworkCore.Migrations;

namespace Nventory.Data.Migrations
{
    public partial class idenity_user_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Patronymic",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Patronymic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C8C481A4-FBFA-4CB4-9CBC-4E00FBD94EDA",
                column: "ConcurrencyStamp",
                value: "3297700b-b475-47fc-9153-5ff068de288b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "646166C4-5E06-4976-AB63-6B0957E06F5F",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a43c5e9-9ec1-44d6-8f72-4e840eacd460", "AQAAAAEAACcQAAAAEPdqIwdD/xADg3O985Zqz03MF5lk2jcwIVgqRrMvgjX3VLNUjHJvGNnsITNxBYf42Q==" });
        }
    }
}
