using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Addedforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Journal",
                table: "Classes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Birthday", "FirstName", "LastName", "Login", "Password" },
                values: new object[] { 1, new DateOnly(1983, 11, 18), "Yana", "Yanovna", "yanito", "lll" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassTeacherId", "Journal", "Number", "Students" },
                values: new object[] { 1, 1, null, 11, "[{\"Id\":1,\"Class\":null,\"ClassId\":1,\"FirstName\":\"Mikhail\",\"LastName\":\"Mikhaylov\",\"Birthday\":{\"Year\":2005,\"Month\":7,\"Day\":9,\"DayOfWeek\":6,\"DayOfYear\":190,\"DayNumber\":732135},\"Login\":\"mikhail\",\"Password\":\"1111\"},{\"Id\":2,\"Class\":null,\"ClassId\":1,\"FirstName\":\"Vasiliy\",\"LastName\":\"Vasiliev\",\"Birthday\":{\"Year\":2006,\"Month\":1,\"Day\":2,\"DayOfWeek\":1,\"DayOfYear\":2,\"DayNumber\":732312},\"Login\":\"vasya2006\",\"Password\":\"13863\"}]" });

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

            migrationBuilder.AlterColumn<string>(
                name: "Journal",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
