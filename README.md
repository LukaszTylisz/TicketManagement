## Football Ticket Management
This is a football ticket sales back office application built with ASP.NET Core 8 Web API and Blazor WebAssembly as the UI and consumer of the API. Using an Onion Architecture with Clean Architecture based on architectural principles, the end goal is to have a testable and maintainable application architecture. 

// Project is in work. In feature will be added more functions

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

 - //Feature Swagger UI
 - //Feature Blazor WebAssembly
 - //Feature Serilog
 - //Feature Pagination
 - //Feature In-Memory Database for Integration Tests
 - //Feature Microsoft Identity with JWT Authentication
 - //Feature Database Seeding
 - //Feature Sendgrid Email Service
 - //Feature Register / Login & Generate Token

