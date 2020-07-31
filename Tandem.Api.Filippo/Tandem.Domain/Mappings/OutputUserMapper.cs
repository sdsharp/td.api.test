using System.Collections.Generic;
using AutoMapper;
using Tandem.Domain.DTO.Users;
using Tandem.Domain.Exceptions;
using Tandem.Domain.Models;

namespace Tandem.Domain.Mappings
{
    public class OutputUserMapper : Profile
    {
        public OutputUserMapper()
        {
            CreateMap<User, OutputUser>()
                .ForPath(t => t.Name, s => s.MapFrom(m => m.GetFullName()));
        }
    }
}