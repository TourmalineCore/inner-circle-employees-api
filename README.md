# InnerCircle.EmployeesService

____
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
