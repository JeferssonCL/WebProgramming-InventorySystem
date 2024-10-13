using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application{
    public static class ApplicationConfiguration{

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationProfile));
        }
    }
}