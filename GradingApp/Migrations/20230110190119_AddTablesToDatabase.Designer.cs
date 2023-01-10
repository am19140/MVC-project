﻿// <auto-generated />
using GradingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GradingApp.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20230110190119_AddTablesToDatabase")]
    partial class AddTablesToDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GradingApp.Models.Course", b =>
                {
                    b.Property<int>("idCourse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idCourse"));

                    b.Property<int>("afm")
                        .HasColumnType("int");

                    b.Property<int>("courseSemester")
                        .HasColumnType("int");

                    b.Property<string>("courseTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCourse");

                    b.HasIndex("afm");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("GradingApp.Models.CourseHasStudents", b =>
                {
                    b.Property<int>("idCourse")
                        .HasColumnType("int");

                    b.Property<int>("registrationNumber")
                        .HasColumnType("int");

                    b.Property<int>("grade")
                        .HasColumnType("int");

                    b.HasKey("idCourse", "registrationNumber");

                    b.HasIndex("registrationNumber");

                    b.ToTable("CourseHasStudents");
                });

            modelBuilder.Entity("GradingApp.Models.Professors", b =>
                {
                    b.Property<int>("afm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("afm"));

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("afm");

                    b.HasIndex("username");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("GradingApp.Models.Secretaries", b =>
                {
                    b.Property<int>("phoneNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("phoneNumber"));

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("phoneNumber");

                    b.HasIndex("username");

                    b.ToTable("Secretaries");
                });

            modelBuilder.Entity("GradingApp.Models.Students", b =>
                {
                    b.Property<int>("registressionNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("registressionNumber"));

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("registressionNumber");

                    b.HasIndex("username");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GradingApp.Models.Users", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GradingApp.Models.Course", b =>
                {
                    b.HasOne("GradingApp.Models.Professors", "Professors")
                        .WithMany()
                        .HasForeignKey("afm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professors");
                });

            modelBuilder.Entity("GradingApp.Models.CourseHasStudents", b =>
                {
                    b.HasOne("GradingApp.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("idCourse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradingApp.Models.Students", "Students")
                        .WithMany()
                        .HasForeignKey("registrationNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("GradingApp.Models.Professors", b =>
                {
                    b.HasOne("GradingApp.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("GradingApp.Models.Secretaries", b =>
                {
                    b.HasOne("GradingApp.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("GradingApp.Models.Students", b =>
                {
                    b.HasOne("GradingApp.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("username")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
