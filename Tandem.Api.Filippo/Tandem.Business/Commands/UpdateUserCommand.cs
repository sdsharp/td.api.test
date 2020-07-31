using System;
using MediatR;
using Tandem.Domain.DTO.Users;

namespace Tandem.Business.Commands
{
    public class UpdateUserCommand : IRequest<OutputUser>
    {
        public Guid UserId { get; set; }
        public InputUser Input { get; set; }
    }
}