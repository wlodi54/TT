using CHK.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CHK.Infrastructure
{
    public class WriteContext : DbContext
    {
        public WriteContext(DbContextOptions<WriteContext> options) :base(options)
        {

        }

        public DbSet<Device> Device { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<InfoTemplate> InfoTemplate { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Info>(Info => Info.HasOne(i => i.Data));
            modelBuilder.Entity<Info>(Info => Info.HasOne(i => i.Device));

            base.OnModelCreating(modelBuilder);
        }
    }
}
