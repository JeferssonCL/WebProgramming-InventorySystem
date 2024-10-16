using Backend.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application
{
    public static class ApplicationConfiguration
    {

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));
            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(UserProfile).Assembly)
        );
        }
    }
}