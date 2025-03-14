# Architecture Overview

This project follows **Clean Architecture** principles, structured into distinct layers:

## Project Layers

- **Presentation Layer** (API and Angular UI)
  - Handles HTTP requests, user interactions, and API endpoints.

- **Application Layer**
  - Business logic and use-case handling, independent from infrastructure.

- **Domain Layer**
  - Core business entities and logic.

- **Infrastructure Layer**
  - Data access (SQL Server via Entity Framework Core).
  - Identity and authentication (ASP.NET Core Identity).
  - Logging (Serilog).

## Microservices and API Gateway

- User Management Microservice
- Product Management Microservice
- Order Management Microservice

All services communicate through an API Gateway (**Ocelot**).

## Technologies

- .NET 8
- ASP.NET Core Web API
- Angular
- SQL Server
- Entity Framework Core
- JWT Authentication
- Ocelot API Gateway
- Serilog Logging