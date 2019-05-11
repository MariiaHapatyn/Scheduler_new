using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Models;

namespace Scheduler.DataAccess.Implementation
{
    public partial class SchedulerContext : IdentityDbContext
    {
        public SchedulerContext()
        {
        }

        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>()
                .HasMany(s => s.Schedule)
                .WithOne(g => g.Group);

            modelBuilder.Entity<Room>()
                .HasMany(s => s.Schedule)
                .WithOne(r => r.Room);

            modelBuilder.Entity<Teacher>()
                .HasMany(s => s.Schedule)
                .WithOne(t => t.Teacher);
        }
    }
}
