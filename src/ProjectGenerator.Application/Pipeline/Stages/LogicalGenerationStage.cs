using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

public class LogicalGenerationStage : IPipelineStage
{
    public bool ShouldExecute(GenerationContext context)
    {
        return context.Template != null && context.GeneratedProject == null;
    }

    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        var request = context.Request;
        var template = context.Template!;

        // Create GeneratedProject
        var generatedProject = new GeneratedProject(
            request.ProjectName,
            $"./output/{request.ProjectName}"
        );

        // Copy directories
        foreach (var dir in template.Directories)
        {
            generatedProject.AddDirectory(new GeneratedDirectory(dir));
        }

        // Process files
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

        context.SetGeneratedProject(generatedProject);

        return Task.FromResult(PipelineResult.Success());
    }

    private string ResolvePlaceholders(string content, ProjectRequest request)
    {
        return content
            .Replace("{{ProjectName}}", request.ProjectName);
    }
}