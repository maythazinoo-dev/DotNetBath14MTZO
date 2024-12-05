using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZOPractce.ConsoleApp.EFCorePractices
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppDbSetting.SqlConnectionStringBuilder.ConnectionString);
            }
        }



        public DbSet<Tbl_Blog> TableBlog { get; set; }
    }

        [Table("Tbl_Blog")]
        public class Tbl_Blog
        {
        [Column("BlogId")]
        public string id { get; set; }
        [Column("BlogTitle")]
        public string title { get; set; }
        [Column("BlogAuthor")]
        public string author {  get; set; }
        [Column("BlogContent")]
        public string content { get; set; }
    }
}
