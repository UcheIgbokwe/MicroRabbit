using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Bus;
using Infra.Bus;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
        }
    }
}