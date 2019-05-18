using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scheduler.DataAccess.Models;
using System;

namespace Scheduler.DataAccess.Implementation
{
    public partial class SchedulerContext : IdentityDbContext
    {
        public SchedulerContext(DbContextOptions<SchedulerContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

    }
}
