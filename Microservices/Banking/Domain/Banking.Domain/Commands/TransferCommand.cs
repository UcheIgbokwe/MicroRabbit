using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Commands;

namespace Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public int Source { get; protected set; }
        public int Destination { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}