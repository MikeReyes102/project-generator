namespace ProjectGenerator.Core.Domain;

public class ProjectTemplate
{
    public string Name { get; private set; }

    public List<TemplateFile> Files { get; private set; } = new();

    public List<string> Directories { get; private set; } = new();

    public ProjectTemplate(string name)
    {
        Name = name;
    }

    public void AddFile(TemplateFile file)
    {
        Files.Add(file);
    }

    public void AddDirectory(string directory)
    {
        Directories.Add(directory);
    }
}