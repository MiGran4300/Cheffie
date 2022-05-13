using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cheffie.Migrations
{
    public partial class addowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerID",
                table: "Cook",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Cook");
        }
    }
}
