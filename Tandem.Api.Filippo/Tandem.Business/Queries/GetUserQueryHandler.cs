using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tandem.Business.Commands;
using Tandem.Domain.DTO.Users;
using Tandem.Repository.EntityFramework;

namespace Tandem.Business.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, OutputUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OutputUser> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetUserByEmail(request.Query.EmailAddress);

            return _mapper.Map<OutputUser>(result);
        }
    }
}
