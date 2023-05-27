using VolonteerHelper.Api.Services;

namespace VolonteerHelper.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterCustomServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
        }
    }
}