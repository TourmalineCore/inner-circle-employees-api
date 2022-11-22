﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
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

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Instant?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Instant>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PersonalEmail")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Skype")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telegram")
                        .HasColumnType("text");

                    b.Property<string>("WorkEmail")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinanceForPayroll", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<int>("EmploymentType")
                        .HasColumnType("integer");

                    b.Property<bool>("HasParking")
                        .HasColumnType("boolean");

                    b.Property<double>("Pay")
                        .HasColumnType("double precision");

                    b.Property<double>("RatePerHour")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeFinanceForPayroll");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetrics", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("AccountingPerMonth")
                        .HasColumnType("double precision");

                    b.Property<Instant>("ActualFromUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Earnings")
                        .HasColumnType("double precision");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<double>("EmploymentType")
                        .HasColumnType("double precision");

                    b.Property<double>("Expenses")
                        .HasColumnType("double precision");

                    b.Property<double>("GrossSalary")
                        .HasColumnType("double precision");

                    b.Property<bool>("HasParking")
                        .HasColumnType("boolean");

                    b.Property<double>("HourlyCostFact")
                        .HasColumnType("double precision");

                    b.Property<double>("HourlyCostHand")
                        .HasColumnType("double precision");

                    b.Property<double>("IncomeTaxContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("InjuriesContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("MedicalContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("NetSalary")
                        .HasColumnType("double precision");

                    b.Property<double>("ParkingCostPerMonth")
                        .HasColumnType("double precision");

                    b.Property<double>("Pay")
                        .HasColumnType("double precision");

                    b.Property<double>("PensionContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("Profit")
                        .HasColumnType("double precision");

                    b.Property<double>("ProfitAbility")
                        .HasColumnType("double precision");

                    b.Property<double>("RatePerHour")
                        .HasColumnType("double precision");

                    b.Property<double>("Retainer")
                        .HasColumnType("double precision");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<double>("SocialInsuranceContributions")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("EmployeeFinancialMetrics");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetricsHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("AccountingPerMonth")
                        .HasColumnType("double precision");

                    b.Property<double>("Earnings")
                        .HasColumnType("double precision");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<double>("EmploymentType")
                        .HasColumnType("double precision");

                    b.Property<double>("Expenses")
                        .HasColumnType("double precision");

                    b.Property<double>("GrossSalary")
                        .HasColumnType("double precision");

                    b.Property<bool>("HasParking")
                        .HasColumnType("boolean");

                    b.Property<double>("HourlyCostFact")
                        .HasColumnType("double precision");

                    b.Property<double>("HourlyCostHand")
                        .HasColumnType("double precision");

                    b.Property<double>("IncomeTaxContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("InjuriesContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("MedicalContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("NetSalary")
                        .HasColumnType("double precision");

                    b.Property<double>("ParkingCostPerMonth")
                        .HasColumnType("double precision");

                    b.Property<double>("Pay")
                        .HasColumnType("double precision");

                    b.Property<double>("PensionContributions")
                        .HasColumnType("double precision");

                    b.Property<double>("Profit")
                        .HasColumnType("double precision");

                    b.Property<double>("ProfitAbility")
                        .HasColumnType("double precision");

                    b.Property<double>("RatePerHour")
                        .HasColumnType("double precision");

                    b.Property<double>("Retainer")
                        .HasColumnType("double precision");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<double>("SocialInsuranceContributions")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("EmployeeFinancialMetricsHistory");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinanceForPayroll", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetricsHistory", b =>
                {
                    b.OwnsOne("SalaryService.Domain.Common.Period", "Period", b1 =>
                        {
                            b1.Property<long>("EmployeeFinancialMetricsHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<Instant>("FromUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("StartedAtUtc");

                            b1.Property<Instant?>("ToUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("UpdatedAtUtc");

                            b1.HasKey("EmployeeFinancialMetricsHistoryId");

                            b1.ToTable("EmployeeFinancialMetricsHistory");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeFinancialMetricsHistoryId");
                        });

                    b.Navigation("Period")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
