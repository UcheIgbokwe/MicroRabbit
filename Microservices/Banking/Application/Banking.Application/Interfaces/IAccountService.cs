using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Domain.Models;

namespace Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}