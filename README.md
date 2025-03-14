Test Microservices Solution

This repository contains a full-stack microservices-based web application built using Clean Architecture, .NET 8, Angular, and SQL Server. The solution demonstrates best practices for developing scalable and maintainable software.

Project Overview

Architecture

The solution employs Clean Architecture principles to ensure separation of concerns and maintainability.

Presentation Layer:

APIs (ASP.NET Core Web API)

Frontend (Angular)

Application Layer:

Contains core application logic, independent from infrastructure.

Domain Layer:

Core business entities, rules, and validations.

Infrastructure Layer:

SQL Server database (accessed via Entity Framework Core)

Authentication and authorization (ASP.NET Core Identity & JWT)

Logging (Serilog)

Microservices

The project consists of three main microservices:

User Management Service: Handles authentication, registration, and user profiles.

Product Management Service: Manages products, inventory, and related operations.

Order Management Service: Manages orders, transactions, and user orders.

Communication between microservices is managed through an Ocelot API Gateway.

Technologies Used

.NET 8

ASP.NET Core Web API

Angular

SQL Server

Entity Framework Core

Ocelot API Gateway

JWT Authentication

Serilog (logging)

Getting Started

Prerequisites

.NET 8 SDK

Node.js & npm

SQL Server

Installation & Setup

Clone the repository:

git clone https://github.com/arturtigranyan/TestMicroservicesSolution.git
cd TestMicroservicesSolution

Restore backend dependencies:

dotnet restore ./src

Apply database migrations:

dotnet ef database update --project ./src/{Microservice}/Test.Infrastructure --startup-project ./src/{Microservice}/Test.Api

Replace {Microservice} with:

Test.Api.UserMicroservice

Test.Api.ProductService

Test.Api.OrderService

Run backend services individually (from Visual Studio or CLI).

Frontend setup:

Navigate to Angular project and install dependencies:

cd src/TestApiAngular
yarn install
ng serve

Project Structure

.
??? docs/                 # Architecture documentation
??? MigrationScripts/     # SQL migration scripts
??? src/
?   ??? Test.Api.OrderService/
?   ??? Test.Api.ProductService/
?   ??? Test.Api.UserMicroservice/
?   ??? TestApiAngular/   # Frontend Angular project
?   ??? Test.ApiGateway/  # Ocelot API Gateway
??? .github/              # CI/CD pipelines
??? README.md             # This documentation

CI/CD

CI/CD pipelines configured with GitHub Actions for automated builds and tests.

Contribution

Contributions are welcome. Please submit pull requests or report issues via GitHub.