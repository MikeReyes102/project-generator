namespace ProjectGenerator.Core.Domain;

// Holds configuration for the type and number of pages in a project.
public class PageConfiguration
{
    // The type of pages (single or multi-page).
    public Enums.PageType PageType { get; set; }

    // The number of pages (used for multi-page projects).
    public int PageCount { get; set; }
}