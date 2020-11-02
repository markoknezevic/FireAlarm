using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FireAlarm.Data;
using FireAlarm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireAlarm.Data
{
    public class FireAlarmDbContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Alarm> Alarms { get; set; }

        public FireAlarmDbContext(DbContextOptions<FireAlarmDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is ITimestampable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((ITimestampable)entity.Entity).CreatedAt = DateTime.UtcNow;
                }

                ((ITimestampable)entity.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}