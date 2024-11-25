using CourseProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Data
{
    public class CourseProjectDbContext : DbContext
    {
        public DbSet<SensorMail> Sensors { get; set; }
        public DbSet<SensorMailCheck> SensorValues { get; set; }
        public DbSet<BackgroundImage> BackgroundImages { get; set; }

        public CourseProjectDbContext(DbContextOptions<CourseProjectDbContext> options)
            :base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SensorMail>()
                .HasMany(e => e.SensorValues)
                .WithOne(v => v.Sensor)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}