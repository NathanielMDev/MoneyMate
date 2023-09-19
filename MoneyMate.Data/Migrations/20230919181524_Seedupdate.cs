using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MoneyMate.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seedupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21b639d5-0c6a-43fe-85bf-65fb5842cb43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f24e262a-c09b-4745-9079-c994113a935e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f4054c95-0087-429f-a5a5-739b739e255b", null, "User", "USER" },
                    { "f6e8d4d7-154d-49c6-b8e5-2d9250f13281", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4054c95-0087-429f-a5a5-739b739e255b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6e8d4d7-154d-49c6-b8e5-2d9250f13281");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21b639d5-0c6a-43fe-85bf-65fb5842cb43", null, "Administrator", "ADMINISTRATOR" },
                    { "f24e262a-c09b-4745-9079-c994113a935e", null, "User", "USER" }
                });
        }
    }
}
