# Project Style Guide

This document outlines the coding style conventions used in this project.

## Naming Conventions

*   **Classes & Interfaces:** Use PascalCase (e.g., `CandyService`, `IUserRepository`).
*   **Interfaces:** Prefix interface names with `I` (e.g., `IUserService`).
*   **Properties & Methods:** Use PascalCase (e.g., `FirstName`, `GetUserDetails`).
*   **DTOs (Data Transfer Objects):** Use PascalCase and often include the action and entity type, suffixed with `Dto` (e.g., `UserRegisterFormDTO`, `CandyResponseDto`).
*   **Private Fields:** Use camelCase prefixed with an underscore (e.g., `_userService`).
*   **Local using aliases:** Use PascalCase for type aliases, often reflecting the original namespace or purpose (e.g., `Dal` for `Candy.DAL.Models`, `CandyDbCtxOpts` for `DbContextOptions<CandyDbContext>`).

## Code Structure & Formatting

*   **File Organization:** Organize code logically into layers (e.g., API, BLL, DAL) and subfolders within layers (e.g., `Configurations`, `Interfaces`, `Models`, `Repositories` within `DAL`).
*   **Namespaces:** Use namespaces that reflect the folder structure (e.g., `Candy.API.Models`, `Candy.BLL.Services`, `Candy.DAL.Repositories`).
*   **Braces:** Use K&R style braces (opening brace on the same line as the statement/declaration).
*   **Indentation:** Use 2 spaces for indentation.
*   **Blank Lines:** Use blank lines to separate methods, properties, and logical blocks of code for readability.
*   **Using Directives:** Group `using` directives at the top of the file. Local using aliases are permitted for brevity where appropriate.

## Comments

*   Use comments to explain complex logic, assumptions, or intent where the code isn't self-explanatory.
*   Use XML documentation comments for public APIs (classes, methods, properties, interface members).

## Diagramming (PlantUML)

*   Use PlantUML for generating diagrams.
*   Define layout direction (e.g., `left to right direction`).
*   Use `package` blocks to represent layers or logical groupings.
*   Use `class` and `interface` keywords as appropriate.
*   Denote public members with `+`.
*   Use comments (`'`) for explanations within the PlantUML definition.

## Data Access Layer (DAL) Conventions

*   **Entity Framework Core:** Utilize Entity Framework Core for database interactions.
*   **DbContext:** Use a single `DbContext` class (`CandyDbContext`) to represent the database session.
*   **DbSet:** Expose entity collections as `DbSet<T>` properties in the `DbContext`.
*   **Entity Configuration:** Configure entity mappings and relationships using classes that implement `IEntityTypeConfiguration<T>`. Place these configuration files in the `Configurations` subfolder, organized by domain (e.g., `Configurations/Products`). Name configuration files `[EntityName]Config.cs`.
*   **Repository Pattern:** Implement the Repository pattern for data access. Define repository interfaces in the `Interfaces` subfolder (e.g., `IUserRepository`) and their implementations in the `Repositories` subfolder (e.g., `UserRepository`).
*   **Fluent API Chaining:** When using Entity Framework's Fluent API for configuration, chain method calls with clear indentation for readability (typically 4 spaces for the chained calls).
*   **Data Validation Attributes:** Use data validation attributes (e.g., `[EmailAddress]`) on parameters in repository interfaces where appropriate for clarity and intent.

---

*This guide is based on observed patterns. Please update it as conventions evolve.*
