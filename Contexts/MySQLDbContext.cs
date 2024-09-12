using Microsoft.EntityFrameworkCore;
using nheejods.Models;

namespace nheejods.Contexts;

public class MySQLDbContext : DbContext
{
    public MySQLDbContext(DbContextOptions<MySQLDbContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<FinanceBox> FinanceBoxs { get; set; }
    public DbSet<FinanceItem> FinanceItems { get; set; }
}
