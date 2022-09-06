using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Addedjournal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classes",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "Subjects",
                table: "Classes",
                newName: "Journal");

            migrationBuilder.CreateTable(
                name: "SubjectJournal",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubjectId = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    Lessons = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectJournal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectJournal_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectJournal_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectJournal_Teachers_TeacherId",
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
                    BeginDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HomeTask = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_SubjectJournal_SubjectJournalId",
                        column: x => x.SubjectJournalId,
                        principalTable: "SubjectJournal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SubjectJournalId",
                table: "Lessons",
                column: "SubjectJournalId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectJournal_ClassId",
                table: "SubjectJournal",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectJournal_SubjectId",
                table: "SubjectJournal",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectJournal_TeacherId",
                table: "SubjectJournal",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "SubjectJournal");

            migrationBuilder.RenameColumn(
                name: "Journal",
                table: "Classes",
                newName: "Subjects");

            migrationBuilder.AddColumn<string>(
                name: "Classes",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
