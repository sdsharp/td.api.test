using Swashbuckle.AspNetCore.Filters;
using Tandem.Domain.DTO.Users;

namespace Tandem.Api.SwaggerExamples
{
    /// <summary>
    /// Provides example data for <see cref="InputUser"/> class.
    /// </summary>
    public class InputUserExample : IExamplesProvider<InputUser>
    {
        /// <summary>
        /// Get example data for <see cref="InputUser"/> class.
        /// </summary>
        /// <returns></returns>
        public InputUser GetExamples()
        {
            return new InputUser
            {
                FirstName = "Mary",
                MiddleName = "J",
                LastName = "Poppins",
                EmailAddress = "mary@elitechildcare.com",
                PhoneNumber = "555-555-5555",
            };
        }
    }
}