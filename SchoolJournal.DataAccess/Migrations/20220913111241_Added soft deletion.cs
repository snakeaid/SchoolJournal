using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Addedsoftdeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("25101af5-d0b3-4992-b8da-dfcdaa170feb"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("9e45ff36-7191-419e-896e-cdcdf2500683"));

            migrationBuilder.AddColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Teachers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Subjects",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "SubjectJournal",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Classes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "DateTimeDeleted", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("583b2835-3d9e-4941-bcea-3a082f9a6aaf"), 1, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "DateTimeDeleted", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("69b0947b-d1ae-4fef-bcd9-6e32f1c9cfdf"), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)), null, new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)), "Draw a picture.", "{}", new Guid("583b2835-3d9e-4941-bcea-3a082f9a6aaf") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("69b0947b-d1ae-4fef-bcd9-6e32f1c9cfdf"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("583b2835-3d9e-4941-bcea-3a082f9a6aaf"));

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "SubjectJournal");

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "DateTimeDeleted",
                table: "Classes");

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("9e45ff36-7191-419e-896e-cdcdf2500683"), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("25101af5-d0b3-4992-b8da-dfcdaa170feb"), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)), "Draw a picture.", "{}", new Guid("9e45ff36-7191-419e-896e-cdcdf2500683") });
        }
    }
}
