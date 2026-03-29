

namespace ProjectGenerator.Core.Domain
{
    // Represents a request to generate a new project, including all options.
    public class ProjectRequest
    {
        // The name of the project to generate.
        public string ProjectName { get; set; } = string.Empty;

        // The author's name (optional).
        public string? AuthorName { get; set; }

        // The type of project to generate.
        public Enums.ProjectType ProjectType { get; set; }

        // Whether to include a README file.
        public bool IncludeReadme { get; set; }

        // Page configuration for the project.
        public PageConfiguration PageConfig { get; set; } = new();

        // Additional options for project generation.
        public List<string> Options { get; set; } = new();
    }
}