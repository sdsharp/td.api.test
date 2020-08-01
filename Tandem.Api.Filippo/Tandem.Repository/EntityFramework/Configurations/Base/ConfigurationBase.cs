using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tandem.Domain.Entities;

namespace Tandem.Repository.EntityFramework.Configurations.Base
{
    public abstract class ConfigurationBase<T> : IEntityTypeConfiguration<T>, IEntityConfiguration where T : class, IEntity
    {
        public void AddConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(this);
        }

        protected String GetEntityName()
        {
            return typeof(T).Name.Replace("Entity", "");
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(GetEntityName());
            CustomConfigure(builder);
        }

        public virtual void CustomConfigure(EntityTypeBuilder<T> builder)
        {
        }
    }
}