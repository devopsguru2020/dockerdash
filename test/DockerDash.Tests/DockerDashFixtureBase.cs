﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;

namespace DockerDash.Tests
{
    public class DockerDashFixtureBase<TStartup> : IDisposable
        where TStartup : class
    {
        private readonly TestServer _server;

        public DockerDashFixtureBase(string baseUri)
        {
            var builder = new WebHostBuilder().UseStartup<TStartup>();
            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri(baseUri);
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
