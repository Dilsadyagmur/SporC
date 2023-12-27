using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 511, DateTimeKind.Local).AddTicks(8796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 717, DateTimeKind.Local).AddTicks(9980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(6781),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(7575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(4525),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(5655));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(3876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(900),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(2110));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 717, DateTimeKind.Local).AddTicks(9980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 511, DateTimeKind.Local).AddTicks(8796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(7575),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(6781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(5655),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(3876),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 16, 17, 0, 15, 718, DateTimeKind.Local).AddTicks(2110),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 16, 17, 58, 41, 512, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Categories",
                type: "int",
                nullable: true);
        }
    }
}
