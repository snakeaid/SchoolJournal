﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    public partial class Removeoffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("69b0947b-d1ae-4fef-bcd9-6e32f1c9cfdf"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("583b2835-3d9e-4941-bcea-3a082f9a6aaf"));

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "DateTimeDeleted",
                table: "Teachers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "DateTimeDeleted",
                table: "Subjects",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "DateTimeDeleted",
                table: "SubjectJournal",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "DateTimeDeleted",
                table: "Students",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "EndDateTime",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "DateTimeDeleted",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "BeginDateTime",
                table: "Lessons",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<LocalDateTime>(
                name: "DateTimeDeleted",
                table: "Classes",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(OffsetDateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "DateTimeDeleted", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("1f59d881-85b4-4f1d-bb2e-c37c9c8e9497"), 1, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "DateTimeDeleted", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("d13912bb-83fa-4eca-8034-3f688df04cba"), new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), null, new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), "Draw a picture.", "{}", new Guid("1f59d881-85b4-4f1d-bb2e-c37c9c8e9497") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("d13912bb-83fa-4eca-8034-3f688df04cba"));

            migrationBuilder.DeleteData(
                table: "SubjectJournal",
                keyColumn: "Id",
                keyValue: new Guid("1f59d881-85b4-4f1d-bb2e-c37c9c8e9497"));

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Teachers",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Subjects",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "SubjectJournal",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Students",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "EndDateTime",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "BeginDateTime",
                table: "Lessons",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<OffsetDateTime>(
                name: "DateTimeDeleted",
                table: "Classes",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(LocalDateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SubjectJournal",
                columns: new[] { "Id", "ClassId", "DateTimeDeleted", "SubjectId", "TeacherId" },
                values: new object[] { new Guid("583b2835-3d9e-4941-bcea-3a082f9a6aaf"), 1, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "BeginDateTime", "DateTimeDeleted", "EndDateTime", "HomeTask", "Marks", "SubjectJournalId" },
                values: new object[] { new Guid("69b0947b-d1ae-4fef-bcd9-6e32f1c9cfdf"), new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)), null, new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)), "Draw a picture.", "{}", new Guid("583b2835-3d9e-4941-bcea-3a082f9a6aaf") });
        }
    }
}
