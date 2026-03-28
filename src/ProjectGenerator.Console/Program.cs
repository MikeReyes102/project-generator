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

class Program
{
    static async Task Main(string[] args)
    {
        SysConsole.WriteLine("=== Project Generator ===");

        // STEP 1: Build request (hardcoded for now)
        var request = new ProjectRequest
        {
            ProjectName = "TestProject",
            ProjectType = ProjectType.BasicFrontend,
            IncludeReadme = true,
            PageConfig = new PageConfiguration
            {
                PageType = PageType.MultiPage,
                PageCount = 1
            },
            Options = new List<string> { "Bootstrap" }
        };

        // STEP 2: Create context
        var context = new GenerationContext(request);

        // STEP 3: Define pipeline stages
        var stages = new List<IPipelineStage>
        {
            new ValidationStage(),
            new TemplateResolutionStage(new BasicTemplateProvider()),
            new LogicalGenerationStage(),
            new MaterializationStage(new FileSystemMaterializer())
        };


        // STEP 4: Run pipeline
        var runner = new PipelineRunner(stages);

        var result = await runner.RunAsync(context);

        // Debug Check: Output final context state after pipeline execution
        if (context.Template != null)
        {
            SysConsole.WriteLine($"Final Template: {context.Template.Name}");
            SysConsole.WriteLine($"Final Files: {context.Template.Files.Count}");
        }

        // Debug Check: Output generated project details
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

        // STEP 5: Output result
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