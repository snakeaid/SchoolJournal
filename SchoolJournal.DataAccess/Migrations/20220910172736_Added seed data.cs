using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Addedseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Art" });

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("d859cd86-acde-4185-adf7-c669fe0f0f05"), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("dc0a0283-4a07-4457-8ac7-cb9682299233"), new DateTime(2022, 9, 7, 11, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 11, 40, 0, 0, DateTimeKind.Unspecified), "Draw a picture.", "{}", new Guid("d859cd86-acde-4185-adf7-c669fe0f0f05") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("dc0a0283-4a07-4457-8ac7-cb9682299233"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("d859cd86-acde-4185-adf7-c669fe0f0f05"));

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
