namespace ProjectGenerator.Core.Domain;

// Represents a fully generated project, including files and directories.
public class GeneratedProject
{
    // The name of the project.
    public string ProjectName { get; private set; }
    // The root output path for the project.
    public string Rootpath { get; private set; }
    // List of generated files.
    public List<GeneratedFile> Files { get; private set; } = new();
    // List of generated directories.
    public List<GeneratedDirectory> Directories { get; private set; } = new();

    public GeneratedProject(string projectName, string rootpath)
    {
        ProjectName = projectName;
        Rootpath = rootpath;
    }

    // Adds a file to the project.
    public void AddFile(GeneratedFile file)
    {
        Files.Add(file);
    }

    // Adds a directory to the project.
    public void AddDirectory(GeneratedDirectory directory)
    {
        Directories.Add(directory);
    }
}