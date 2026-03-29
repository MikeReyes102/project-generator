using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline;

// Orchestrates the execution of pipeline stages for project generation.
public class PipelineRunner
{
    // The ordered list of pipeline stages to execute.
    private readonly IEnumerable<IPipelineStage> _stages;

    // Constructor takes the pipeline stages to run.
    public PipelineRunner(IEnumerable<IPipelineStage> stages)
    {
        _stages = stages;
    }

    // Runs each pipeline stage in order, passing the context through each.
    // If any stage fails, returns the failure result immediately.
    public async Task<PipelineResult> RunAsync(
        GenerationContext context,
        CancellationToken cancellationToken = default)
    {
        foreach (var stage in _stages)
        {
            if (!stage.ShouldExecute(context))
                continue;

            var result = await stage.ExecuteAsync(context, cancellationToken);

            if (!result.IsSuccess)
                return result;
        }

        // All stages succeeded
        return PipelineResult.Success();
    }
}