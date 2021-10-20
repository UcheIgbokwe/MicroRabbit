using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Bus;
using Transfer.Domain.Events;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }
        public Task Handle(TransferCreatedEvent @event)
        {
            //write to db or do whatever
            _transferRepository.CreateTransferLog(new TransferLog()
            {
                Source = @event.Source,
                Destination = @event.Destination,
                Amount = @event.Amount
            });

            return Task.CompletedTask;
        }
    }
}