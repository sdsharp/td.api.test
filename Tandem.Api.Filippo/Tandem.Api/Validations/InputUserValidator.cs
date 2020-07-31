﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Tandem.Domain.DTO.Users;

namespace Tandem.Api.Validations
{
    public class InputUserValidator : AbstractValidator<InputUser>
    {
        public InputUserValidator()
        {
            RuleFor(practice => practice.FirstName).NotEmpty();
            RuleFor(practice => practice.LastName).NotEmpty();
            RuleFor(practice => practice.MiddleName).NotEmpty();
            RuleFor(practice => practice.PhoneNumber).NotEmpty();

            RuleFor(practice => practice.EmailAddress).NotEmpty();
            RuleFor(practice => practice.EmailAddress).EmailAddress();
        }
    }
}
