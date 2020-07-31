using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Tandem.Repository.Core;
using Tandem.Repository.EntityFramework;
using Tandem.Repository.EntityFramework.Base;

namespace Tandem.Repository.Registrations
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.TryAddScoped<IContext, TandemContext>();

            services.TryAddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static async Task MigrateDb(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<IContext>();

                await context.Database.MigrateAsync();
            }
        }
    }
}
