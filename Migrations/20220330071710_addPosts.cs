using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cheffie.Migrations
{
    public partial class addPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Post_1",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_1", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_1_Cook_CookId",
                        column: x => x.CookId,
                        principalTable: "Cook",
                        principalColumn: "CookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_1_CookId",
                table: "Post_1",
                column: "CookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_1");
        }
    }
}
