# TestMicroservicesSolution
Test Microservices

TestMicroservicesSolution
This is a full-stack Microservices-based Web Application built using Clean Architecture, .NET 8, Angular, and SQL Server.

Getting Started

Prerequisites

.NET 8 SDK
Node.js & npm
SQL Server
Visual Studio or VS Code

Installation

Clone the repository:
git clone https://github.com/arturtigranyan/TestMicroservicesSolution.git
cd TestMicroservicesSolution

Navigate to the src directory and restore dependencies:
dotnet restore

Database Setup

Apply migrations for each microservice:

User Microservice:
dotnet ef database update --project ./src/Test.Api.UserMicroservice/Test.Infrastructure --startup-project ./src/Test.Api.UserMicroservice/Test.Api

Product Microservice:
dotnet ef database update --project ./src/Test.Api.ProductService/Test.Infrastructure --startup-project ./src/Test.Api.ProductService/Test.Api

Order Microservice:
dotnet ef database update --project ./src/Test.Api.OrderService/Test.Infrastructure --startup-project ./src/Test.Api.OrderService/Test.Api

Running the Application

Run each microservice individually using Visual Studio or the CLI:
dotnet run --project ./src/{Microservice}/Test.Api

Replace {Microservice} with the specific microservice name (e.g., Test.Api.UserMicroservice).

Frontend Setup (Angular)
Navigate to the Angular directory:

cd src/TestApiAngular
npm install
ng serve

Open Angular application at:

http://localhost:4200

Running Tests
Execute all tests:
dotnet test ./src

Documentation
Further documentation on architecture decisions, setup instructions, and API usage is located in the docs folder.

CI/CD Pipeline
Continuous Integration configured with GitHub Actions to build and test automatically on every push.

Technologies
.NET 8
Entity Framework Core
SQL Server
Angular
GitHub Actions
Serilog