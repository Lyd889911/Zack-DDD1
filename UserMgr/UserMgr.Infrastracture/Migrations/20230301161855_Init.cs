using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserMgr.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_login_history",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Phone_RegionNumber = table.Column<int>(type: "int", nullable: false),
                    Phone_PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_login_history", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Phone_RegionNumber = table.Column<int>(type: "int", nullable: false),
                    Phone_PhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    passwordHash = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_access_fails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LockEnd = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AccessFailCount = table.Column<int>(type: "int", nullable: false),
                    isLockOut = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_access_fails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_access_fails_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_user_access_fails_UserId",
                table: "user_access_fails",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_access_fails");

            migrationBuilder.DropTable(
                name: "user_login_history");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
