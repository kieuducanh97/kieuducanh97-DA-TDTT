using JobFinder.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Controllers;

public class JobController : Controller
{
    private readonly JobFinderDbContext _context;

    public JobController(JobFinderDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string? searchTerm)
    {
        return RedirectToAction("Index", "Home", new { searchTerm });
    }

    public async Task<IActionResult> Details(int id)
    {
        var job = await _context.Jobs.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        if (job is null)
        {
            return NotFound();
        }

        return View(job);
    }
}
