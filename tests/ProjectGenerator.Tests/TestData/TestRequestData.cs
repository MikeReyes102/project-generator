namespace ProjectGenerator.Tests.TestData;

public class TestRequestData
{
    public string ProjectName { get; set; } = "";

    public string PageType { get; set; } = "";

    public int PageCount { get; set; }

    public int ExpectedFileCount { get; set; }

    public bool ShouldSucced { get; set; }

    public string ExpectedErrorContains { get; set; } = "";
}