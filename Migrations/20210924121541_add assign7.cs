using Microsoft.EntityFrameworkCore.Migrations;

namespace SixthWeb.Migrations
{
    public partial class addassign7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Assignments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UserId",
                table: "Assignments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_UserId",
                table: "Assignments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
