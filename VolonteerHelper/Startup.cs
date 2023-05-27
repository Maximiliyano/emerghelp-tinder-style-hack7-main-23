using Microsoft.EntityFrameworkCore;
using VolonteerHelper.Api.Context;
using VolonteerHelper.Api.Extensions;

namespace VolonteerHelper.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            var migrationAssembly = typeof(VolonteerDbContext).Assembly.GetName().Name;
            services.AddDbContext<VolonteerDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DbConnection"),
                    opt => opt.MigrationsAssembly(migrationAssembly)));

            services.RegisterCustomServices();

            services.AddControllers();
            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithOrigins("https://localhost:5001");
                });
            });
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllers();
            });
        }
    }
}