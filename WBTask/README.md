# WBTask

WBTask is a lightweight ASP.NET Core Web API for managing package workflows, package versions, and processing steps. The application is built around an in-memory Entity Framework Core database and includes basic validation for user-role access during process creation.

## Project overview

This project provides a simple backend for operations such as:

- creating and retrieving packages
- tracking package versions
- managing package processes
- validating user permissions by role and country
- exposing API documentation in development mode

## Tech stack

- ASP.NET Core 10 Web API
- Entity Framework Core
- InMemory database provider
- OpenAPI / Swagger UI support

## Project structure

- `Program.cs` — application startup and DI configuration
- `Controllers/` — API controllers for packages, versions, and processes
- `Models/` — database context and domain models
- `Validators/` — role/permission validation logic
- `Properties/launchSettings.json` — local run profiles

## Getting started

### Prerequisites

- .NET 10 SDK
- A code editor such as Visual Studio or VS Code

### Restore dependencies

```bash
dotnet restore
```

### Run the API

```bash
dotnet run
```

By default, the app runs with local URLs configured in `Properties/launchSettings.json`.

- HTTP: http://localhost:5027
- HTTPS: https://localhost:7205

## Development API documentation

When running in Development mode, the project exposes OpenAPI metadata and Swagger UI.

- OpenAPI document: `/openapi/v1.json`
- Swagger UI: `/swagger`

## Seeded data

The application seeds initial sample data at startup using `DatabaseInitilaizer.Seed(...)`.

This includes example users, roles, and tasks. Because the app uses the in-memory database, data is reset when the application restarts.

## API endpoints

### Packages

- `GET /api/Package` — list all packages
- `GET /api/Package/{id}` — get a package by id
- `POST /api/Package` — create a new package

### Package versions

- `GET /api/Package/{packId}/PackageVersion` — list versions for a package
- `GET /api/Package/{packId}/PackageVersion/{id}` — get a specific package version

### Processes

- `GET /api/Package/{packId}/Process` — list processes for a package
- `GET /api/Package/{packId}/Process/{id}` — get a process by id
- `POST /api/Package/{packId}/Process` — create a process for a package

## Example requests

### Create a package

```bash
curl -X POST "https://localhost:7205/api/Package" \
  -H "Content-Type: application/json" \
  -d '{
    "packageContent": "Initial package payload",
    "lastVersion": 1,
    "status": "Draft"
  }'
```

### Create a process

```bash
curl -X POST "https://localhost:7205/api/Package/1/Process" \
  -H "Content-Type: application/json" \
  -H "x-user-id: 1" \
  -d '{
    "packageId": 1,
    "id": 1,
    "name": "Country approval",
    "initiatorUserId": 1,
    "countryCode": "BG",
    "status": "Pending"
  }'
```

## Validation behavior

Process creation is checked through the `Validator` class. It validates whether the supplied user id matches a known user and whether that user has the required role for the supplied country code.

If the user is not valid for the requested role/country combination, the controller returns an unauthorized result.

## Notes

- The application is intentionally simple and uses an in-memory data store for local development.
- This project is a backend API and does not include a frontend UI.
- The models and controllers suggest an approval workflow pattern, but some endpoints are currently left commented out or under active development.

## License

This project does not currently specify a license file. If you plan to publish or distribute it, add a license before doing so.
