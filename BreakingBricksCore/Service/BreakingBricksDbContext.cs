using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BreakingBricksCore.Entity;

namespace BreakingBricksCore.Service
{
    public class BreakingBricksDbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BreakingBricks;Trusted_Connection=True;");
        }
    }

}
