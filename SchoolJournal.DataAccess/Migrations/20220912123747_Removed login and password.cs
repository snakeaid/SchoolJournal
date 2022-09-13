using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Removedloginandpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Login",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Students");

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("9e45ff36-7191-419e-896e-cdcdf2500683"), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("25101af5-d0b3-4992-b8da-dfcdaa170feb"), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)), "Draw a picture.", "{}", new Guid("9e45ff36-7191-419e-896e-cdcdf2500683") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("25101af5-d0b3-4992-b8da-dfcdaa170feb"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("9e45ff36-7191-419e-896e-cdcdf2500683"));

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "mikhail", "1111" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password" },
                values: new object[] { "vasya2006", "13863" });

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("27c2daf4-d344-43a0-ab95-096a969134c0"), 1, 1, 1 });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "yanito", "lll" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("ab271173-b4d4-4fbc-b76b-416842e7f29e"), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)), "Draw a picture.", "{}", new Guid("27c2daf4-d344-43a0-ab95-096a969134c0") });
        }
    }
}
