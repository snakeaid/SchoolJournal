using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Removedconversions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lessons",
                table: "SubjectJournal");

            migrationBuilder.DropColumn(
                name: "Journal",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Students",
                table: "Classes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Lessons",
                table: "SubjectJournal",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Journal",
                table: "Classes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Students",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
