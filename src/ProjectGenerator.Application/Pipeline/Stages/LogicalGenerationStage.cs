using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

public class LogicalGenerationStage : IPipelineStage
{
    public bool ShouldExecute(GenerationContext context)
    {
        return context.GeneratedProject == null;
    }

    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        // TODO: Build GeneratedProject here
        return Task.FromResult(PipelineResult.Success());
    }
}