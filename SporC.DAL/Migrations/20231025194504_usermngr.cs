using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class usermngr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Categories_categoriesId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "PostUser");

            migrationBuilder.DropIndex(
                name: "IX_Teams_categoriesId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "categoriesId",
                table: "Teams");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 695, DateTimeKind.Local).AddTicks(4332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 127, DateTimeKind.Local).AddTicks(3891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 696, DateTimeKind.Local).AddTicks(2095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 128, DateTimeKind.Local).AddTicks(4032));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 696, DateTimeKind.Local).AddTicks(196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 128, DateTimeKind.Local).AddTicks(1515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 695, DateTimeKind.Local).AddTicks(8351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 127, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 695, DateTimeKind.Local).AddTicks(6535),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 127, DateTimeKind.Local).AddTicks(6713));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 127, DateTimeKind.Local).AddTicks(3891),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 695, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 128, DateTimeKind.Local).AddTicks(4032),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 696, DateTimeKind.Local).AddTicks(2095));

            migrationBuilder.AddColumn<int>(
                name: "categoriesId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 128, DateTimeKind.Local).AddTicks(1515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 696, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 127, DateTimeKind.Local).AddTicks(9056),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 695, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 20, 0, 32, 18, 127, DateTimeKind.Local).AddTicks(6713),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 25, 22, 45, 4, 695, DateTimeKind.Local).AddTicks(6535));

            migrationBuilder.CreateTable(
                name: "PostUser",
                columns: table => new
                {
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUser", x => new { x.PostsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_PostUser_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_categoriesId",
                table: "Teams",
                column: "categoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUser_UsersId",
                table: "PostUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Categories_categoriesId",
                table: "Teams",
                column: "categoriesId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
