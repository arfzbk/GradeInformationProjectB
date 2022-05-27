﻿// <auto-generated />
using System;
using GradeInformation.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GradeInformation.DataAccess.Migrations
{
    [DbContext(typeof(GradeInformationContext))]
    [Migration("20220416124424_initialcreate")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompanyField", b =>
                {
                    b.Property<int>("CompaniesCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("FieldsFieldId")
                        .HasColumnType("int");

                    b.HasKey("CompaniesCompanyId", "FieldsFieldId");

                    b.HasIndex("FieldsFieldId");

                    b.ToTable("CompanyField");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CityId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyCapacity")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CompanyId");

                    b.HasIndex("CityId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Degree", b =>
                {
                    b.Property<int>("DegreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DegreeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FacultyId")
                        .HasColumnType("int");

                    b.HasKey("DegreeId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FacultyName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FieldName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FieldId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SectorName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SectorId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.SectorCompany", b =>
                {
                    b.Property<int>("SectorCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.HasKey("SectorCompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SectorId");

                    b.ToTable("SectorCompanies");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfGrade")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DegreeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Gpa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NewSurname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("SurName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tc")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("StudentId");

                    b.HasIndex("CityId");

                    b.HasIndex("DegreeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.StudentCompany", b =>
                {
                    b.Property<int>("StudentCompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("FieldId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentCompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FieldId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCompanies");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.StudentCompanyTool", b =>
                {
                    b.Property<int>("StudentCompanyToolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StudentCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("StudentCompanyToolId");

                    b.HasIndex("StudentCompanyId");

                    b.HasIndex("ToolId");

                    b.ToTable("StudentCompanyTools");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Tool", b =>
                {
                    b.Property<int>("ToolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ToolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ToolId");

                    b.ToTable("Tools");
                });

            modelBuilder.Entity("CompanyField", b =>
                {
                    b.HasOne("GradeInformation.Entities.Concrete.Company", null)
                        .WithMany()
                        .HasForeignKey("CompaniesCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradeInformation.Entities.Concrete.Field", null)
                        .WithMany()
                        .HasForeignKey("FieldsFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Company", b =>
                {
                    b.HasOne("GradeInformation.Entities.Concrete.City", "City")
                        .WithMany("Companies")
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Degree", b =>
                {
                    b.HasOne("GradeInformation.Entities.Concrete.Faculty", "Faculty")
                        .WithMany("Degrees")
                        .HasForeignKey("FacultyId");

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.SectorCompany", b =>
                {
                    b.HasOne("GradeInformation.Entities.Concrete.Company", "Company")
                        .WithMany("SectorCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradeInformation.Entities.Concrete.Sector", "Sector")
                        .WithMany("SectorCompanies")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Student", b =>
                {
                    b.HasOne("GradeInformation.Entities.Concrete.City", "City")
                        .WithMany("Students")
                        .HasForeignKey("CityId");

                    b.HasOne("GradeInformation.Entities.Concrete.Degree", "Degree")
                        .WithMany()
                        .HasForeignKey("DegreeId");

                    b.Navigation("City");

                    b.Navigation("Degree");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.StudentCompany", b =>
                {
                    b.HasOne("GradeInformation.Entities.Concrete.Company", "Company")
                        .WithMany("StudentCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradeInformation.Entities.Concrete.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId");

                    b.HasOne("GradeInformation.Entities.Concrete.Student", "Student")
                        .WithMany("StudentCompanies")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Field");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.StudentCompanyTool", b =>
                {
                    b.HasOne("GradeInformation.Entities.Concrete.StudentCompany", "StudentCompany")
                        .WithMany()
                        .HasForeignKey("StudentCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GradeInformation.Entities.Concrete.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentCompany");

                    b.Navigation("Tool");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.City", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Company", b =>
                {
                    b.Navigation("SectorCompanies");

                    b.Navigation("StudentCompanies");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Faculty", b =>
                {
                    b.Navigation("Degrees");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Sector", b =>
                {
                    b.Navigation("SectorCompanies");
                });

            modelBuilder.Entity("GradeInformation.Entities.Concrete.Student", b =>
                {
                    b.Navigation("StudentCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
