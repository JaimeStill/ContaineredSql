using ContaineredSql.Models;
using Microsoft.EntityFrameworkCore;

namespace ContaineredSql.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
}