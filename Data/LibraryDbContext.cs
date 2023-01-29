using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
}
