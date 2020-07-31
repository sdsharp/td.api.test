using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Filters;
using Tandem.Domain.DTO.Users;

namespace Tandem.Api.SwaggerExamples
{
    /// <summary>
    /// Provides example data for <see cref="OutputUser"/> class.
    /// </summary>
    public class OutputUserExample : IExamplesProvider<OutputUser>
    {
        /// <summary>
        /// Get example data for <see cref="OutputUser"/> class.
        /// </summary>
        /// <returns></returns>
        public OutputUser GetExamples()
        {
            return new OutputUser
            {
                UserId = Guid.Empty,
                Name = "Mary J Poppins",
                EmailAddress = "mary@elitechildcare.com",
                PhoneNumber = "555-555-5555"
            };
        }
    }
}
