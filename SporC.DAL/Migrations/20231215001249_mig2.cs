using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 352, DateTimeKind.Local).AddTicks(4866),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 853, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 353, DateTimeKind.Local).AddTicks(3833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 854, DateTimeKind.Local).AddTicks(3127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 353, DateTimeKind.Local).AddTicks(1619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 854, DateTimeKind.Local).AddTicks(1200));

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
                defaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 352, DateTimeKind.Local).AddTicks(9364),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 853, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 352, DateTimeKind.Local).AddTicks(7330),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 853, DateTimeKind.Local).AddTicks(7784));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 853, DateTimeKind.Local).AddTicks(5942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 352, DateTimeKind.Local).AddTicks(4866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 854, DateTimeKind.Local).AddTicks(3127),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 353, DateTimeKind.Local).AddTicks(3833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 854, DateTimeKind.Local).AddTicks(1200),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 353, DateTimeKind.Local).AddTicks(1619));

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
                defaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 853, DateTimeKind.Local).AddTicks(9500),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 352, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 15, 1, 6, 55, 853, DateTimeKind.Local).AddTicks(7784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 15, 3, 12, 49, 352, DateTimeKind.Local).AddTicks(7330));

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
    }
}
