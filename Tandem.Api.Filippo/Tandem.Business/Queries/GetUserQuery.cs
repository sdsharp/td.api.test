using MediatR;
using Tandem.Domain.DTO.Users;

namespace Tandem.Business.Queries
{
    public class GetUserQuery : IRequest<OutputUser>
    {
        public UserQuery Query { get; set; }
    }
}