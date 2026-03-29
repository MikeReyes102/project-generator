using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;
using ProjectGenerator.Core.Validation;

namespace ProjectGenerator.Application.Pipeline.Stages;

// Pipeline stage that validates the project request.
public class ValidationStage : IPipelineStage
{
    // Only execute if validation hasn't already been performed.
    public bool ShouldExecute(GenerationContext context)
    {
        return context.ValidationResult == null;
    }

    // Runs input validation and updates the context with the result.
    // Returns failure if validation errors are found.
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