using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class usereklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_User_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUser_User_UsersId",
                table: "PostUser");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Teams_TeamId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserTypes_UserTypeId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserTypeId",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_TeamId",
                table: "Users",
                newName: "IX_Users_TeamId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 674, DateTimeKind.Local).AddTicks(391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 792, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(7232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 792, DateTimeKind.Local).AddTicks(372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(3806),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 791, DateTimeKind.Local).AddTicks(7198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 791, DateTimeKind.Local).AddTicks(3896));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUser_Users_UsersId",
                table: "PostUser",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostUser_Users_UsersId",
                table: "PostUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Teams_TeamId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "User",
                newName: "IX_User_UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TeamId",
                table: "User",
                newName: "IX_User_TeamId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 792, DateTimeKind.Local).AddTicks(3726),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 674, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 792, DateTimeKind.Local).AddTicks(372),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 791, DateTimeKind.Local).AddTicks(7198),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 2, 21, 14, 24, 791, DateTimeKind.Local).AddTicks(3896),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_User_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostUser_User_UsersId",
                table: "PostUser",
                column: "UsersId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Teams_TeamId",
                table: "User",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserTypes_UserTypeId",
                table: "User",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "Id");
        }
    }
}
