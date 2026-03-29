using ProjectGenerator.Core.Domain;

namespace ProjectGenerator.Core.Validation;

// Provides input validation logic for project requests.
public static class InputValidation
{
    // Validates the given project request and returns the result.
    public static ValidationResult Validate(ProjectRequest request)
    {
        var result = new ValidationResult();

        // Validate project name and page configuration
        ValidateProjectName(request.ProjectName, result);
        ValidatePageConfiguration(request.PageConfig, result);

        return result;
    }

    // Checks if the project name is valid and adds errors if not.
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

        // Prevent path traversal or invalid folder names
        if (name.Contains(".") || name.Contains("/") || name.Contains("\\"))
        {
            result.AddError("Project name cannot contain '.', '/' or '\' characters.");
        }
    }

    // Checks if the page configuration is valid and adds errors if not.
    private static void ValidatePageConfiguration(PageConfiguration config, ValidationResult result)
    {
        if (config.PageType == Enums.PageType.MultiPage)
        {
            // Multi-page projects must have a positive page count
            if (config.PageCount <= 0)
            {
                result.AddError("Page count must be greater than 0 for multi-page projects.");
            }

            // Limit the number of pages to a maximum
            if (config.PageCount > 5)
            {
                result.AddError("Page count cannot exceed 5.");
            }
        }
    }
}