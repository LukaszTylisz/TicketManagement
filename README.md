## Ticket Management
This is a ticket sales back office application built with `ASP.NET Core 8 Web API` and  `Blazor WebAssembly` as the UI and consumer of the API. Using an Onion Architecture with Clean Architecture based on architectural principles, the end goal is to have a testable and maintainable application architecture. 

// Project is in work. In feature will be added more functions

## Requirements

Before you begin, ensure you have the following software installed on your system:

- [.NET Core 8 SDK]

## Development Setup
1. Clone this repository:
   ```bash
   git clone https://github.com/LukaszTylisz/TicketManagement.git
   
2. Create a database with -Context TicketManagementDatabaseContext then TicketManagementDatabaseIdentityDbContext and apply migrations:
   ```bash
    update-database -Context dbContext
3. Back end run on: https://localhost:7025/ and Front end on: https://localhost:7233

### Solution structure

![image](https://github.com/LukaszTylisz/TicketManagement/assets/86656091/5d4bffe8-433c-4c05-b959-dbaf88d73c93)

### Swagger

![image](https://github.com/LukaszTylisz/TicketManagement/assets/86656091/5ce49cbc-24e3-43c9-8d58-5745cbf58a96)


### Architecture overview

With Onion Architecture the `Domain` and `Application` layers are at the center of the design. This is known as the Core of the system.

The Domain layer contains enterprise logic and types and the Application layer contains business logic and types. The Core shouldn’t be dependent on concerns such as `Persistence` (Data Access) and `Infrastructure`, so we invert those dependencies. Therefore, Infrastructure and Presentation depend on the Core.

This is achieved by adding interfaces and abstractions within Core, which are implemented by layers outside Core such as Infrastructure.

All dependencies flow inwards, and Core has no dependencies on any other layers. Infrastructure and Presentation depend on Core, but not on one another.

#### The architecture is based on the following architectural principles:

- Separation of concerns
- Dependency Inversion
- Single Responsibility
- DRY
- Persistence Ignorance

This results in a design that is:
- Independent of UI, databases, frameworks
- Clean, maintainable, testable

### Goal
Have a solid foundation for future projects

### Technologies

- ASP.NET Core 8 Web API
- Onion Architecture
- CQRS with MediatR
- Fluent Validation
- Automapper
- Entity Framework Core - Code First
- Repository Pattern
- NSwag client code generation
- Response wrappers
- Custom Exception Handling Middlewares
- Microsoft Identity with JWT Authentication
- Register / Login & Generate Token
- Feature Database Seeding
- Feature Serilog
- Swagger UI
- Blazor WebAssembly
- Sendgrid Email Service
- Feature In-Memory Database for Integration Tests
- Moq
- Xunit
- //Feature Pagination


