using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;
using ProjectGenerator.Core.Validation;

namespace ProjectGenerator.Application.Pipeline.Stages;

public class ValidationStage : IPipelineStage
{
    public bool ShouldExecute(GenerationContext context)
    {
        return context.ValidationResult == null;
    }

    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        var result = InputValidation.Validate(context.Request);

        context.SetValidationResult(result);

        if (!result.IsValid)
        {
            return Task.FromResult(PipelineResult.Failure(result.Errors));
        }

        return Task.FromResult(PipelineResult.Success());
    }
}