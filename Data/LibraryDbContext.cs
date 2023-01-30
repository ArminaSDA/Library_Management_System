using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Library_Management_System.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<AuthorBook> AuthorBooks { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<BookRental> BookRentals { get; set; }
    public DbSet<UserLogin> UserLogins { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<UserLogin>(entity => {
            entity.HasKey(k => k.id);
        });
        
    }
    public IEnumerable<Author> Author { get; internal set; }
  

}
