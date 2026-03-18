

namespace ProjectGenerator.Core.Domain
{
    public class ProjectRequest
    {
        public string ProjectName { get; set; } = string.Empty;

        public string? AuthorName { get; set; }

        public Enums.ProjectType ProjectType { get; set; }

        public bool IncludeReadme { get; set; }

        public PageConfiguration PageConfig { get; set; } = new();

        public List<string> Options { get; set; } = new();
    }
}