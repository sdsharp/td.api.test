using System;

namespace Tandem.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
    }
}
