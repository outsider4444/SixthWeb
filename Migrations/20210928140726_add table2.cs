using Microsoft.EntityFrameworkCore.Migrations;

namespace SixthWeb.Migrations
{
    public partial class addtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UsersAssignments_UsersAssignmentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_UsersAssignments_UsersAssignmentId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_UsersAssignmentId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UsersAssignmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UsersAssignmentId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "UsersAssignmentId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersAssignments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AssignmentUsersAssignment",
                columns: table => new
                {
                    AssignmentsId = table.Column<int>(type: "int", nullable: false),
                    UsersAssignmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentUsersAssignment", x => new { x.AssignmentsId, x.UsersAssignmentsId });
                    table.ForeignKey(
                        name: "FK_AssignmentUsersAssignment_Assignments_AssignmentsId",
                        column: x => x.AssignmentsId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentUsersAssignment_UsersAssignments_UsersAssignmentsId",
                        column: x => x.UsersAssignmentsId,
                        principalTable: "UsersAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserUsersAssignment",
                columns: table => new
                {
                    UsersAssignmentsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUsersAssignment", x => new { x.UsersAssignmentsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserUsersAssignment_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUsersAssignment_UsersAssignments_UsersAssignmentsId",
                        column: x => x.UsersAssignmentsId,
                        principalTable: "UsersAssignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentUsersAssignment_UsersAssignmentsId",
                table: "AssignmentUsersAssignment",
                column: "UsersAssignmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUsersAssignment_UsersId",
                table: "UserUsersAssignment",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentUsersAssignment");

            migrationBuilder.DropTable(
                name: "UserUsersAssignment");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersAssignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
