using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tandem.Domain.Entities;
using Tandem.Domain.Exceptions;
using Tandem.Domain.Models;
using Tandem.Repository.Core;
using Tandem.Repository.EntityFramework.Base;

namespace Tandem.Repository.EntityFramework
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(IContext context) : base(context)
        {
        }

        public async Task<User> GetUserByEmail(String emailAddress)
        {
            return await Where(e => e.EmailAddress == emailAddress).Select(u => new User
            {
                UserId = u.Id,
                FirstName = u.FirstName,
                MiddleName = u.MiddleName,
                LastName = u.LastName,
                EmailAddress = u.EmailAddress,
                PhoneNumber = u.PhoneNumber
            }).FirstOrDefaultAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            var entity = new UserEntity
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                PhoneNumber = user.PhoneNumber
            };

            Add(entity);
            await SaveChangesAsync();

            user.UserId = entity.Id;
            
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var target = await Where(u => u.Id == user.UserId)
                .FirstOrDefaultAsync();

            if (target == null)
            {
                throw new TandemValidationException($"User ID '{user.UserId}' not found.");
            }

            target.FirstName = user.FirstName;
            target.MiddleName = user.MiddleName;
            target.LastName = user.LastName;
            target.EmailAddress = user.EmailAddress;
            target.PhoneNumber = user.PhoneNumber;


            await SaveChangesAsync();

            return user;
        }
    }
}