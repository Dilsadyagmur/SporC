using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(1018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 511, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(8400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(6554),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(4796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(3053),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(900));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 511, DateTimeKind.Local).AddTicks(8796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(1018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(6781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(8400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(4525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(6554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 26, 19, 0, 54, 951, DateTimeKind.Local).AddTicks(3053));
        }
    }
}
