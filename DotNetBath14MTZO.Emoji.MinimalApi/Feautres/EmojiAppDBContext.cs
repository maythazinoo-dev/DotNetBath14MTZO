using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DotNetBath14MTZO.Emoji.MinimalApi.Feautres
{
    public class EmojiAppDBContext : DbContext
    {
        private readonly SqlConnectionStringBuilder _connectionStringBuilder;
        public EmojiAppDBContext()
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


        public DbSet<EmojiModel> EmojiModels { get; set; }
    }
}

