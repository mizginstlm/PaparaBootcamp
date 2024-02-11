using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalHouseApi.Migrations
{
    /// <inheritdoc />
    public partial class TenantEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("5d1da007-76f3-4c5a-b41e-bd2f73c57f51"));

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("f06a4911-dea0-4ff1-a885-9f7f6c286d7f"), "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("f06a4911-dea0-4ff1-a885-9f7f6c286d7f"));

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("5d1da007-76f3-4c5a-b41e-bd2f73c57f51"), "admin", "admin" });
        }
    }
}
