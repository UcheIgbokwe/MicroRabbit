using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Application.Interfaces;
using Banking.Application.Services;
using Banking.Data.Context;
using Banking.Data.Repository;
using Banking.Domain.CommandHandlers;
using Banking.Domain.Commands;
using Banking.Domain.Interfaces;
using Domain.Core.Bus;
using Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(serviceProvider => {
                var mediator = serviceProvider.GetService<IMediator>();
                var serviceScopeFactory = serviceProvider.GetService<IServiceScopeFactory>();
                return new RabbitMQBus(mediator, serviceScopeFactory);
            });

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}