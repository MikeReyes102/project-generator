using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

public class MaterializationStage : IPipelineStage
{
    public bool ShouldExecute(GenerationContext context)
    {
        return context.GeneratedProject != null;
    }

    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        // TODO: Write files to disk (Infrastructure)
        return Task.FromResult(PipelineResult.Success());
    }
}