using FluentValidation;
using Tandem.Domain.DTO.Users;

namespace Tandem.Api.Validations
{
    public class UserQueryValidator : AbstractValidator<UserQuery>
    {
        public UserQueryValidator()
        {
            RuleFor(practice => practice.EmailAddress).NotEmpty();
            RuleFor(practice => practice.EmailAddress).EmailAddress();
        }
    }
}