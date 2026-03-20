using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Core.Pipeline.Interfaces;

public interface IPipelineStage
{
    bool ShouldExecute(GenerationContext context);

    Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken);
}