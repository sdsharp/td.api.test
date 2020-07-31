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
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async void DuplicatedEmailAddressTest()
        {
            var emailAddress = "mary@elitechildcare.com";

            var command = CreateCommand();

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(repository => repository.GetUserByEmail(It.IsAny<String>()))
                .Returns(Task.FromResult(new User
                {
                    EmailAddress = emailAddress
                }));

            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<OutputUserMapper>();
                x.AddProfile<UserMapper>();
            }));

            var handler = new CreateUserCommandHandler(userRepositoryMock.Object, mapper);

            var result = await Assert.ThrowsAsync<TandemValidationException>(async () => await handler.Handle(command, CancellationToken.None));

            Assert.Equal($"Email address '{emailAddress}' already in the system.", result.Message);
        }

        [Fact]
        public async void HandleTest()
        {
            var command = CreateCommand();

            var userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock
                .Setup(repository => repository.CreateUser(
                        It.Is<User>(user
                            => user.FirstName == command.Input.FirstName
                               && user.MiddleName == command.Input.MiddleName
                               && user.LastName == command.Input.LastName
                               && user.PhoneNumber == command.Input.PhoneNumber
                               && user.EmailAddress == command.Input.EmailAddress)
                    )
                );

            var mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.AddProfile<OutputUserMapper>();
                x.AddProfile<UserMapper>();
            }));

            var handler = new CreateUserCommandHandler(userRepositoryMock.Object, mapper);

            await handler.Handle(command, CancellationToken.None);

            userRepositoryMock.VerifyAll();
        }

        private static CreateUserCommand CreateCommand()
        {
            CreateUserCommand command = new CreateUserCommand()
            {
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
