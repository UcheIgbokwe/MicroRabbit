using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Banking.Domain.Commands;
using Banking.Domain.Events;
using Domain.Core.Bus;
using MediatR;

namespace Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;
        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;

        }
        public async Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //write to db or do whatever
            
            //Publish event to RabbitMQ
            _bus.Publish(new TransferCreatedEvent(request.Source, request.Destination, request.Amount));
            

            return await Task.FromResult(true);
        }
    }
}