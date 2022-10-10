using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace E_commerce.Migrations
{
    public partial class sec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TbCategories",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "(N'')");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbCategories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "('0001-01-01T00:00:00.0000000')");

            migrationBuilder.AddColumn<int>(
                name: "CurrentState",
                table: "TbCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "TbCategories",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "(N'')");

            migrationBuilder.AddColumn<bool>(
                name: "ShowInHomePage",
                table: "TbCategories",
                type: "bit",
                nullable: false,
                defaultValueSql: "(CONVERT([bit],(0)))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TbCategories");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbCategories");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbCategories");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "TbCategories");

            migrationBuilder.DropColumn(
                name: "ShowInHomePage",
                table: "TbCategories");
        }
    }
}
