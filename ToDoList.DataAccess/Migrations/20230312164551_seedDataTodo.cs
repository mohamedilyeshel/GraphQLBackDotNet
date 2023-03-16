using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDataTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "Content", "IsDone", "UserId" },
                values: new object[,]
                {
                    { 1, "lezimni ntayah el sabouna", true, 1 },
                    { 2, "bech nrakah el live chat", false, 1 },
                    { 3, "nwali rajel", false, 2 },
                    { 4, "niklek omk", true, 3 }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthdayDate",
                value: new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8761));
        }
    }
}
