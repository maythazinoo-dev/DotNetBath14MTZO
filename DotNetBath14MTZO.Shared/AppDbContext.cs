using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBath14MTZO.Shared;

public class AppDbContext : DbContext
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;


    public AppDbContext()
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "WalletDB",
            UserID = "sa",
            Password = "mtzoo@123",
            TrustServerCertificate = true
        };

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
        }
    }

    public DbSet<BlogModel> Blogs { get; set; }
}
