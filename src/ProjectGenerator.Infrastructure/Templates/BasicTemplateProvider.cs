using ProjectGenerator.Core.Contracts;
using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Enums;

namespace ProjectGenerator.Infrastructure.Templates;

// Provides a basic frontend project template (HTML/CSS/JS) based on the request.
public class BasicTemplateProvider : ITemplateProvider
{
    // Returns a project template for a basic frontend project.
    public ProjectTemplate GetTemplate(ProjectRequest request)
    {
        var template = new ProjectTemplate("Basic Frontend");

        // Add base directories
        template.AddDirectory("styles");
        template.AddDirectory("scripts");

        // Add base files
        template.AddFile(new TemplateFile(
            "index.html",
            "<html><head><title>{{ProjectName}}</title></head><body><h1>Welcome</h1></body></html>"
        ));

        template.AddFile(new TemplateFile(
            "styles/base.css",
            "body { margin: 0; font-family: Arial; }"
        ));

        template.AddFile(new TemplateFile(
            "scripts/main.js",
            "console.log('App initialized');"
        ));

        // Add multi-page support if requested
        if (request.PageConfig.PageType == PageType.MultiPage)
        {
            template.AddDirectory("pages");

            for (int i = 1; i <= request.PageConfig.PageCount; i++)
            {
                template.AddFile(new TemplateFile(
                    $"pages/page{i}.html",
                    $"<html><body><h1>Page {i}</h1></body></html>"
                ));
            }
        }

        return template;
    }
}