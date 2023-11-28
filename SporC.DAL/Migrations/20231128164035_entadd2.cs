using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class entadd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 74, DateTimeKind.Local).AddTicks(3799),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 75, DateTimeKind.Local).AddTicks(3656),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 692, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 75, DateTimeKind.Local).AddTicks(352),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 74, DateTimeKind.Local).AddTicks(8053),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.AddColumn<string>(
                name: "CommentUser",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 74, DateTimeKind.Local).AddTicks(6154),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(2688));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentUser",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 74, DateTimeKind.Local).AddTicks(3799));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 692, DateTimeKind.Local).AddTicks(1137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 75, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(8351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 75, DateTimeKind.Local).AddTicks(352));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(4838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 74, DateTimeKind.Local).AddTicks(8053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(2688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 40, 35, 74, DateTimeKind.Local).AddTicks(6154));
        }
    }
}
