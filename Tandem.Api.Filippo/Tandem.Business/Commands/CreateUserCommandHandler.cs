using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tandem.Domain.DTO.Users;
using Tandem.Domain.Exceptions;
using Tandem.Domain.Models;
using Tandem.Repository.EntityFramework;

namespace Tandem.Business.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, OutputUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, 
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OutputUser> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmail(command.Input.EmailAddress);

            if (user != null)
            {
                throw new TandemValidationException($"Email address '{command.Input.EmailAddress}' already in the system.");
            }

            user = _mapper.Map<User>(command.Input);

            var result = await _userRepository.CreateUser(user);

            return _mapper.Map<OutputUser>(result);
        }
    }
}
