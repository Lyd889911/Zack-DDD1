using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserMgr.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class t2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_access_fails_users_UserId",
                table: "user_access_fails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_access_fails",
                table: "user_access_fails");

            migrationBuilder.RenameTable(
                name: "user_access_fails",
                newName: "UserAccessFail");

            migrationBuilder.RenameIndex(
                name: "IX_user_access_fails_UserId",
                table: "UserAccessFail",
                newName: "IX_UserAccessFail_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAccessFail",
                table: "UserAccessFail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccessFail_users_UserId",
                table: "UserAccessFail",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccessFail_users_UserId",
                table: "UserAccessFail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAccessFail",
                table: "UserAccessFail");

            migrationBuilder.RenameTable(
                name: "UserAccessFail",
                newName: "user_access_fails");

            migrationBuilder.RenameIndex(
                name: "IX_UserAccessFail_UserId",
                table: "user_access_fails",
                newName: "IX_user_access_fails_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_access_fails",
                table: "user_access_fails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_access_fails_users_UserId",
                table: "user_access_fails",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
