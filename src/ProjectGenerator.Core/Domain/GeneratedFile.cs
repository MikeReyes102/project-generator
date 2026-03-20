namespace ProjectGenerator.Core.Domain;

public class GeneratedFile
{
    public string Path { get; private set; }
    public string Content { get; private set; }
    public GeneratedFile(string path, string content)
    {
        Path = path;
        Content = content;
    }
}