﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaparaApp.API.Migrations
{
    /// <inheritdoc />
    public partial class ProductFeaturesupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductDefinitonId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductFeatureId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductDefinitonId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductFeatureId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
