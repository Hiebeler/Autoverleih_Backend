using Microsoft.EntityFrameworkCore;

namespace Autoverleih_Backend.Db.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public virtual DbSet<User> Users { get; set; } = null!;
}