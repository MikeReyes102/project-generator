namespace ProjectGenerator.Core.Domain;

public class GeneratedProject
{
    public string ProjectName { get; private set; }
    public string Rootpath { get; private set; }
    public List<GeneratedFile> Files { get; private set; } = new();
    public List<GeneratedDirectory> Directories { get; private set; } = new();
    public GeneratedProject(string projectName, string rootpath)
    {
        ProjectName = projectName;
        Rootpath = rootpath;
    }

    public void AddFile(GeneratedFile file)
    {
        Files.Add(file);
    }

    public void AddDirectory(GeneratedDirectory directory)
    {
        Directories.Add(directory);
    }
}