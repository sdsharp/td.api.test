using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Tandem.Domain.DTO.Users;
using Xunit;

namespace TandemIntegrationTest
{
    [Trait("Integration", "UserApi")]
    [Collection("Api collection")]
    public class UserApiTest
    {
        private const String Email = "mary@elitechildcare.com";

        private static readonly InputUser _user = new InputUser
        {
            FirstName = "Mary",
            MiddleName = "J",
            LastName = "Poppins",
            EmailAddress = Email,
            PhoneNumber = "555-555-5555"
        };

        private static readonly InputUser _newUser = new InputUser
        {
            FirstName = "Mary1",
            MiddleName = String.Empty,
            LastName = "Poppins1",
            EmailAddress = Email,
            PhoneNumber = "555-555-1111"
        };

        [Fact]
        public async void UserTest()
        {
            using var client = new ClientProvider().Client;

            // get user with empty db
            var response = await client.GetAsync($"/v1/User?EmailAddress={Email}");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

            var json = JsonConvert.SerializeObject(_user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // create user
            response = await client.PostAsync("/v1/User", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // second try with same user
            response = await client.PostAsync("/v1/User", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            // get user after insert
            response = await client.GetAsync($"/v1/User?EmailAddress={Email}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            string resp = await response.Content.ReadAsStringAsync();
            var resultUser = JsonConvert.DeserializeObject<OutputUser>(resp);

            Assert.Equal(Email, resultUser.EmailAddress);
            Assert.Equal(_user.PhoneNumber, resultUser.PhoneNumber);
            Assert.Equal($"{_user.FirstName} {_user.MiddleName} {_user.LastName}", resultUser.Name);

            // update inserted user
            json = JsonConvert.SerializeObject(_newUser);
            content = new StringContent(json, Encoding.UTF8, "application/json");

            response = await client.PutAsync($"/v1/User?userId={resultUser.UserId}", content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            resp = await response.Content.ReadAsStringAsync();
            resultUser = JsonConvert.DeserializeObject<OutputUser>(resp);

            Assert.Equal(Email, resultUser.EmailAddress);
            Assert.Equal(_newUser.PhoneNumber, resultUser.PhoneNumber);
            Assert.Equal($"{_newUser.FirstName} {_newUser.LastName}", resultUser.Name);
        }        
    }
}
