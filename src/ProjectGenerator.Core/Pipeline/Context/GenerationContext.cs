using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Validation;

namespace ProjectGenerator.Core.Pipeline.Context;

// Holds state and results for a project generation pipeline run.
public class GenerationContext
{
    // The project request being processed.
    public ProjectRequest Request { get; }

    // The validation result, if validation has been performed.
    public ValidationResult? ValidationResult { get; private set; }

    // The resolved project template, if set.
    public ProjectTemplate? Template { get; private set; }

    // The generated project, if set.
    public GeneratedProject? GeneratedProject { get; private set; }

    // Create a new context for the given request.
    public GenerationContext(ProjectRequest request)
    {
        Request = request ?? throw new ArgumentNullException(nameof(request));
    }

    // Set the validation result (can only be set once).
    public void SetValidationResult(ValidationResult result)
    {
        if (ValidationResult != null)
            throw new InvalidOperationException("Validation already performed.");

        ValidationResult = result;
    }

    // Set the resolved template (can only be set once).
    public void SetTemplate(ProjectTemplate template)
    {
        if (Template != null)
            throw new InvalidOperationException("Template already set.");

        Template = template;
    }

    // Set the generated project (can only be set once).
    public void SetGeneratedProject(GeneratedProject project)
    {
        if (GeneratedProject != null)
            throw new InvalidOperationException("Project already generated.");

        GeneratedProject = project;
    }
}