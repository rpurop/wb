using Microsoft.EntityFrameworkCore;

namespace WBTask.Models;

public class WBTaskContext : DbContext
{
    public WBTaskContext(DbContextOptions<WBTaskContext> options)
        : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserRole> UserRoles {get; set;} = null!;
    public DbSet<Task> Tasks {get;set;} = null!;
    public DbSet<Step> Steps {get;set;} = null!;
    public DbSet<Process> Processes {get;set;} = null!;
    public DbSet<Package> Packages {get;set;} = null!;
    public DbSet<PackageVersion> PackageVersions {get; set;}
    public DbSet<Log> Logs {get; set;}

}