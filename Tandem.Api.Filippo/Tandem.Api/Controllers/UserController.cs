using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tandem.Business.Commands;
using Tandem.Business.Queries;
using Tandem.Domain.DTO.Users;
using Tandem.Domain.Exceptions;

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
        private readonly IMediator _mediator;

        /// <summary>
        /// Creates a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public UserController(ILogger<UserController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <returns>Returns the created user.</returns>
        [HttpPost]
        public async Task<OutputUser> Post([FromBody] InputUser request)
        {
            var command = new CreateUserCommand
            {
                Input = request
            };

            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Gets user by email.
        /// </summary>
        /// <returns>Returns the found user.</returns>
        [HttpGet]
        public async Task<OutputUser> Get([FromQuery]UserQuery request)
        {
            var command = new GetUserQuery()
            {
                Query = request
            };

            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <returns>Returns the updated user.</returns>
        [HttpPut]
        public async Task<OutputUser> Put(Guid userId, [FromBody] InputUser request)
        {
            var command = new UpdateUserCommand()
            {
                UserId = userId,
                Input = request
            };

            var result = await _mediator.Send(command);

            return result;
        }
    }
}
