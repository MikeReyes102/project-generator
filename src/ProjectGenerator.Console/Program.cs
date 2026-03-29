using ProjectGenerator.Application.Pipeline;
using ProjectGenerator.Application.Pipeline.Stages;
using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Enums;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Infrastructure.Templates;
using ProjectGenerator.Infrastructure.FileSystem;

using SysConsole = System.Console;

namespace ProjectGenerator.Console;

// Entry point for the Project Generator console application.
// This program demonstrates the use of the project generation pipeline with hardcoded input.
class Program
{
    static async Task Main(string[] args)
    {
        // Display application header
        SysConsole.WriteLine("=== Project Generator ===");

        // STEP 1: Build a sample project request (hardcoded for demonstration)
        // In a real application, this would be built from user input or configuration.
        var request = new ProjectRequest
        {
            ProjectName = "TestProject", // Name of the project to generate
            ProjectType = ProjectType.BasicFrontend, // Type of project (enum)
            IncludeReadme = true, // Whether to include a README file
            PageConfig = new PageConfiguration
            {
                PageType = PageType.MultiPage, // Type of pages (enum)
                PageCount = 1 // Number of pages to generate
            },
            Options = new List<string> { "Bootstrap" } // Additional options (e.g., frameworks)
        };

        // STEP 2: Create the generation context with the request
        var context = new GenerationContext(request);

        // STEP 3: Define the pipeline stages in order
        // Each stage performs a specific part of the generation process
        var stages = new List<IPipelineStage>
        {
            new ValidationStage(), // Validates the input request
            new TemplateResolutionStage(new BasicTemplateProvider()), // Resolves the template to use
            new LogicalGenerationStage(), // Generates the logical project structure
            new MaterializationStage(new FileSystemMaterializer()) // Writes files to disk
        };

        // STEP 4: Run the pipeline
        var runner = new PipelineRunner(stages);
        var result = await runner.RunAsync(context);

        // Output the final template state after pipeline execution (for debugging)
        if (context.Template != null)
        {
            SysConsole.WriteLine($"Final Template: {context.Template.Name}");
            SysConsole.WriteLine($"Final Files: {context.Template.Files.Count}");
        }

        // Output generated project details (for debugging)
        if (context.GeneratedProject != null)
        {
            SysConsole.WriteLine($"Generated Project: {context.GeneratedProject.ProjectName}");
            SysConsole.WriteLine($"Root Path: {context.GeneratedProject.Rootpath}");

            SysConsole.WriteLine("\nDirectories:");
            foreach (var dir in context.GeneratedProject.Directories)
            {
                SysConsole.WriteLine($"- {dir.Path}");
            }

            SysConsole.WriteLine("\nFiles:");
            foreach (var file in context.GeneratedProject.Files)
            {
                SysConsole.WriteLine($"- {file.Path}");
            }
        }

        // STEP 5: Output the result of the pipeline
        if (result.IsSuccess)
        {
            SysConsole.WriteLine("✅ Project generation pipeline completed successfully.");
        }
        else
        {
            SysConsole.WriteLine("❌ Pipeline failed with errors:");
            foreach (var error in result.Errors)
            {
                SysConsole.WriteLine($"- {error}");
            }
        }
    }
}