using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class isdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(6558),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 276, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(4395),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(2368),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(436),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(5443));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 276, DateTimeKind.Local).AddTicks(1301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(9309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(4395));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(7347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(2368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(5443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 5, 18, 54, 2, 706, DateTimeKind.Local).AddTicks(436));
        }
    }
}
