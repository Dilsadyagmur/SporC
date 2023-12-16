using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Posts_PostId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_PostId",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Pictures");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(995),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(7851),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(9840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(6105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(4459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(2855),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(4078));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PictureId",
                table: "Posts",
                column: "PictureId",
                unique: true,
                filter: "[PictureId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Pictures_PictureId",
                table: "Posts",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Pictures_PictureId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PictureId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(2104),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(995));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(9840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(7851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(7841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(6105));

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(5869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 14, 16, 365, DateTimeKind.Local).AddTicks(4078),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 27, 5, 453, DateTimeKind.Local).AddTicks(2855));

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PostId",
                table: "Pictures",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Posts_PostId",
                table: "Pictures",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
