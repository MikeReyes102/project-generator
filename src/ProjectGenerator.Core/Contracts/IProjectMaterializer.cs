using ProjectGenerator.Core.Domain;

namespace ProjectGenerator.Core.Contracts;

// Defines a contract for materializing (writing) a generated project to an output (e.g., file system).
public interface IProjectMaterializer
{
    // Materializes the generated project using the provided output mechanism.
    Task MaterializeAsync(
        GeneratedProject project,
        CancellationToken cancellationToken);
}