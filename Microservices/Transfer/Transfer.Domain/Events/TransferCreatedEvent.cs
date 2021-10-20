using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Events;

namespace Transfer.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public int Source { get; protected set; }
        public int Destination { get; protected set; }
        public decimal Amount { get; protected set; }
        
        public TransferCreatedEvent(int source, int destination, decimal amount)
        {
            Source = source;
            Destination = destination;
            Amount = amount;
        }
    }
}