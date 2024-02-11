using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalHouseApi.Migrations
{
    /// <inheritdoc />
    public partial class EditEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("f06a4911-dea0-4ff1-a885-9f7f6c286d7f"));

            migrationBuilder.AlterColumn<int>(
                name: "ApartmentNumber",
                table: "Apartments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("e85462fb-dcde-41d7-a021-a657584960bb"), "admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("e85462fb-dcde-41d7-a021-a657584960bb"));

            migrationBuilder.AlterColumn<string>(
                name: "ApartmentNumber",
                table: "Apartments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("f06a4911-dea0-4ff1-a885-9f7f6c286d7f"), "admin", "admin" });
        }
    }
}
