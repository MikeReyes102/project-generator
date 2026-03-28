using ProjectGenerator.Application.Pipeline;
using ProjectGenerator.Application.Pipeline.Stages;
using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Enums;
using ProjectGenerator.Core.Pipeline.Context;

namespace ProjectGenerator.Tests.Validation;

public class ValidationTests
{
    [Fact]
    public async Task Pipeline_Should_Fail_When_ProjectName_Is_Empty()
    {
        var request = new ProjectRequest
        {
            ProjectName = "",
            ProjectType = ProjectType.BasicFrontend,
            IncludeReadme = true,
            PageConfig = new PageConfiguration
            {
                PageType = PageType.SinglePage
            }
        };

        var context = new GenerationContext(request);

        var runner = new PipelineRunner(new[]
        {
            new ValidationStage()
        });

        var result = await runner.RunAsync(context);

        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Errors);
    }
}