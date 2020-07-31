using Tandem.Domain.Exceptions;
using Tandem.Domain.Models;
using Xunit;

namespace TandemUnitTest.Domain.Extensions
{
    public class UserExtensionTest
    {
        [Fact]
        public void GetFullNameWithMiddleNameTest()
        {
            var user = new User
            {
                FirstName = "FirstName",
                MiddleName = "MiddleName",
                LastName = "LastName"
            };

            Assert.Equal("FirstName MiddleName LastName", user.GetFullName());
        }

        [Fact]
        public void GetFullNameWithoutMiddleNameTest()
        {
            var user = new User
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };

            Assert.Equal("FirstName LastName", user.GetFullName());
        }
    }
}
