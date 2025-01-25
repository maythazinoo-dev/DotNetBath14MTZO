using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.BurmaProject.Shared
{
    public class AppDbContext : DbContext
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;
        public AppDbContext()
        {
            _connectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "EmojisDB",
                UserID = "sa",
                Password = "mtzoo@123",
                TrustServerCertificate = true
            };

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
       
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionStringBuilder.ConnectionString);
            }
        }

        public DbSet<BurmaProjectModel> burmaProjectModel { get; set; }
        public DbSet<GroupData> groupData { get; set; }
    }
  
}
