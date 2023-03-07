using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_day2.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<news_details> news_Detailss { get; set; }
        public DbSet<author> authors { get; set; }
        public DbSet<news> newss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source =.\sqlexpress; database = testSystem; integrated security = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<news>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.name).HasMaxLength(50);
                   
            });

        }
    }
}