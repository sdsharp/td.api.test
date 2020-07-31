using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tandem.Business.Commands;
using Tandem.Domain.DTO.Users;

namespace Tandem.Business.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, OutputUser>
    {
        public async Task<OutputUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return new OutputUser();
        }
    }
}
