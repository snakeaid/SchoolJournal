using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Addedfirstandlastnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d13912bb-83fa-4eca-8034-3f688df04cba"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("1f59d881-85b4-4f1d-bb2e-c37c9c8e9497"));

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
                columns: new[] { "Id", "ClassId", "DateTimeDeleted", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("584ecaee-908c-4bce-9d92-28579c51b667"), 1, null, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Yana", "Yanovna" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "DateTimeDeleted", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("04d4e13c-73f7-41fc-a693-c490ffd6bf04"), new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), null, new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), "Draw a picture.", "{}", new Guid("584ecaee-908c-4bce-9d92-28579c51b667") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("04d4e13c-73f7-41fc-a693-c490ffd6bf04"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("584ecaee-908c-4bce-9d92-28579c51b667"));

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
                columns: new[] { "Id", "ClassId", "DateTimeDeleted", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("1f59d881-85b4-4f1d-bb2e-c37c9c8e9497"), 1, null, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Names",
                value: new[] { "Yana", "Yanovna" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "DateTimeDeleted", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("d13912bb-83fa-4eca-8034-3f688df04cba"), new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), null, new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), "Draw a picture.", "{}", new Guid("1f59d881-85b4-4f1d-bb2e-c37c9c8e9497") });
        }
    }
}
