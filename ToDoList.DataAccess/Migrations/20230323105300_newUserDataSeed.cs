using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newUserDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthdayDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthdayDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 23, 11, 53, 0, 173, DateTimeKind.Local).AddTicks(2352), "123456" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthdayDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 23, 11, 53, 0, 173, DateTimeKind.Local).AddTicks(2369), "123456" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthdayDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 23, 11, 53, 0, 173, DateTimeKind.Local).AddTicks(2371), "123456" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthdayDate", "Password" },
                values: new object[] { new DateTime(2023, 3, 23, 11, 53, 0, 173, DateTimeKind.Local).AddTicks(2373), "123456" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthdayDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1585));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 15, 9, 40, 54, 446, DateTimeKind.Local).AddTicks(1602));
        }
    }
}
