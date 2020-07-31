using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tandem.Domain.DTO.Users;

namespace Tandem.Business.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OutputUser>
    {
        public async Task<OutputUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return new OutputUser();
        }
    }
}
