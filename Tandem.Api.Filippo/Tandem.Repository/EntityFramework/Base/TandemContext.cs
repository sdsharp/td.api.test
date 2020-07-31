using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tandem.Repository.Core;
using Tandem.Repository.EntityFramework.Configurations.Base;

namespace Tandem.Repository.EntityFramework.Base
{
    public class TandemContext : DbContext, IContext
    {
        private readonly IConfiguration _configuration;

        public TandemContext()
        {
        }

        public TandemContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("TandemDatabase")
                                   ?? "Data Source=(local);Initial Catalog=BayManager;Integrated Security=SSPI;"; // to support Update-Database

            optionsBuilder.UseSqlServer(connectionString);
        }

        public Task<int> SaveChangesAsync()
        {
            return this.SaveChangesAsync(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var type = typeof(IEntityConfiguration);

            var configurations = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass)
                .Where(p => !p.IsAbstract)
                .Where(p => type.IsAssignableFrom(p))
                .Select(t => Activator.CreateInstance(t) as IEntityConfiguration);

            foreach (var configuration in configurations)
            {
                configuration?.AddConfiguration(modelBuilder);
            }
        }
    }
}