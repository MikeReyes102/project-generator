using ProjectGenerator.Core.Domain;

namespace ProjectGenerator.Core.Validation;

public static class InputValidation
{
    public static ValidationResult Validate(ProjectRequest request)
    {
        var result = new ValidationResult();

        ValidateProjectName(request.ProjectName, result);
        ValidatePageConfiguration(request.PageConfig, result);

        return result;
    }

    private static void ValidateProjectName(string name, ValidationResult result)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            result.AddError("Project name cannot be empty.");
            return;
        }

        if (name.Length < 3)
        {
            result.AddError("Project name must be at least 3 characters long.");
        }

        if (name.Any(char.IsWhiteSpace))
        {
            result.AddError("Project name cannot contain spaces.");
        }

        // Reject project names containing path traversal or separators
        if (name.Contains(".") || name.Contains("/") || name.Contains("\\"))
        {
            result.AddError("Project name cannot contain '.', '/' or '\' characters.");
        }
    }

    private static void ValidatePageConfiguration(PageConfiguration config, ValidationResult result)
    {
        if (config.PageType == Enums.PageType.MultiPage)
        {
            if (config.PageCount <= 0)
            {
                result.AddError("Page count must be greater than 0 for multi-page projects.");
            }

            if (config.PageCount > 5)
            {
                result.AddError("Page count cannot exceed 5.");
            }
        }
    }
}