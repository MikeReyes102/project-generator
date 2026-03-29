using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Core.Pipeline.Interfaces;

// Defines a stage in the project generation pipeline.
public interface IPipelineStage
{
    // Determines whether this stage should execute, given the current context.
    bool ShouldExecute(GenerationContext context);

    // Executes the stage logic asynchronously.
    Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken);
}