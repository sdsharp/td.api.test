using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Tandem.Repository.Registrations;

namespace Tandem.Business.Registrations
{
    public static class BusinessRegistration
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddRepository();

            services.AddMediatR(typeof(BusinessRegistration));

            return services;
        }

        public static async Task MigrateDb(IApplicationBuilder app)
        {
            await RepositoryRegistration.MigrateDb(app);
        }
    }
}
