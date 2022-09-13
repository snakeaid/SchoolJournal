﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SchoolJournal.DataAccess;

#nullable disable

namespace SchoolJournal.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220912123747_Removed login and password")]
    partial class Removedloginandpassword
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassTeacherId")
                        .HasColumnType("integer");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassTeacherId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassTeacherId = 1,
                            Number = 11
                        });
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<OffsetDateTime>("BeginDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<OffsetDateTime>("EndDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HomeTask")
                        .HasColumnType("text");

                    b.Property<string>("Marks")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SubjectJournalId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SubjectJournalId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = new Guid("25101af5-d0b3-4992-b8da-dfcdaa170feb"),
                            BeginDateTime = new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 10), NodaTime.Offset.FromHours(0)),
                            EndDateTime = new NodaTime.OffsetDateTime(new NodaTime.LocalDateTime(2022, 9, 7, 11, 40), NodaTime.Offset.FromHours(0)),
                            HomeTask = "Draw a picture.",
                            Marks = "{}",
                            SubjectJournalId = new Guid("9e45ff36-7191-419e-896e-cdcdf2500683")
                        });
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<LocalDate>("Birthday")
                        .HasColumnType("date");

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<string[]>("Names")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new NodaTime.LocalDate(2005, 7, 9),
                            ClassId = 1,
                            Names = new[] { "Mikhail", "Mikhaylov" }
                        },
                        new
                        {
                            Id = 2,
                            Birthday = new NodaTime.LocalDate(2006, 1, 2),
                            ClassId = 1,
                            Names = new[] { "Vasiliy", "Vasiliev" }
                        });
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Art"
                        });
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.SubjectJournal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectJournal");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9e45ff36-7191-419e-896e-cdcdf2500683"),
                            ClassId = 1,
                            SubjectId = 1,
                            TeacherId = 1
                        });
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<LocalDate>("Birthday")
                        .HasColumnType("date");

                    b.Property<string[]>("Names")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthday = new NodaTime.LocalDate(1983, 11, 18),
                            Names = new[] { "Yana", "Yanovna" }
                        });
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Class", b =>
                {
                    b.HasOne("SchoolJournal.DataAccess.Primitives.Teacher", "ClassTeacher")
                        .WithMany()
                        .HasForeignKey("ClassTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassTeacher");
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Lesson", b =>
                {
                    b.HasOne("SchoolJournal.DataAccess.Primitives.SubjectJournal", "SubjectJournal")
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectJournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectJournal");
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Student", b =>
                {
                    b.HasOne("SchoolJournal.DataAccess.Primitives.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.SubjectJournal", b =>
                {
                    b.HasOne("SchoolJournal.DataAccess.Primitives.Class", "Class")
                        .WithMany("Journal")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolJournal.DataAccess.Primitives.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolJournal.DataAccess.Primitives.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.Class", b =>
                {
                    b.Navigation("Journal");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolJournal.DataAccess.Primitives.SubjectJournal", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
