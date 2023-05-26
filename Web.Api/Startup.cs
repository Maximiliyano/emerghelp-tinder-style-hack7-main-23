using Microsoft.EntityFrameworkCore;
using Web.DAL.Context;

namespace Web.Api;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var migrationAssembly = typeof(WebDatabaseContext).Assembly.GetName().Name;
        services.AddDbContext<WebDatabaseContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DbConnection"),
                opt => opt.MigrationsAssembly(migrationAssembly)));
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseSwaggerUI();
            
        app.UseEndpoints(cfg =>
        {
            cfg.MapControllers();
        });
        
        InitializeDatabase(app);
    }
    
    private static void InitializeDatabase(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices
            .GetService<IServiceScopeFactory>()?
            .CreateScope();

        using var context = scope?.ServiceProvider
            .GetRequiredService<WebDatabaseContext>();

        context?.Database.Migrate();
    }
}