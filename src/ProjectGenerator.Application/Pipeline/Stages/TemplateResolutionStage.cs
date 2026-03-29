using ProjectGenerator.Core.Contracts;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

// Pipeline stage that resolves the project template based on the request.
public class TemplateResolutionStage : IPipelineStage
{
    // The template provider used to resolve templates.
    private readonly ITemplateProvider _templateProvider;

    // Constructor takes the template provider to use.
    public TemplateResolutionStage(ITemplateProvider templateProvider)
    {
        _templateProvider = templateProvider;
    }

    // Only execute if the template hasn't already been set.
    public bool ShouldExecute(GenerationContext context)
    {
        return context.Template == null;
    }

    // Resolves the template and updates the context.
    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        var template = _templateProvider.GetTemplate(context.Request);

        context.SetTemplate(template);

        return Task.FromResult(PipelineResult.Success());
    }
}