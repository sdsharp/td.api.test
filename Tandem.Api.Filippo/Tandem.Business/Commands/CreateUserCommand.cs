using MediatR;
using Tandem.Domain.DTO.Users;

namespace Tandem.Business.Commands
{
    public class CreateUserCommand : IRequest<OutputUser>
    {
        public InputUser Input { get; set; }
    }
}