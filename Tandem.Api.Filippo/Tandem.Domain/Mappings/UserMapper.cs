using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Tandem.Domain.DTO.Users;
using Tandem.Domain.Entities;
using Tandem.Domain.Models;

namespace Tandem.Domain.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<InputUser, User>()
                .ForPath(t => t.UserId, s => s.Ignore());
        }
    }
}
