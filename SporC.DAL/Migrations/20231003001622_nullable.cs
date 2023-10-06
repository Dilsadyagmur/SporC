using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(8967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 674, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(6915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(7232));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(5047),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(3806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(868));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 674, DateTimeKind.Local).AddTicks(391),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(8967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(7232),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(3806),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 2, 59, 48, 673, DateTimeKind.Local).AddTicks(868),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(2703));
        }
    }
}
