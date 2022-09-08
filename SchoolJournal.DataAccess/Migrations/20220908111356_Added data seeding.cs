using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Addeddataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Birthday", "FirstName", "LastName", "Login", "Password" },
                values: new object[] { 1, new DateOnly(1983, 11, 18), "Yana", "Yanovna", "yanito", "lll" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassTeacherId", "Number" },
                values: new object[] { 1, 1, 11 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthday", "ClassId", "FirstName", "LastName", "Login", "Password" },
                values: new object[,]
                {
                    { 1, new DateOnly(2005, 7, 9), 1, "Mikhail", "Mikhaylov", "mikhail", "1111" },
                    { 2, new DateOnly(2006, 1, 2), 1, "Vasiliy", "Vasiliev", "vasya2006", "13863" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
