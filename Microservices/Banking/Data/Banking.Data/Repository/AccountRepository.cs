using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Data.Context;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;

namespace Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _dbContext;
        public AccountRepository(BankingDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IEnumerable<Account> GetAccounts()
        {
            return _dbContext.Accounts;
        }
    }
}