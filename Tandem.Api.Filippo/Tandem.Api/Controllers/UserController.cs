using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tandem.Domain.DTO.Users;

namespace Tandem.Api.Controllers
{
    /// <summary>
    /// Manages the endpoints for User features.
    /// </summary>
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Creates a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger"></param>
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <returns>Returns the created user.</returns>
        [HttpPost]
        public OutputUser Post([FromBody] InputUser request)
        {
            return new OutputUser();
        }

        /// <summary>
        /// Gets user by email.
        /// </summary>
        /// <returns>Returns the found user.</returns>
        [HttpGet("{emailAddress}")]
        public OutputUser Get([FromRoute] String emailAddress)
        {
            var result = new OutputUser();
            return result;
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <returns>Returns the updated user.</returns>
        [HttpPut]
        public OutputUser Put([FromRoute] Guid userId, [FromBody] InputUser request)
        {
            return new OutputUser();
        }
    }
}
