using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureAPI.Models;

namespace TemperatureAPI.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        public DbSet<Measurement> Measurements { get; set; }

        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Location>().HasKey(l => l.Name);

            builder.Entity<Measurement>().HasOne(m=>m.Location).WithMany(l=>l.Measurements).HasForeignKey(m => m.LocationName);
            builder.Entity<Measurement>().HasIndex(m => m.Time);
        }

        public DbSet<User> Users { get; set; }
    }
}
