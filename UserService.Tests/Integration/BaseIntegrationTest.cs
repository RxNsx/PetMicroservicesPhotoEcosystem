using MassTransit.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PhotoEcosystem.UserService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UserService.Tests.Integration
{
    /// <summary>
    /// Базовый класс для выполнения интеграционных тестов
    /// </summary>
    public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestWebAppFactory>
    {
        private readonly IServiceScope _scope;
        protected readonly ISender Sender;
        protected readonly AppDbContext Context;

        public BaseIntegrationTest(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();
            Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
            Context = _scope.ServiceProvider.GetRequiredService<AppDbContext>();
        }
    }
}
