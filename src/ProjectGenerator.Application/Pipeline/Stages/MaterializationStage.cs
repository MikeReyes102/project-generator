using ProjectGenerator.Core.Contracts;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

// Pipeline stage that materializes the generated project to the file system or other output.
public class MaterializationStage : IPipelineStage
{
    // The materializer used to write the project to disk or other output.
    private readonly IProjectMaterializer _materializer;

    // Constructor takes the materializer to use.
    public MaterializationStage(IProjectMaterializer materializer)
    {
        _materializer = materializer;
    }

    // Only execute if a generated project is available in the context.
    public bool ShouldExecute(GenerationContext context)
    {
        return context.GeneratedProject != null;
    }

    // Materializes the generated project using the provided materializer.
    public async Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        await _materializer.MaterializeAsync(
            context.GeneratedProject!,
            cancellationToken
        );

        return PipelineResult.Success();
    }
}