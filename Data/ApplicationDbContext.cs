using FilesAPI.Models;
using FilesAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilesAPI.Data;

public class ApplicationDbContext : DbContext
{
      public ApplicationDbContext (DbContextOptions <ApplicationDbContext> options):base(options)
    {
    }
     public DbSet<FileModel> Files { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
}
