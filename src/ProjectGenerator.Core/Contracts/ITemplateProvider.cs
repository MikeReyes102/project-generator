using ProjectGenerator.Core.Domain;

namespace ProjectGenerator.Core.Contracts;

public interface ITemplateProvider
{
    ProjectTemplate GetTemplate(ProjectRequest request);
}