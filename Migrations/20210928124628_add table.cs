using Microsoft.EntityFrameworkCore.Migrations;

namespace SixthWeb.Migrations
{
    public partial class addtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Assignments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersAssignmentId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsersAssignmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAssignments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_UsersAssignmentId",
                table: "Assignments",
                column: "UsersAssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UsersAssignmentId",
                table: "AspNetUsers",
                column: "UsersAssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UsersAssignments_UsersAssignmentId",
                table: "AspNetUsers",
                column: "UsersAssignmentId",
                principalTable: "UsersAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_UsersAssignments_UsersAssignmentId",
                table: "Assignments",
                column: "UsersAssignmentId",
                principalTable: "UsersAssignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersAssignments_UsersAssignmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_UsersAssignments_UsersAssignmentId",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "UsersAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_UsersAssignmentId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UsersAssignmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "UsersAssignmentId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "UsersAssignmentId",
                table: "AspNetUsers");
        }
    }
}
