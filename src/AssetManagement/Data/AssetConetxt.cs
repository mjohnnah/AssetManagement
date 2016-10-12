using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Models;

namespace AssetManagement.Data
{
    public class AssetConetxt : DbContext
    {
        public AssetConetxt(DbContextOptions<AssetConetxt> options) :base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Assignment> Assigments { get; set; }
        public DbSet<Assignee> Assignees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>().ToTable("Asset");
            modelBuilder.Entity<Assignee>().ToTable("Assignee");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
        }

    }
}
