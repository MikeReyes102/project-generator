namespace ProjectGenerator.Core.Domain;

// Represents a project template, including its files and directories.
public class ProjectTemplate
{
    // The name of the template.
    public string Name { get; private set; }

    // List of file templates for the project.
    public List<TemplateFile> Files { get; private set; } = new();

    // List of directory names for the project.
    public List<string> Directories { get; private set; } = new();

    public ProjectTemplate(string name)
    {
        Name = name;
    }

    // Adds a file template to the project template.
    public void AddFile(TemplateFile file)
    {
        Files.Add(file);
    }

    // Adds a directory to the project template.
    public void AddDirectory(string directory)
    {
        Directories.Add(directory);
    }
}