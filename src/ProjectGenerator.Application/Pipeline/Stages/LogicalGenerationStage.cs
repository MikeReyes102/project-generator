using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

// Pipeline stage that generates the logical project structure and files in memory.
public class LogicalGenerationStage : IPipelineStage
{
    // Only execute if a template is set and the project hasn't been generated yet.
    public bool ShouldExecute(GenerationContext context)
    {
        return context.Template != null && context.GeneratedProject == null;
    }

    // Generates the in-memory project structure and files based on the template.
    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        var request = context.Request;
        var template = context.Template!;

        // Create the generated project with the output path
        var generatedProject = new GeneratedProject(
            request.ProjectName,
            $"./output/{request.ProjectName}"
        );

        // Add directories from the template
        foreach (var dir in template.Directories)
        {
            generatedProject.AddDirectory(new GeneratedDirectory(dir));
        }

        // Add files from the template, resolving placeholders
        foreach (var file in template.Files)
        {
            var resolvedContent = ResolvePlaceholders(
                file.ContentTemplate,
                request
            );

            var generatedFile = new GeneratedFile(
                file.Path,
                resolvedContent
            );

            generatedProject.AddFile(generatedFile);
        }

        // Update the context with the generated project
        context.SetGeneratedProject(generatedProject);

        return Task.FromResult(PipelineResult.Success());
    }

    // Replaces template placeholders in file content using the project request.
    private string ResolvePlaceholders(string content, ProjectRequest request)
    {
        return content
            .Replace("{{ProjectName}}", request.ProjectName);
    }
}