using ProjectGenerator.Core.Contracts;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

public class MaterializationStage : IPipelineStage
{
    private readonly IProjectMaterializer _materializer;

    public MaterializationStage(IProjectMaterializer materializer)
    {
        _materializer = materializer;
    }

    public bool ShouldExecute(GenerationContext context)
    {
        return context.GeneratedProject != null;
    }

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