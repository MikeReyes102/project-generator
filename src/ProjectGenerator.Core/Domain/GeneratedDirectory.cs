namespace ProjectGenerator.Core.Domain;

public class GeneratedDirectory
{
    public string Path { get; private set; }

    public GeneratedDirectory(string path)
    {
        Path = path;
    }
}