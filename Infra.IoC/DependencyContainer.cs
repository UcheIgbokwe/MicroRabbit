using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Microsoft.Extensions.DependencyInjection.Extensions;
using Transfer.Application.Interfaces;
using Transfer.Application.Services;
using Transfer.Data.Context;
using Transfer.Data.Repository;
using Transfer.Domain.EventHandlers;
using Transfer.Domain.Events;
using Transfer.Domain.Interfaces;

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

            //Subscriptions
            services.AddTransient<TransferEventHandler>();

            //Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            //Domain Banking Queries
            services.AddMediatR(typeof(GetAccountsQueryHandler).GetTypeInfo().Assembly);

            //Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            //Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();
            services.TryAddScoped<BankingDbContext>();
            services.TryAddScoped<TransferDbContext>();
        }
    }
}