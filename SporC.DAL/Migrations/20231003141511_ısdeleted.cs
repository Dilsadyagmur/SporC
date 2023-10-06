using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporC.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ısdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 276, DateTimeKind.Local).AddTicks(1301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(8967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(9309),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(7347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(5443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(2703));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Teams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(8967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 276, DateTimeKind.Local).AddTicks(1301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(6915),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(5047),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(7347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 3, 3, 16, 22, 78, DateTimeKind.Local).AddTicks(2703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 10, 3, 17, 15, 11, 275, DateTimeKind.Local).AddTicks(5443));
        }
    }
}
