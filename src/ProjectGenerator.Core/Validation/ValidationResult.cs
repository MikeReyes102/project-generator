namespace ProjectGenerator.Core.Validation;

// Represents the result of a validation operation, including any errors found.
public class ValidationResult
{
    // True if there are no errors.
    public bool IsValid => !Errors.Any();

    // List of validation errors.
    public List<string> Errors { get; private set; } = new();

    // Adds an error message to the result.
    public void AddError(string error)
    {
        Errors.Add(error);
    }
}