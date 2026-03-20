using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Validation;

namespace ProjectGenerator.Core.Pipeline.Context;

public class GenerationContext
{
    public ProjectRequest Request { get; }

    public ValidationResult? ValidationResult { get; private set; }

    public ProjectTemplate? Template { get; private set; }

    public GeneratedProject? GeneratedProject { get; private set; }

    public GenerationContext(ProjectRequest request)
    {
        Request = request ?? throw new ArgumentNullException(nameof(request));
    }

    public void SetValidationResult(ValidationResult result)
    {
        if (ValidationResult != null)
            throw new InvalidOperationException("Validation already performed.");

        ValidationResult = result;
    }

    public void SetTemplate(ProjectTemplate template)
    {
        if (Template != null)
            throw new InvalidOperationException("Template already set.");

        Template = template;
    }

    public void SetGeneratedProject(GeneratedProject project)
    {
        if (GeneratedProject != null)
            throw new InvalidOperationException("Project already generated.");

        GeneratedProject = project;
    }
}