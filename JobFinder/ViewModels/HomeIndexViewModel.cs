using JobFinder.Models;

namespace JobFinder.ViewModels;

public class HomeIndexViewModel
{
    public string SearchTerm { get; set; } = string.Empty;

    public IReadOnlyList<Job> Jobs { get; set; } = Array.Empty<Job>();

    public IReadOnlyList<Job> FeaturedJobs { get; set; } = Array.Empty<Job>();
}
