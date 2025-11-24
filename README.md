# NewProjectWithUnit – ASP.NET Core Web API (Repository + Unit of Work)

A clean ASP.NET Core Web API for managing **Departments** and **Employees** using the **Repository Pattern**, **Unit of Work**, and **DTOs** for clean and scalable architecture.

---

## 🔍 Overview

This project is a RESTful Web API that allows you to:

- Manage **Departments**
  - Create / Read / Update / Delete departments
- Manage **Employees**
  - Each employee belongs to a department (one-to-many)
  - Create / Read / Update / Delete employees
- Use **Repository Pattern** to separate data access from business logic
- Use **Unit of Work** to group multiple repository operations in a single transaction
- Use **DTOs** to control what data is exposed from the API
- Easily extend the project with new entities and features

---

## 🧱 Technologies & Packages

### 🔹 Framework

- .NET (ASP.NET Core) Web API  
- Entity Framework Core  
- SQL Server (LocalDB or full instance)

### 🔹 NuGet Packages (examples)

> Update versions according to your `.csproj` file.

| Package Name                                | Usage                                      |
|---------------------------------------------|--------------------------------------------|
| `Microsoft.EntityFrameworkCore`             | Base EF Core ORM                           |
| `Microsoft.EntityFrameworkCore.SqlServer`   | SQL Server provider for EF Core            |
| `Microsoft.EntityFrameworkCore.Tools`       | Migrations & design-time tools             |
| `Swashbuckle.AspNetCore`                    | Swagger UI & OpenAPI documentation         |
| (Optional) `AutoMapper`                     | Mapping between Entities and DTOs          |

### 🔹 Other Tools

- Entity Framework Core  
- SQL Server  
- Visual Studio / VS Code  
- Postman or Swagger UI for testing the API  

---

## 🗂 Project Structure

```text
NewProjectWithUnit
├── Controllers
│   ├── DepartmentController.cs          // Department CRUD endpoints
│   └── EmployeeFirsrController.cs       // Employee CRUD endpoints
│
├── Dbcontext
│   └── App_context.cs                   // EF Core DbContext (Departments, Employees)
│
├── Repository
│   ├── IRepository.cs                   // Generic repository interface
│   └── MainRepository.cs                // Generic repository implementation
│
├── Unit of Ropository
│   ├── IUnitofwork.cs                   // Unit of Work contract
│   └── UnitRrpository.cs                // Unit of Work implementation
│
├── Models                                // Domain entities (Employee, Department, etc.)
│   ├── Employee.cs
│   └── Department.cs
│
├── DTO                                   // Data Transfer Objects
│   ├── EmployeeDto.cs
│   └── DepartmentDto.cs
│
├── appsettings.json                      // Connection string and configuration
└── Program.cs / Startup.cs               // Services registration & middleware pipeline
