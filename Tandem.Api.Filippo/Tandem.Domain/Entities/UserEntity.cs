using System;

namespace Tandem.Domain.Entities
{
    public class UserEntity
    {
        public Guid UserId { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
    }
}
