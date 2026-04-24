using System.Diagnostics;
using JobFinder.Data;
using JobFinder.Models;
using JobFinder.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Controllers;

public class HomeController : Controller
{
    private readonly JobFinderDbContext _context;

    public HomeController(JobFinderDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? searchTerm)
    {
        var query = _context.Jobs.AsNoTracking().OrderByDescending(job => job.PostedDate).AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            query = query.Where(job =>
                job.Title.Contains(searchTerm) ||
                job.Description.Contains(searchTerm) ||
                job.Company.Contains(searchTerm));
        }

        var jobs = await query.ToListAsync();
        var featuredJobs = jobs.Take(3).ToList();

        var viewModel = new HomeIndexViewModel
        {
            SearchTerm = searchTerm ?? string.Empty,
            Jobs = jobs,
            FeaturedJobs = featuredJobs
        };

        return View(viewModel);
    }

    [Route("Home/NotFound")]
    public IActionResult NotFoundPage()
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        return View("NotFound");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
