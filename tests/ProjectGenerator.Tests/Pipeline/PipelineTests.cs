using ProjectGenerator.Application.Pipeline;
using ProjectGenerator.Application.Pipeline.Stages;
using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Enums;
using ProjectGenerator.Core.Pipeline.Context;
using ProjectGenerator.Core.Pipeline.Interfaces;
using ProjectGenerator.Infrastructure.Templates;

namespace ProjectGenerator.Tests.Pipeline;

public class PipelineTests
{
    [Fact]
    public async Task Pipeline_Should_Generate_Project_For_Valid_Input()
    {
        // Arrange
        var request = new ProjectRequest
        {
            ProjectName = "TestProject",
            ProjectType = ProjectType.BasicFrontend,
            IncludeReadme = true,
            PageConfig = new PageConfiguration
            {
                PageType = PageType.MultiPage,
                PageCount = 3
            }
        };

        var context = new GenerationContext(request);

        var stages = new List<IPipelineStage>
        {
            new ValidationStage(),
            new TemplateResolutionStage(new BasicTemplateProvider()),
            new LogicalGenerationStage()
        };

        var runner = new PipelineRunner(stages);

        // Act
        var result = await runner.RunAsync(context);

        // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(context.GeneratedProject);
        Assert.Equal(6, context.GeneratedProject!.Files.Count);
    }
}