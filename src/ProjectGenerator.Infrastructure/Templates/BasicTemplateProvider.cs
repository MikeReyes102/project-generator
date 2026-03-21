using ProjectGenerator.Core.Contracts;
using ProjectGenerator.Core.Domain;
using ProjectGenerator.Core.Enums;

namespace ProjectGenerator.Infrastructure.Templates;

public class BasicTemplateProvider : ITemplateProvider
{
    public ProjectTemplate GetTemplate(ProjectRequest request)
    {
        var template = new ProjectTemplate("Basic Frontend");

        // Base structure
        template.AddDirectory("styles");
        template.AddDirectory("scripts");

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

        // Multi-page support (based on request)
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