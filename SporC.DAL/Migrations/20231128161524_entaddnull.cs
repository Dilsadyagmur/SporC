using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class entaddnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(454),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 364, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 692, DateTimeKind.Local).AddTicks(1137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 365, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.AlterColumn<string>(
                name: "PostUserName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(8351),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 365, DateTimeKind.Local).AddTicks(3228));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(4838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 365, DateTimeKind.Local).AddTicks(1446));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(2688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 364, DateTimeKind.Local).AddTicks(9682));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 364, DateTimeKind.Local).AddTicks(7641),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(454));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 365, DateTimeKind.Local).AddTicks(5369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 692, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.AlterColumn<string>(
                name: "PostUserName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 365, DateTimeKind.Local).AddTicks(3228),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(8351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 365, DateTimeKind.Local).AddTicks(1446),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(4838));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 28, 19, 12, 12, 364, DateTimeKind.Local).AddTicks(9682),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 11, 28, 19, 15, 24, 691, DateTimeKind.Local).AddTicks(2688));
        }
    }
}
