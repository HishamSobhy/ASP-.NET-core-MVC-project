﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lec5.Data;

#nullable disable

namespace lec5.Migrations
{
    [DbContext(typeof(DataBase))]
    [Migration("20221008124842_dep_fk")]
    partial class dep_fk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("lec5.Models.courses", b =>
                {
                    b.Property<int>("Cour_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cour_Id"), 1L, 1);

                    b.Property<string>("Cour_Hours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cour_name")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Cour_Id");

                    b.ToTable("coursess");
                });

            modelBuilder.Entity("lec5.Models.Department", b =>
                {
                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Dept_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Dept_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("lec5.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("Dept_Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("lec5.Models.Student", b =>
                {
                    b.HasOne("lec5.Models.Department", "Department")
                        .WithMany("students")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("lec5.Models.Department", b =>
                {
                    b.Navigation("students");
                });
#pragma warning restore 612, 618
        }
    }
}
