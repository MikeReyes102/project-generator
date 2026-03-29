namespace ProjectGenerator.Core.Pipeline.Results;

// Represents the result of a pipeline stage execution, including success status and errors.
public class PipelineResult
{
    // True if the pipeline stage was successful.
    public bool IsSuccess { get; }

    // List of errors, if any, from the pipeline stage.
    public IReadOnlyList<string> Errors { get; }

    // Private constructor to enforce use of static helpers.
    private PipelineResult(bool isSuccess, IReadOnlyList<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    // Creates a successful pipeline result.
    public static PipelineResult Success()
    {
        return new PipelineResult(true, Array.Empty<string>());
    }

    // Creates a failed pipeline result with the specified errors.
    public static PipelineResult Failure(IEnumerable<string> errors)
    {
        return new PipelineResult(false, errors.ToList());
    }
}