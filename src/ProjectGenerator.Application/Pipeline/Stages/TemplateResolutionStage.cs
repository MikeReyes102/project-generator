using ProjectGenerator.Core.Contracts;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Core.Pipeline.Results;

namespace ProjectGenerator.Application.Pipeline.Stages;

public class TemplateResolutionStage : IPipelineStage
{
    private readonly ITemplateProvider _templateProvider;

    public TemplateResolutionStage(ITemplateProvider templateProvider)
    {
        _templateProvider = templateProvider;
    }

    public bool ShouldExecute(GenerationContext context)
    {
        return context.Template == null;
    }

    public Task<PipelineResult> ExecuteAsync(
        GenerationContext context,
        CancellationToken cancellationToken)
    {
        var template = _templateProvider.GetTemplate(context.Request);

        context.SetTemplate(template);

        return Task.FromResult(PipelineResult.Success());
    }
}