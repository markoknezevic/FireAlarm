using FireAlarm.API.Helpers;
using FireAlarm.Data;
using FireAlarm.DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FireAlarm.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new Configuration.Configuration();
            Configuration.Bind(configuration);
            
            var dbContextConfiguration = new FireAlarmDbContextConfiguration(Configuration);
            
            services.AddSingleton(configuration);
            
            services.AddControllers();
            services.AddDbContext<FireAlarmDbContext>(options => options.UseNpgsql(dbContextConfiguration.ConnectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MailSender>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}