using ProjectGenerator.Application.Pipeline;
using ProjectGenerator.Application.Pipeline.Stages;
using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Enums;
using ProjectGenerator.Core.Pipeline.Context;

namespace ProjectGenerator.Tests.Validation;

// Contains unit tests for validating the input validation stage of the pipeline.
public class ValidationTests
{
    // Test: The pipeline should fail if the project name is empty.
    // This ensures that the validation stage correctly rejects invalid input.
    [Fact]
    public async Task Pipeline_Should_Fail_When_ProjectName_Is_Empty()
    {
        // Arrange: Create a request with an empty project name
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

        // Act: Run the pipeline with only the validation stage
        var runner = new PipelineRunner(new[]
        {
            new ValidationStage()
        });

        var result = await runner.RunAsync(context);

        // Assert: The result should be a failure with errors
        Assert.False(result.IsSuccess);
        Assert.NotEmpty(result.Errors);
    }
}