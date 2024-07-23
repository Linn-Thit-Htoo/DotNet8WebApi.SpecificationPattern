using DotNet8WebApi.SpecificationPattern.Api.Features.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNet8WebApi.SpecificationPattern.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, WebApplicationBuilder builder)
        {
            return services.AddDbContextService(builder)
                .AddGenericRepositoryService()
                .AddBLService();
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient);

            return services;
        }

        private static IServiceCollection AddGenericRepositoryService(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        private static IServiceCollection AddBLService(this IServiceCollection services)
        {
            return services.AddScoped<BL_Blog>();
        }
    }
}
