using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetBath14MTZO.SnakesAndLadderGame.Features
{
    public class AppDbContext : DbContext
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public AppDbContext()
        {
            _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "SnakesAndLaddersDB",
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


        public DbSet<PlayerModel> gamePlayer { get; set; }
        public DbSet<BoardModel> gameBoard { get; set; }
        public DbSet<GameMoveModel> gameMove { get; set; }
        public DbSet<GameModel> game { get; set; }

    }
}
