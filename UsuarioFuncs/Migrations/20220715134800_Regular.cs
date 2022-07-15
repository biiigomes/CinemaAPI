using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuarioFuncs.Migrations
{
    public partial class Regular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "98b24daa-e76a-4c40-8cfd-6dd2d13a487b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a9090ac-88bd-4b26-8d4f-0b9e70130410", "AQAAAAEAACcQAAAAEG5AAT1asmjUQTSpN9Nbe13KCK8opSpKS1BGWj/Qcwvw6Lp3qF5JSWAhkYnJWVI/vg==", "ba22468f-8701-4f70-8e8c-8ed6cf17ddad" });
        }
    }
}
