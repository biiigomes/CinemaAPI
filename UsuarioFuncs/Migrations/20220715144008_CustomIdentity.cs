using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuarioFuncs.Migrations
{
    public partial class CustomIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "123e4583-fc3e-4f2d-b262-b99a92f239c7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 9999, "633b325d-fed3-4b84-8f44-cd389760729a", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b3e4a54-1930-461b-a000-e21ae12ab21a", "AQAAAAEAACcQAAAAEChZichLk8qbvwbNk2wwXCuK/DLs4oUcQisd0T2KaccZYKt7aLbjy0pDxD5fZU8maA==", "4522f3e8-c7ef-402f-a90f-69283ff2f8b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999);

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "173b1d36-0e06-4deb-b1f2-14840861a9e9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "14a86a2a-cb07-4f2f-9a4f-d3b0675df906", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e3b7406-3fba-4982-b883-e6e1d1e89bc3", "AQAAAAEAACcQAAAAEEecRRaN1o1HqFuGuKApcAMLd6Za3OZ4d6C5cV0R3RTXHN04q1w7YVgfzTp2XSehWw==", "4b3a4e01-bdab-4ed7-b30b-f766aab28579" });
        }
    }
}
