using Microsoft.EntityFrameworkCore.Migrations;

namespace Riode.Data.Migrations
{
    public partial class acceptedbyid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcceptedById",
                table: "Contacts",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedById",
                table: "Contacts");
        }
    }
}
