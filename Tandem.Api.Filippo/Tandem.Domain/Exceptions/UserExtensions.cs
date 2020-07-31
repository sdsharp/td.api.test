using System;
using Tandem.Domain.Models;

namespace Tandem.Domain.Exceptions
{
    public static class UserExtensions
    {
        public static String GetFullName(this User user)
        {
            var middleName = !String.IsNullOrWhiteSpace(user.MiddleName)
                ? $" {user.MiddleName}"
                : String.Empty;

            return $"{user.FirstName}{middleName} {user.LastName}";
        }
    }
}