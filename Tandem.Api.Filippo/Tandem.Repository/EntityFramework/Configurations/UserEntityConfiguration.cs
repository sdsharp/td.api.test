using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tandem.Domain.Entities;
using Tandem.Repository.EntityFramework.Configurations.Base;

namespace Tandem.Repository.EntityFramework.Configurations
{
    public class UserEntityConfiguration : ConfigurationBase<UserEntity>
    {
        public override void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            base.Configure(builder);
            builder.Property(i => i.FirstName).IsRequired();
            builder.Property(i => i.MiddleName);
            builder.Property(i => i.LastName).IsRequired();
            builder.Property(i => i.PhoneNumber).IsRequired();
            builder.Property(i => i.EmailAddress).IsRequired();
            builder.Property(i => i.Created).IsRequired();

            builder.HasIndex(i => i.EmailAddress).IsUnique();
        }
    }
}
