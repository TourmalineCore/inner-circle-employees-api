﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SalaryService.DataAccess;

#nullable disable

namespace SalaryService.DataAccess.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20221205174728_AddDisctrictCoefficient")]
    partial class AddDisctrictCoefficient
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SalaryService.Domain.CoefficientOptions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("DistrictCoefficient")
                        .HasColumnType("double precision");

                    b.Property<double>("IncomeTaxPercent")
                        .HasColumnType("double precision");

                    b.Property<double>("MinimumWage")
                        .HasColumnType("double precision");

                    b.Property<double>("OfficeExpenses")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("CoefficientOptions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DistrictCoefficient = 0.14999999999999999,
                            IncomeTaxPercent = 0.13,
                            MinimumWage = 15279.0,
                            OfficeExpenses = 49000.0
                        });
                });

            modelBuilder.Entity("SalaryService.Domain.DesiredFinancesAndReserve", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("DesiredIncome")
                        .HasColumnType("double precision");

                    b.Property<double>("DesiredProfit")
                        .HasColumnType("double precision");

                    b.Property<double>("DesiredProfitability")
                        .HasColumnType("double precision");

                    b.Property<double>("ReserveForHalfYear")
                        .HasColumnType("double precision");

                    b.Property<double>("ReserveForQuarter")
                        .HasColumnType("double precision");

                    b.Property<double>("ReserveForYear")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("DesiredFinancesAndReserve");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DesiredIncome = 0.0,
                            DesiredProfit = 0.0,
                            DesiredProfitability = 0.0,
                            ReserveForHalfYear = 0.0,
                            ReserveForQuarter = 0.0,
                            ReserveForYear = 0.0
                        });
                });

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("CorporateEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Instant?>("DeletedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("GitHub")
                        .HasColumnType("text");

                    b.Property<string>("GitLab")
                        .HasColumnType("text");

                    b.Property<Instant>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PersonalEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CorporateEmail")
                        .IsUnique();

                    b.HasIndex("GitHub")
                        .IsUnique();

                    b.HasIndex("GitLab")
                        .IsUnique();

                    b.HasIndex("PersonalEmail")
                        .IsUnique();

                    b.HasIndex("Phone")
                        .IsUnique();

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

                    b.Property<double>("ParkingCostPerMonth")
                        .HasColumnType("double precision");

                    b.Property<double>("Pay")
                        .HasColumnType("double precision");

                    b.Property<double>("RatePerHour")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

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

                    b.Property<double>("DistrictCoefficient")
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

                    b.Property<double>("Prepayment")
                        .HasColumnType("double precision");

                    b.Property<double>("Profit")
                        .HasColumnType("double precision");

                    b.Property<double>("ProfitAbility")
                        .HasColumnType("double precision");

                    b.Property<double>("RatePerHour")
                        .HasColumnType("double precision");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<double>("SocialInsuranceContributions")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

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

                    b.Property<double>("Prepayment")
                        .HasColumnType("double precision");

                    b.Property<double>("Profit")
                        .HasColumnType("double precision");

                    b.Property<double>("ProfitAbility")
                        .HasColumnType("double precision");

                    b.Property<double>("RatePerHour")
                        .HasColumnType("double precision");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.Property<double>("SocialInsuranceContributions")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeFinancialMetricsHistory");
                });

            modelBuilder.Entity("SalaryService.Domain.TotalFinancesHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("PayrollExpense")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalExpense")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("TotalFinancesHistory");
                });

            modelBuilder.Entity("TotalFinances", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Instant>("ActualFromUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("PayrollExpense")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalExpense")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("TotalFinances");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ActualFromUtc = NodaTime.Instant.FromUnixTimeTicks(0L),
                            PayrollExpense = 0.0,
                            TotalExpense = 0.0
                        });
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinanceForPayroll", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithOne("EmployeeFinanceForPayroll")
                        .HasForeignKey("SalaryService.Domain.EmployeeFinanceForPayroll", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetrics", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithOne("EmployeeFinancialMetrics")
                        .HasForeignKey("SalaryService.Domain.EmployeeFinancialMetrics", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SalaryService.Domain.EmployeeFinancialMetricsHistory", b =>
                {
                    b.HasOne("SalaryService.Domain.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SalaryService.Domain.Common.Period", "Period", b1 =>
                        {
                            b1.Property<long>("EmployeeFinancialMetricsHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<Instant>("FromUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("FromUtc");

                            b1.Property<Instant?>("ToUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("ToUtc");

                            b1.HasKey("EmployeeFinancialMetricsHistoryId");

                            b1.ToTable("EmployeeFinancialMetricsHistory");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeFinancialMetricsHistoryId");
                        });

                    b.Navigation("Employee");

                    b.Navigation("Period")
                        .IsRequired();
                });

            modelBuilder.Entity("SalaryService.Domain.TotalFinancesHistory", b =>
                {
                    b.OwnsOne("SalaryService.Domain.Common.Period", "Period", b1 =>
                        {
                            b1.Property<long>("TotalFinancesHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<Instant>("FromUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("FromUtc");

                            b1.Property<Instant?>("ToUtc")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("ToUtc");

                            b1.HasKey("TotalFinancesHistoryId");

                            b1.ToTable("TotalFinancesHistory");

                            b1.WithOwner()
                                .HasForeignKey("TotalFinancesHistoryId");
                        });

                    b.Navigation("Period")
                        .IsRequired();
                });

            modelBuilder.Entity("SalaryService.Domain.Employee", b =>
                {
                    b.Navigation("EmployeeFinanceForPayroll")
                        .IsRequired();

                    b.Navigation("EmployeeFinancialMetrics")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
