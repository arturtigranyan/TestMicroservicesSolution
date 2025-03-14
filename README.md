# TestMicroservicesSolution

This is a full-stack Microservices-based Web Application built using Clean Architecture, .NET 8, Angular, and SQL Server.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js & npm](https://nodejs.org/en/download/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

**Clone the repository:**

```bash
git clone https://github.com/arturtigranyan/TestMicroservicesSolution.git
```

**Navigate to the project root:**

```bash
cd TestMicroservicesSolution
```

**Restore dependencies:**

```bash
dotnet restore ./src
```

### Backend Setup

**Apply migrations to your databases:**

```bash
dotnet ef database update --project ./src/Test.Api.ProductService/Test.Infrastructure --startup-project ./src/Test.Api.ProductService/Test.Api
dotnet ef database update --project ./src/Test.Api.OrderService/Test.Infrastructure --startup-project ./src/Test.Api.OrderService/Test.Api
dotnet ef database update --project ./src/Test.Api.UserMicroservice/Test.Infrastructure --startup-project ./src/Test.Api.UserMicroservice/Test.Api
```

**Run each microservice individually:**

```bash
dotnet run --project ./src/{MicroserviceName}/Test.Api
```

Replace `{MicroserviceName}` with the respective service directory (e.g., `Test.Api.ProductService`).

### Frontend Setup (Angular)

**Navigate to Angular project:**

```bash
cd ./src/TestApiAngular/ecommerce-ui
```

**Install Angular dependencies:**

```bash
npm install
```

**Run Angular application:**

```bash
npm start
```

The application will run at (http://localhost:4200)

---

## Project Structure

- **`src/`**
  - Contains all microservices and the frontend Angular application.

- **`MigrationScripts/`**
  - SQL scripts generated from Entity Framework migrations.

- **`docs/`**
  - Project documentation and architectural details.

---

## Architecture

See the [Architecture.md](docs/ARCHITECTURE.md) file for detailed information about the project architecture and design decisions.