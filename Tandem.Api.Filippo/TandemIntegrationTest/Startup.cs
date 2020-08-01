using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tandem.Api.Middleware;
using Tandem.Business.Registrations;
using Tandem.Domain.Mappings;
using Tandem.Repository.Core;
using Tandem.Repository.EntityFramework.Base;

namespace TandemIntegrationTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<Startup>();
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(context.ModelState);
                    return result;
                };
            });

            services.AddAutoMapper(typeof(UserMapper).Assembly);
            services.AddBusiness();

            services.AddDbContext<TandemContext>(contextOptionsBuilder =>
            {
                contextOptionsBuilder.UseInMemoryDatabase(databaseName: "TandemContext_database");
            });

            var contextOption = new DbContextOptionsBuilder<TandemContext>()
                .UseInMemoryDatabase(databaseName: "TandemContext_database")
                .Options;

            services.AddScoped<IContext>(provider => new TandemContext(contextOption));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
