using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Events;

namespace Banking.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public TransferCreatedEvent(int source, int destination, decimal amount)
        {
            Source = source;
            Amount = amount;
            Destination = destination;

        }
        public int Source { get; protected set; }
        public int Destination { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}