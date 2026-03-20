using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline;

public class PipelineRunner
{
    private readonly IEnumerable<IPipelineStage> _stages;

    public PipelineRunner(IEnumerable<IPipelineStage> stages)
    {
        _stages = stages;
    }

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

        return PipelineResult.Success();
    }
}