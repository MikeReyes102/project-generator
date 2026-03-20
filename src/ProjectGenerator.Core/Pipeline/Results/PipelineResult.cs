namespace ProjectGenerator.Core.Pipeline.Results;

public class PipelineResult
{
    public bool IsSuccess { get; }

    public IReadOnlyList<string> Errors { get; }

    private PipelineResult(bool isSuccess, IReadOnlyList<string> errors)
    {
        IsSuccess = isSuccess;
        Errors = errors;
    }

    public static PipelineResult Success()
    {
        return new PipelineResult(true, Array.Empty<string>());
    }

    public static PipelineResult Failure(IEnumerable<string> errors)
    {
        return new PipelineResult(false, errors.ToList());
    }
}