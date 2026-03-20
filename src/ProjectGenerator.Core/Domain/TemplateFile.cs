namespace ProjectGenerator.Core.Domain;

public class TemplateFile
{
    public string Path { get; private set; }

    public string ContentTemplate { get; private set; }

    public TemplateFile(string path, string contentTemplate)
    {
        Path = path;
        ContentTemplate = contentTemplate;
    }
}