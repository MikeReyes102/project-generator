using ProjectGenerator.Core.Domain;

namespace ProjectGenerator.Core.Contracts;

public interface IProjectMaterializer
{
    Task MaterializeAsync(
        GeneratedProject project,
        CancellationToken cancellationToken);
}