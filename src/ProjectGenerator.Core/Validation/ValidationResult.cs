namespace ProjectGenerator.Core.Validation;

public class ValidationResult
{
    public bool IsValid => !Errors.Any();

    public List<string> Errors { get; private set; } = new();

    public void AddError(string error)
    {
        Errors.Add(error);
    }
}