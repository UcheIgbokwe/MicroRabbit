using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transfer.Data.Context;
using Transfer.Domain.Interfaces;
using Transfer.Domain.Models;

namespace Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private readonly TransferDbContext _dbContext;
        public TransferRepository(TransferDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task CreateTransferLog(TransferLog transferLog)
        {
            _dbContext.TransferLogs.Add(transferLog);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _dbContext.TransferLogs;
        }
    }
}