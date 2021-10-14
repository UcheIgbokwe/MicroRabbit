using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Bus;
using Domain.Core.Commands;
using Domain.Core.Events;

namespace Infra.Bus
{
    public sealed class RabbitMQBus : IEventBus
    {
        public void Publish<T>(T @event) where T : Event
        {
            throw new NotImplementedException();
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            throw new NotImplementedException();
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            throw new NotImplementedException();
        }
    }
}