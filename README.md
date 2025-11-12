# inner-circle-employees-api

## Run in Visual Studio

First run this script to run a db and mocked external deps:
```bash
docker compose --profile MockForDevelopment up --build
```

## Migrations

### Adding a new migration  (Windows via Visual Studio)

Run the database using docker compose executing the following script (don't close the terminal unless you want to stop the containers)
```bash
docker compose --profile DbOnly up --build
```
>Note: `--build` gurantees that we run the latest code after re-applying the script

After making changes to the model and AppDbContext open Tools -> NuGet Package Manager -> Package Manager Console

If you want to use 'Update-Database' commands to apply migrations to the database please execute following command in Package Manager Console every time you open the solution.
```bash
$env:ASPNETCORE_ENVIRONMENT = 'MockForDevelopment';
```

Execute the following with your migration name
```bash
Add-Migration <YOUR_MIGRATION_NAME> -Project Application -Context AppDbContext
```

To apply migration run the following:
```bash
Update-Database -Project Application -Context AppDbContext
```

## Karate Tests

### Run Karate Tests Against Api Running in IDE (not Docker Compose)

Run Db and MockServer executing the following command (don't close the terminal unless you want to stop the containers)

```bash
docker compose --profile MockForDevelopment up --build
```

Then execute following command inside of the dev-container
```bash
API_ROOT_URL=http://host.docker.internal:5506 java -jar /karate.jar .
```

### Run Karate against Api, Db, and MockServer in Docker Compose

Run Api, Db, and MockServer executing the following command (don't close the terminal unless you want to stop the containers)

```bash
docker compose --profile MockForTests up --build
```

Then execute following command inside of the dev-container
```bash
API_ROOT_URL=http://localhost:6506 java -jar /karate.jar .
```

### Running Karate Tests, Api, Db, and MockServer in Docker Compose

Run the docker compose with MockForPullRequest profile executing the following command (don't close the terminal unless you want to stop the containers)

```bash
docker compose --profile MockForPullRequest up --build
```
>Note: this also includes Karate Tests run by default. However, if you want to run the test again from Dev Container execute:
```bash
API_ROOT_URL=http://localhost:6506 java -jar /karate.jar .
```

## Swagger

You can fetch OpenApi endpoints and types contract using this path `/swagger/openapi/v1.json`. Swagger UI is accessible here `/swagger/index.html`. 

However, UI doesn't support requests execution, this requires adding Auth dialog to pass a token. It is a bi

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
