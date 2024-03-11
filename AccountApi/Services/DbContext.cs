using Microsoft.EntityFrameworkCore;

namespace AccountAPI;

public class AccountDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=accounts.db");
    }
}

