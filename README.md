# inner-circle-employees-api

# Getting started with Docker

You need to create an internal network for configuring interaction between different back-end services.  
You can do it using the following command in your terminal: `docker network create ic-backend-deb`.  
Note: If you already has this network, skip this step.

To start the service, you should go to the solution folder and enter this command in the terminal. This command starts the service in Docker and raises the database.
```
docker-compose up -d
```

You can use Swagger to see all roots by following this link:
```
http://localhost:5000/index.html
```
Service requests are made like this
```
GET http://localhost:5000/api/finances/get-finance-data
POST http://localhost:5000/api/employees/create-employee
```

## Configurations

- MockForPullRequest - used in PR pipeline to run the service in isolation (no external deps) and run its Karate tests against it
- MockForDevelopment - used locally when you run the service in Visual Studio e.g. in Debug and don't want to spin up any external deps
- LocalEnvForDevelopment - used locally when you run the service in Visual Studio and you want to connect to its external deps from Local Env (ToDo not there yet)
- ProdForDevelopment - used locally when you run the service in Visual Studio and want to connect to its external deps from Prod specially dedicated Local Development Tenant (ToDo, need to complete tenants, secrets need to be available in the developer PC env vars)
- ProdForDeployment - used when we run the service in Prod, it shouldn't contain any secrets, it should be a Release build, using real Prod external deps

## Database scheme 

```mermaid
erDiagram
    CoefficientOptions{
        bigint Id PK "Not null."
        numeric DistrictCoefficient "Not null."
        numeric MinimumWage "Not null."
        numeric IncomeTaxPercent "Not null."
        numeric OfficeExpenses "Not null."
    }

    EmployeeFinancialMetrics{
        bigint EmployeeId PK, FK "Not null."
        timestamptz CreatedAtUtc "Not null."
        numeric Salary "Not null."
        numeric HourlyCostFact "Not null."
        numeric HourlyCostHand "Not null."
        numeric Earnings "Not null."
        numeric IncomeTaxContributions "Not null."
        numeric PensionContributions "Not null."
        numeric MedicalContributions "Not null."
        numeric SocialInsuranceContributions "Not null."
        numeric InjuriesContributions "Not null."
        numeric Expenses "Not null."
        numeric Profit "Not null."
        numeric ProfitAbility "Not null."
        numeric GrossSalary "Not null."
        numeric NetSalary "Not null."
        numeric RatePerHour "Not null."
        numeric Pay "Not null."
        numeric Prepayment "Not null."
        numeric EmploymentType "Not null."
        numeric ParkingCostPerMonth "Not null."
        numeric AccountingPerMonth "Not null."
        numeric DistrictCoefficient "Not null. Default is 0.0."
    }

    EmployeeFinancialMetricsHistory{
        bigint Id PK "Not null."
        bigint EmployeeId FK "Not null."
        timestamptz FromUtc "Not null."
        timestamptz ToUtc
        numeric Salary "Not null."
        numeric HourlyCostFact "Not null."
        numeric HourlyCostHand "Not null."
        numeric Earnings "Not null."
        numeric IncomeTaxContributions "Not null."
        numeric PensionContributions "Not null."
        numeric MedicalContributions "Not null."
        numeric SocialInsuranceContributions "Not null."
        numeric InjuriesContributions "Not null."
        numeric Expenses "Not null."
        numeric Profit "Not null."
        numeric ProfitAbility "Not null."
        numeric GrossSalary "Not null."
        numeric NetSalary "Not null."
        numeric RatePerHour "Not null."
        numeric Pay "Not null."
        numeric Prepayment "Not null."
        numeric EmploymentType "Not null."
        numeric ParkingCostPerMonth "Not null."
        numeric AccountingPerMonth "Not null."
    }

    Employees{
        bigint Id PK "Not null."
        text FirstName "Not null."
        text LastName "Not null."
        text MiddleName "Default is ''."
        text CorporateEmail "Not null. Default is ''."
        text PersonalEmail "Default is ''."
        text Phone "Default is ''."
        text GitHub
        text GitLab
        timestamptz HireDate
        timestamptz DeletedAtUtc
        bool IsBlankEmployee "Not null. Default is true."
        bool IsCurrentEmployee "Not null. Default is false."
        bool IsEmployedOfficially "Not null. Default is false."
        text PersonnelNumber
        bool IsSpecial "Not null. Default is false."
        bigint TenantId "Not null. Default is 0."
    }

    EstimatedFinancialEfficiency{
        bigint Id PK "Not null."
        numeric DesiredEarnings "Not null."
        numeric DesiredProfit "Not null."
        numeric DesiredProfitability "Not null."
        numeric ReserveForQuarter "Not null."
        numeric ReserveForHalfYear "Not null."
        numeric ReserveForYear "Not null."
        timestamptz CreatedAtUtc "Not null. Default is '1970-01-01 05:00:00+05'."
    }

    TotalFinances{
        bigint Id PK "Not null."
        timestamptz CreatedAtUtc "Not null."
        numeric PayrollExpense "Not null."
        numeric TotalExpense "Not null."
    }

    TotalFinancesHistory{
        bigint Id PK "Not null."
        timestamptz FromUtc "Not null."
        timestamptz ToUtc
        numeric PayrollExpense "Not null."
        numeric TotalExpense "Not null."
    }

    WorkingPlan{
        bigint Id PK "Not null."
        numeric WorkingDaysInYear "Not null."
        numeric WorkingDaysInYearWithoutVacation "Not null."
        numeric WorkingDaysInYearWithoutVacationAndSick "Not null."
        numeric WorkingDaysInMonth "Not null."
        numeric WorkingHoursInMonth "Not null."
    }


    Employees ||--|| EmployeeFinancialMetrics : has
    Employees ||--|{ EmployeeFinancialMetricsHistory : has

```
