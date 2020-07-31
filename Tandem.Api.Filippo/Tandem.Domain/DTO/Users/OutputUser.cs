using System;

namespace Tandem.Domain.DTO.Users
{
    public class OutputUser
    {
        public Guid UserId { get; set; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public String EmailAddress { get; set; }
    }
}
