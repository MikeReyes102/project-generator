namespace ProjectGenerator.Core.Domain;

// Represents a file template used to generate a file in a project.
public class TemplateFile
{
    // The relative path where the file will be generated.
    public string Path { get; private set; }

    // The template content for the file (may include placeholders).
    public string ContentTemplate { get; private set; }

    public TemplateFile(string path, string contentTemplate)
    {
        Path = path;
        ContentTemplate = contentTemplate;
    }
}