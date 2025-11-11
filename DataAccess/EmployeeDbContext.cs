using Core;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class EmployeeDbContext : DbContext
{
  public DbSet<Employee> Employees { get; set; }

  public DbSet<WorkingPlan> WorkingPlan { get; set; }

  public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    base.OnModelCreating(modelBuilder);
  }
}
