using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class ChangedDateTimetoDateTimeOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("dc0a0283-4a07-4457-8ac7-cb9682299233"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("d859cd86-acde-4185-adf7-c669fe0f0f05"));

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("96fe28ca-89a9-4580-b74a-f4f7c7cfa2bb"), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("a054a2af-dcdf-411e-b2fe-a4346892a5df"), new DateTimeOffset(new DateTime(2022, 9, 7, 11, 10, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 7, 11, 40, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), "Draw a picture.", "{}", new Guid("96fe28ca-89a9-4580-b74a-f4f7c7cfa2bb") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("a054a2af-dcdf-411e-b2fe-a4346892a5df"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("96fe28ca-89a9-4580-b74a-f4f7c7cfa2bb"));

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("d859cd86-acde-4185-adf7-c669fe0f0f05"), 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("dc0a0283-4a07-4457-8ac7-cb9682299233"), new DateTime(2022, 9, 7, 11, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 7, 11, 40, 0, 0, DateTimeKind.Unspecified), "Draw a picture.", "{}", new Guid("d859cd86-acde-4185-adf7-c669fe0f0f05") });
        }
    }
}
