TestMicroservicesSolution

This is a full-stack Microservices-based Web Application built using Clean Architecture, .NET 8, Angular, and SQL Server.

Getting Started

Prerequisites

.NET 8 SDK

Node.js & npm

SQL Server

Installation

Clone the repository:

git clone https://github.com/arturtigranyan/TestMicroservicesSolution.git

Navigate to the project root:

cd TestMicroservicesSolution

Restore dependencies:

dotnet restore ./src

Backend Setup

Apply migrations to your databases:

dotnet ef database update --project ./src/Test.Api.ProductService/Test.Infrastructure --startup-project ./src/Test.Api.ProductService/Test.Api
dotnet ef database update --project ./src/Test.Api.OrderService/Test.Infrastructure --startup-project ./src/Test.Api.OrderService/Test.Api
dotnet ef database update --project ./src/Test.Api.UserMicroservice/Test.Infrastructure --startup-project ./src/Test.Api.UserMicroservice/Test.Api

Run each microservice individually:

dotnet run --project ./src/{MicroserviceName}/Test.Api

Frontend Setup (Angular)

Navigate to Angular project:

cd ./src/TestApiAngular/ecommerce-ui

Install Angular dependencies:

npm install

Run Angular application:

npm start

The application will run at http://localhost:4200

Project Structure

src/

Contains all microservices and frontend Angular application.

MigrationScripts/

SQL scripts generated from Entity Framework migrations.

docs/

Project documentation and architectural details.

Architecture

See the Architecture.md file for detailed information about the project architecture and design decisions.

