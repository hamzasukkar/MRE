# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a Monitoring and Evaluation (M&E) Platform for Syria built with .NET 7 and Entity Framework Core. The platform provides comprehensive project management, framework alignment, and monitoring capabilities for development programs.

## Architecture

The solution follows Clean Architecture principles with four main projects:

- **MEPlatform.API**: ASP.NET Core Web API project serving as the entry point with JWT authentication, Swagger documentation, and CORS configuration
- **MEPlatform.Core**: Domain layer containing entities, enums, and business logic with base entity pattern
- **MEPlatform.Application**: Application layer with DTOs, services, MediatR handlers, AutoMapper profiles, and FluentValidation
- **MEPlatform.Infrastructure**: Infrastructure layer handling data access via Entity Framework Core, SQL Server, and Identity management

## Key Technologies

- .NET 7 with nullable reference types enabled
- Entity Framework Core 7.0 with SQL Server
- ASP.NET Core Identity with JWT Bearer authentication
- MediatR for CQRS pattern
- AutoMapper for object mapping  
- FluentValidation for input validation
- Swagger/OpenAPI for API documentation

## Common Commands

### Build and Run
```bash
# Build entire solution
dotnet build MEPlatform.sln

# Run API project (includes database seeding)
dotnet run --project MEPlatform.API

# Build specific project
dotnet build MEPlatform.API
```

### Database Operations
```bash
# Add migration (run from solution root)
dotnet ef migrations add <MigrationName> --project MEPlatform.Infrastructure --startup-project MEPlatform.API

# Update database
dotnet ef database update --project MEPlatform.Infrastructure --startup-project MEPlatform.API

# Remove last migration
dotnet ef migrations remove --project MEPlatform.Infrastructure --startup-project MEPlatform.API
```

### Package Management
```bash
# Restore packages
dotnet restore

# Add package to specific project
dotnet add MEPlatform.API package <PackageName>
```

## Domain Model

The platform manages:
- **Frameworks**: M&E frameworks with hierarchical elements and indicators
- **Projects**: Development projects with alignment to frameworks, regional/sector associations
- **Programs**: Collections of related projects
- **Users**: Role-based access (SuperAdministrator, Supervisor, ProgramManager, Viewer)
- **Monitoring**: Data collection and measurements against indicators

## Authentication & Authorization

- JWT-based authentication configured in Program.cs
- Role-based authorization policies for different user levels
- Default admin user seeded on startup (admin@meplatform.com / Admin123!)
- Identity configuration with password requirements

## API Structure

Controllers are organized by domain:
- **AuthController**: User authentication and registration
- **FrameworksController**: M&E framework management
- **ProgramsController**: Program CRUD operations  
- **MonitoringController**: Data collection and reporting

## Development Notes

- Database is automatically created and seeded on application startup
- CORS configured for React frontend (localhost:3000)
- Swagger UI available in development mode
- All entities inherit from BaseEntity with audit fields
- No test projects currently configured in the solution