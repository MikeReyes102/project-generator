# Project Generator (V1)

Project Generator is a modular .NET 8.0 application for generating project scaffolding and codebases based on customizable templates and user-defined options. It is designed for extensibility, maintainability, and ease of use, supporting a pipeline-based architecture for validation, template resolution, logical generation, and materialization.

## Features

- **Pipeline Architecture:** Modular stages for validation, template resolution, logical generation, and file materialization.
- **Extensible Templates:** Easily add or modify templates for different project types and structures.
- **Domain-Driven Design:** Clear separation of concerns with core, application, and infrastructure layers.
- **Test Coverage:** Includes unit and integration tests for validation and pipeline logic.
- **Customizable Options:** Supports options like frameworks (e.g., Bootstrap) and page configurations.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Building the Project

```
dotnet build
```

### Running the Console Application

```
dotnet run --project src/ProjectGenerator.Console
```

### Running Tests

```
dotnet test
```

## Usage

The console application demonstrates generating a sample project using a hardcoded request. You can modify `Program.cs` in `src/ProjectGenerator.Console` to customize the request or integrate user input.

**Pipeline Stages:**

1. Validation
2. Template Resolution
3. Logical Generation
4. Materialization (writes files to disk)

**Output:**
Generated projects are written to the `output/` directory by default.

## Project Structure

```
src/
 ProjectGenerator.Core/         # Core domain models, contracts, enums, validation, pipeline interfaces
 ProjectGenerator.Application/  # Pipeline runner and stage implementations
 ProjectGenerator.Infrastructure/ # File system and template providers
 ProjectGenerator.Console/      # Console entry point
output/                          # Generated projects
tests/                           # Unit and integration tests
```

## Extending the Generator

- **Add New Templates:** Implement `ITemplateProvider` and register in the pipeline.
- **Add Pipeline Stages:** Implement `IPipelineStage` and add to the pipeline runner.
- **Customize Materialization:** Extend or replace `IProjectMaterializer`.

## Contributing

Contributions are welcome! Please open issues or pull requests for bug fixes, new features, or improvements.

## Roadmap

### V2 (Planned)

- Add interactive user input for project generation (CLI prompts or arguments)
- Add a new template option for React projects
