using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tandem.Domain.Entities;

namespace Tandem.Repository.EntityFramework.Configurations.Base
{
    public abstract class ConfigurationBaseGuid<T> : ConfigurationBase<T>, IEntityConfiguration where T : BaseEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);
            builder.Property(s => s.Id).HasColumnName($"{GetEntityName()}ID");
        }
    }
}