using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Bus;
using Transfer.Application.Interfaces;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IEventBus _bus;
        private readonly ITransferRepository _transferRepository;
        public TransferService(ITransferRepository transferRepository, IEventBus bus)
        {
            _transferRepository = transferRepository;
            _bus = bus;
            
        }
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _transferRepository.GetTransferLogs();
        }

    }
}