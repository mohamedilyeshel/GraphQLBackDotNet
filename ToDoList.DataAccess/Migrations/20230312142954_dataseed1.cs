using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dataseed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthdayDate", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8714), "hamdi@gmail.com", "Hamdi", "Bali" },
                    { 2, new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8756), "mahdi@gmail.com", "Mahdi", "Bougriba" },
                    { 3, new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8759), "ilyes@gmail.com", "Ilyes", "Helal" },
                    { 4, new DateTime(2023, 3, 12, 15, 29, 53, 897, DateTimeKind.Local).AddTicks(8761), "rayen@gmail.com", "Rayen", "Zebi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
