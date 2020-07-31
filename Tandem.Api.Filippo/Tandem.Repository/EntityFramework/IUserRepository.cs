using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tandem.Domain.Models;

namespace Tandem.Repository.EntityFramework
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(String emailAddress);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
    }

}
