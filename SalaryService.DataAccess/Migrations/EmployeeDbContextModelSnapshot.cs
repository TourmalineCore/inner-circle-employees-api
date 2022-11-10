﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalaryService.DataAccess;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalaryService.Domain.BasicSalaryParameters", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<int>("EmploymentType")
                        .HasColumnType("integer");

                    b.Property<double>("EmploymentTypeValue")
                        .HasColumnType("double precision");

                    b.Property<bool>("HasParking")
                        .HasColumnType("boolean");

                    b.Property<double>("Pay")
                        .HasColumnType("double precision");

                    b.Property<double>("RatePerHour")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("BasicSalaryParameters");
                });

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PersonalEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Skype")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telegram")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WorkEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SalaryService.Domain.BasicSalaryParameters", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithOne("Performances")
                        .HasForeignKey("SalaryService.Domain.BasicSalaryParameters", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Navigation("Performances")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
