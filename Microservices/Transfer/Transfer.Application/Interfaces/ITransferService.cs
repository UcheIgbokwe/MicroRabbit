using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfer.Domain.Models;

namespace Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        IEnumerable<TransferLog> GetTransferLogs();
    }
}