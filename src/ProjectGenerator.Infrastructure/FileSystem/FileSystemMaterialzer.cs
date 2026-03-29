using ProjectGenerator.Core.Contracts;
using ProjectGenerator.Core.Domain;

namespace ProjectGenerator.Infrastructure.FileSystem;

// Implements IProjectMaterializer to write the generated project to the file system.
public class FileSystemMaterializer : IProjectMaterializer
{
    // Writes the generated project to disk, creating directories and files as needed.
    public async Task MaterializeAsync(
        GeneratedProject project,
        CancellationToken cancellationToken)
    {
        var root = project.Rootpath;

        // Create root directory
        Directory.CreateDirectory(root);

        // Create subdirectories
        foreach (var dir in project.Directories)
        {
            var fullPath = Path.Combine(root, dir.Path);
            Directory.CreateDirectory(fullPath);
        }

        // Create files
        foreach (var file in project.Files)
        {
            var fullPath = Path.Combine(root, file.Path);

            var directory = Path.GetDirectoryName(fullPath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            await File.WriteAllTextAsync(
                fullPath,
                file.Content,
                cancellationToken
            );
        }
    }
}