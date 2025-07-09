﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorShop_Project.Data.Migrations
{
    /// <inheritdoc />
    public partial class modify_brand_add_image_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Brands",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Brands");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
