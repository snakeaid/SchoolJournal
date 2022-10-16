using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DateTimeDeleted = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateTimeDeleted = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<LocalDate>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Letter = table.Column<string>(type: "text", nullable: false),
                    ClassTeacherId = table.Column<int>(type: "integer", nullable: false),
                    DateTimeDeleted = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_ClassTeacherId",
                        column: x => x.ClassTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    DateTimeDeleted = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<LocalDate>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectJournals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    DateTimeDeleted = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectJournals_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectJournals_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectJournals_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectJournalId = table.Column<Guid>(type: "uuid", nullable: false),
                    Marks = table.Column<string>(type: "text", nullable: false),
                    BeginDateTime = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: false),
                    EndDateTime = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: false),
                    HomeTask = table.Column<string>(type: "text", nullable: true),
                    DateTimeDeleted = table.Column<LocalDateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_SubjectJournals_SubjectJournalId",
                        column: x => x.SubjectJournalId,
                        principalTable: "SubjectJournals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "DateTimeDeleted", "Name" },
                values: new object[] { 1, null, "Art" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Birthday", "DateTimeDeleted", "FirstName", "LastName" },
                values: new object[] { 1, new NodaTime.LocalDate(1983, 11, 18), null, "Yana", "Yanovna" });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "ClassTeacherId", "DateTimeDeleted", "Letter", "Number" },
                values: new object[] { 1, 1, null, "A", 11 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthday", "ClassId", "DateTimeDeleted", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new NodaTime.LocalDate(2005, 7, 9), 1, null, "Mikhail", "Mikhaylov" },
                    { 2, new NodaTime.LocalDate(2006, 1, 2), 1, null, "Vasiliy", "Vasiliev" }
                });

            migrationBuilder.InsertData(
                table: "SubjectJournals",
                columns: new[] { "Id", "ClassId", "DateTimeDeleted", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("eb2426c2-e67b-4688-8e82-12d089395f27"), 1, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "DateTimeDeleted", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("dc42e0d8-c434-48a5-8975-459afde23cf2"), new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), null, new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), "Draw a picture.", "{}", new Guid("eb2426c2-e67b-4688-8e82-12d089395f27") });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_ClassTeacherId",
                table: "Classes",
                column: "ClassTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SubjectJournalId",
                table: "Lessons",
                column: "SubjectJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectJournals_ClassId",
                table: "SubjectJournals",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectJournals_SubjectId",
                table: "SubjectJournals",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectJournals_TeacherId",
                table: "SubjectJournals",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectJournals");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
