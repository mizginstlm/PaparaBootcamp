using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalHouseApi.Migrations
{
    /// <inheritdoc />
    public partial class Manager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("e85462fb-dcde-41d7-a021-a657584960bb"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Manager");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Manager",
                newName: "ManagerName");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Manager",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Manager",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Manager");

            migrationBuilder.RenameColumn(
                name: "ManagerName",
                table: "Manager",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Manager",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("e85462fb-dcde-41d7-a021-a657584960bb"), "admin", "admin" });
        }
    }
}
