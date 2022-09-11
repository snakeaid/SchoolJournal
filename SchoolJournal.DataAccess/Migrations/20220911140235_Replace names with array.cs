using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Replacenameswitharray : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e160f9d0-397f-426b-98a1-a6a3956210fb"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("5611343c-eec7-4097-a976-60dedf419bf4"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Students");

            migrationBuilder.AddColumn<string[]>(
                name: "Names",
                table: "Teachers",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string[]>(
                name: "Names",
                table: "Students",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "Names",
                value: new[] { "Mikhail", "Mikhaylov" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "Names",
                value: new[] { "Vasiliy", "Vasiliev" });

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("27c2daf4-d344-43a0-ab95-096a969134c0"), 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Names",
                value: new[] { "Yana", "Yanovna" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("ab271173-b4d4-4fbc-b76b-416842e7f29e"), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)), "Draw a picture.", "{}", new Guid("27c2daf4-d344-43a0-ab95-096a969134c0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("ab271173-b4d4-4fbc-b76b-416842e7f29e"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("27c2daf4-d344-43a0-ab95-096a969134c0"));

            migrationBuilder.DropColumn(
                name: "Names",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Names",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Mikhail", "Mikhaylov" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Vasiliy", "Vasiliev" });

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("5611343c-eec7-4097-a976-60dedf419bf4"), 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Yana", "Yanovna" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("e160f9d0-397f-426b-98a1-a6a3956210fb"), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)), "Draw a picture.", "{}", new Guid("5611343c-eec7-4097-a976-60dedf419bf4") });
        }
    }
}
