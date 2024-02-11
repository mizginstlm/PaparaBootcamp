using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalHouseApi.Migrations
{
    /// <inheritdoc />
    public partial class RoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("b5e8e1eb-e83d-4dc3-b241-a938dc7ebe91"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "ManagerName", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("1f2fbc73-6445-4752-89b5-eb5e5db61feb"), "admin", new byte[] { 91, 74, 68, 161, 165, 125, 185, 96, 14, 31, 14, 59, 106, 202, 42, 100, 186, 104, 237, 114, 20, 184, 47, 53, 230, 213, 59, 53, 119, 147, 166, 42, 67, 100, 225, 199, 232, 110, 14, 52, 194, 162, 230, 224, 32, 154, 3, 22, 165, 7, 129, 223, 111, 245, 43, 163, 98, 166, 136, 61, 96, 85, 16, 180 }, new byte[] { 153, 73, 47, 125, 205, 154, 18, 219, 132, 185, 177, 163, 197, 35, 49, 183, 130, 88, 220, 116, 208, 53, 164, 179, 83, 12, 253, 85, 104, 37, 128, 176, 249, 128, 208, 150, 28, 232, 67, 0, 5, 196, 249, 232, 98, 213, 173, 40, 143, 111, 207, 27, 122, 103, 55, 166, 166, 48, 33, 19, 220, 80, 5, 12, 133, 25, 151, 43, 112, 166, 121, 83, 130, 45, 32, 19, 134, 134, 143, 35, 149, 139, 175, 153, 173, 4, 191, 170, 117, 121, 63, 122, 192, 37, 63, 188, 255, 43, 235, 130, 65, 164, 250, 133, 122, 205, 202, 148, 191, 32, 42, 208, 73, 48, 254, 32, 201, 243, 36, 84, 30, 4, 4, 222, 232, 7, 88, 86 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("1f2fbc73-6445-4752-89b5-eb5e5db61feb"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "ManagerName", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("b5e8e1eb-e83d-4dc3-b241-a938dc7ebe91"), "admin", new byte[] { 105, 182, 92, 176, 245, 201, 234, 182, 40, 24, 22, 17, 239, 72, 135, 43, 120, 156, 210, 221, 38, 49, 39, 183, 133, 238, 50, 44, 232, 34, 171, 216, 194, 159, 72, 113, 77, 201, 100, 94, 108, 140, 222, 69, 23, 1, 88, 38, 88, 50, 60, 215, 43, 42, 86, 48, 40, 91, 36, 25, 220, 216, 76, 201 }, new byte[] { 61, 12, 156, 123, 81, 158, 158, 144, 67, 234, 51, 43, 46, 84, 245, 223, 53, 31, 252, 56, 228, 226, 39, 58, 226, 43, 58, 175, 8, 66, 156, 55, 252, 148, 13, 108, 38, 205, 54, 165, 209, 156, 24, 85, 171, 203, 118, 115, 13, 83, 1, 30, 132, 193, 60, 72, 236, 93, 229, 103, 236, 43, 220, 222, 178, 243, 74, 229, 148, 94, 205, 122, 154, 255, 47, 146, 130, 190, 163, 180, 199, 255, 75, 4, 128, 61, 212, 147, 32, 51, 244, 126, 216, 18, 48, 11, 67, 17, 108, 206, 111, 24, 25, 96, 182, 83, 81, 104, 77, 224, 18, 79, 176, 145, 2, 116, 214, 159, 80, 250, 84, 32, 144, 129, 32, 236, 206, 79 } });
        }
    }
}
