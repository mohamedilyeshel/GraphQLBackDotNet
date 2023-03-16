using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class makeTheEmailFieldUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 17, 45, 51, 269, DateTimeKind.Local).AddTicks(957));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 17, 45, 51, 269, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 17, 45, 51, 269, DateTimeKind.Local).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 17, 45, 51, 269, DateTimeKind.Local).AddTicks(1008));
        }
    }
}
