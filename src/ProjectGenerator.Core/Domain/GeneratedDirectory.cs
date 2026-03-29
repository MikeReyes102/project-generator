namespace ProjectGenerator.Core.Domain;

// Represents a directory generated as part of a project.
public class GeneratedDirectory
{
    // The relative path of the directory within the project.
    public string Path { get; private set; }

    public GeneratedDirectory(string path)
    {
        Path = path;
    }
}