namespace ProjectGenerator.Core.Domain;

// Represents a file generated as part of a project.
public class GeneratedFile
{
    // The relative path of the file within the project.
    public string Path { get; private set; }
    // The file's content.
    public string Content { get; private set; }

    public GeneratedFile(string path, string content)
    {
        Path = path;
        Content = content;
    }
}