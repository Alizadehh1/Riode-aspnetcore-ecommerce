using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Riode.Data.Migrations
{
    public partial class uodatebaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Colors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Colors",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Colors");
        }
    }
}
