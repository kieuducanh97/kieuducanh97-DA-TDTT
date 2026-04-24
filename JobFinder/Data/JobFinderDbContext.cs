using JobFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace JobFinder.Data;

public class JobFinderDbContext : DbContext
{
    public JobFinderDbContext(DbContextOptions<JobFinderDbContext> options)
        : base(options)
    {
    }

    public DbSet<Job> Jobs => Set<Job>();

    public DbSet<User> Users => Set<User>();
}
