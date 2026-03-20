using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

public class TemplateResolutionStage : IPipelineStage
{
    public bool ShouldExecute(GenerationContext context)
    {
        return context.Template == null;
    }

    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        // TODO: Implement template resolution
        return Task.FromResult(PipelineResult.Success());
    }
}