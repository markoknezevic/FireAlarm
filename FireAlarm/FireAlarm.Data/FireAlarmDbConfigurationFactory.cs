using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExerciseTracker.Data
{
    public class FireAlarmDbConfigurationFactory : IDesignTimeDbContextFactory<FireAlarmDbContext>
    {
        public FireAlarmDbContext CreateDbContext(string[] args)
        {
            var dbContextConfiguration = new FireAlarmDbContextConfiguration();
            var dbContextBuilder = new DbContextOptionsBuilder<FireAlarmDbContext>();
            dbContextBuilder.UseNpgsql(dbContextConfiguration.ConnectionString); 
            return new FireAlarmDbContext(dbContextBuilder.Options);
        }
    }
}