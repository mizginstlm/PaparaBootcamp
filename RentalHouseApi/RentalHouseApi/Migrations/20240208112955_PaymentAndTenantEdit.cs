using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalHouseApi.Migrations
{
    /// <inheritdoc />
    public partial class PaymentAndTenantEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("a2b19550-24c8-4c4c-a1de-a5f5d7cb9feb"));

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Block",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("5d1da007-76f3-4c5a-b41e-bd2f73c57f51"), "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("5d1da007-76f3-4c5a-b41e-bd2f73c57f51"));

            migrationBuilder.DropColumn(
                name: "Block",
                table: "Apartments");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Tenants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("a2b19550-24c8-4c4c-a1de-a5f5d7cb9feb"), "admin", "admin" });
        }
    }
}
