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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, OutputUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<OutputUser> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetUserByEmail(command.Input.EmailAddress);

            if (user != null
                && user.UserId != command.UserId)
            {
                throw new TandemValidationException($"Email address '{command.Input.EmailAddress}' is associated with another user.");
            }

            user = _mapper.Map<User>(command.Input);
            user.UserId = command.UserId;

            var result = await _userRepository.UpdateUser(user);

            return _mapper.Map<OutputUser>(result);
        }
    }
}