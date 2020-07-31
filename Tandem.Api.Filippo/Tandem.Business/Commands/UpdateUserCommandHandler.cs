using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tandem.Domain.DTO.Users;

namespace Tandem.Business.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, OutputUser>
    {
        public async Task<OutputUser> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return new OutputUser();
        }
    }
}