// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lec5.Data;

#nullable disable

namespace lec5.Migrations
{
    [DbContext(typeof(DataBase))]
    partial class DataBaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Departmentcourses", b =>
                {
                    b.Property<int>("DepartmentsDept_Id")
                        .HasColumnType("int");

                    b.Property<int>("coursessCour_Id")
                        .HasColumnType("int");

                    b.HasKey("DepartmentsDept_Id", "coursessCour_Id");

                    b.HasIndex("coursessCour_Id");

                    b.ToTable("Departmentcourses");
                });

            modelBuilder.Entity("lec5.Models.courses", b =>
                {
                    b.Property<int>("Cour_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cour_Id"), 1L, 1);

                    b.Property<int>("Cour_Hours")
                        .HasColumnType("int");

                    b.Property<string>("Cour_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Cour_Id");

                    b.ToTable("coursess");
                });

            modelBuilder.Entity("lec5.Models.Department", b =>
                {
                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<string>("Dept_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Dept_Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("lec5.Models.role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
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

            modelBuilder.Entity("lec5.Models.StudentCourses", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("coursesId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "coursesId");

                    b.HasIndex("coursesId");

                    b.ToTable("StudentCoursess");
                });

            modelBuilder.Entity("lec5.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Userrole", b =>
                {
                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.Property<int>("rolesId")
                        .HasColumnType("int");

                    b.HasKey("UsersId", "rolesId");

                    b.HasIndex("rolesId");

                    b.ToTable("Userrole");
                });

            modelBuilder.Entity("Departmentcourses", b =>
                {
                    b.HasOne("lec5.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDept_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lec5.Models.courses", null)
                        .WithMany()
                        .HasForeignKey("coursessCour_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("lec5.Models.StudentCourses", b =>
                {
                    b.HasOne("lec5.Models.Student", "student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lec5.Models.courses", "courses")
                        .WithMany("StudentCourses")
                        .HasForeignKey("coursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("courses");

                    b.Navigation("student");
                });

            modelBuilder.Entity("Userrole", b =>
                {
                    b.HasOne("lec5.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lec5.Models.role", null)
                        .WithMany()
                        .HasForeignKey("rolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("lec5.Models.courses", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("lec5.Models.Department", b =>
                {
                    b.Navigation("students");
                });

            modelBuilder.Entity("lec5.Models.Student", b =>
                {
                    b.Navigation("StudentCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
