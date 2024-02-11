using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalHouseApi.Migrations
{
    /// <inheritdoc />
    public partial class ManagerHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manager",
                columns: new[] { "Id", "ManagerName", "PasswordHash", "PasswordSalt" },
                values: new object[] { new Guid("65945fe2-797c-4965-80ed-64619283655f"), "admin", new byte[] { 138, 4, 74, 255, 204, 191, 205, 118, 213, 211, 208, 195, 15, 100, 33, 220, 133, 25, 86, 212, 127, 156, 193, 207, 175, 209, 172, 212, 59, 143, 110, 125, 42, 152, 51, 235, 206, 135, 10, 79, 204, 164, 233, 252, 1, 16, 193, 227, 121, 246, 32, 86, 210, 97, 142, 64, 36, 190, 74, 128, 159, 58, 189, 148 }, new byte[] { 114, 176, 253, 223, 108, 135, 78, 8, 154, 126, 54, 223, 246, 213, 180, 17, 20, 165, 46, 234, 107, 107, 134, 164, 142, 80, 235, 217, 173, 148, 203, 201, 206, 78, 163, 26, 182, 54, 249, 95, 194, 84, 245, 158, 169, 222, 148, 222, 3, 201, 46, 44, 191, 226, 251, 107, 113, 103, 99, 87, 182, 112, 235, 211, 211, 183, 197, 116, 200, 221, 203, 2, 149, 215, 222, 202, 148, 31, 145, 185, 162, 75, 16, 158, 249, 176, 231, 184, 90, 137, 9, 132, 61, 199, 176, 90, 83, 202, 115, 209, 31, 27, 187, 235, 26, 192, 25, 115, 103, 39, 114, 217, 255, 0, 217, 31, 151, 214, 239, 58, 59, 87, 153, 209, 188, 226, 247, 178 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Manager",
                keyColumn: "Id",
                keyValue: new Guid("65945fe2-797c-4965-80ed-64619283655f"));
        }
    }
}
