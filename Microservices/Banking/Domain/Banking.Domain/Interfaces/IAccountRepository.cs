using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Domain.Models;

namespace Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}