using ProjectGenerator.Core.Domain;

namespace ProjectGenerator.Core.Contracts;

// Defines a contract for providing project templates based on a request.
public interface ITemplateProvider
{
    // Returns a project template for the given request.
    ProjectTemplate GetTemplate(ProjectRequest request);
}