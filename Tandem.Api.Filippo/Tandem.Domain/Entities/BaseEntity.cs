using System;

namespace Tandem.Domain.Entities
{
    public abstract class BaseEntity : IEntity<Guid>
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
    }
}