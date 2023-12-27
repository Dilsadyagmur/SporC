using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(1451),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 685, DateTimeKind.Local).AddTicks(1824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(9254),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(6819),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(4412),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(3053));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(1018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(8400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 685, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(6554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(9254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(4796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(3053),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 23, 13, 27, 684, DateTimeKind.Local).AddTicks(4412));
        }
    }
}
