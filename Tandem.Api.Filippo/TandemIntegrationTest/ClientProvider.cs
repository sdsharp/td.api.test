using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Tandem.Api.Controllers;

namespace TandemIntegrationTest
{
    public class ClientProvider : IDisposable
    {
        private TestServer _testServer;
        public HttpClient Client { get; private set; }

        public ClientProvider()
        {

            var builder = new WebHostBuilder();
            builder.ConfigureAppConfiguration((context, b) =>
            {
                context.HostingEnvironment.ApplicationName = typeof(UserController).Assembly.GetName().Name;
            });

            _testServer = new TestServer(builder
                .UseStartup<Startup>());

            Client = _testServer.CreateClient();
        }

        public void Dispose()
        {
            if (_testServer != null)
            {
                _testServer.Dispose();
                _testServer = null;
            }
        }
    }
}