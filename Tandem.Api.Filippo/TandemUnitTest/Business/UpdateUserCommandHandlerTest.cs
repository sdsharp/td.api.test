using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Tandem.Business.Commands;
using Tandem.Domain.DTO.Users;
using Tandem.Domain.Exceptions;
using Tandem.Domain.Mappings;
using Tandem.Domain.Models;
using Tandem.Repository.EntityFramework;
using Xunit;

namespace TandemUnitTest.Business
{
    public class UpdateUserCommandHandlerTest
    {
        [Fact]
        public async void DuplicatedEmailAddressTest()
        {
            var emailAddress = "mary@elitechildcare.com";
            var command = CreateCommand(Guid.NewGuid());
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(repository => repository.GetUserByEmail(It.IsAny<String>()))
                .Returns(Task.FromResult(new User
                {
                    UserId = Guid.NewGuid(),
                    EmailAddress = emailAddress
                }));

            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<OutputUserMapper>();
                x.AddProfile<UserMapper>();
            }));

            var handler = new UpdateUserCommandHandler(userRepositoryMock.Object, mapper);
            var result = await Assert.ThrowsAsync<TandemValidationException>(async () => await handler.Handle(command, CancellationToken.None));

            Assert.Equal($"Email address '{command.Input.EmailAddress}' is associated with another user.", result.Message);
        }

        [Fact]
        public async void HandleTest()
        {
            var command = CreateCommand(Guid.NewGuid());
            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(repository => repository.UpdateUser(
                        It.Is<User>(user
                            => user.UserId == command.UserId
                               && user.FirstName == command.Input.FirstName
                               && user.MiddleName == command.Input.MiddleName
                               && user.LastName == command.Input.LastName
                               && user.PhoneNumber == command.Input.PhoneNumber
                               && user.EmailAddress == command.Input.EmailAddress)
                    )
                );

            userRepositoryMock
                .Setup(repository => repository.GetUserByEmail(It.IsAny<String>()))
                .Returns(Task.FromResult(new User
                {
                    UserId = command.UserId,
                    EmailAddress = command.Input.EmailAddress
                }));

            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<OutputUserMapper>();
                x.AddProfile<UserMapper>();
            }));

            var handler = new UpdateUserCommandHandler(userRepositoryMock.Object, mapper);
            await handler.Handle(command, CancellationToken.None);

            userRepositoryMock.VerifyAll();
        }

        private static UpdateUserCommand CreateCommand(Guid userId)
        {
            UpdateUserCommand command = new UpdateUserCommand()
            {
                UserId = userId,
                Input = new InputUser
                {
                    FirstName = "Mary",
                    MiddleName = "J",
                    LastName = "Poppins",
                    EmailAddress = "mary@elitechildcare.com",
                    PhoneNumber = "555-555-5555"
                }

            };

            return command;
        }
    }
}