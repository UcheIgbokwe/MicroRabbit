using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Application.Interfaces;
using Banking.Application.Models;
using Banking.Domain.Commands;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using Domain.Core.Bus;

namespace Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;
        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _bus = bus;
            _accountRepository = accountRepository;

        }
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.Source,
                accountTransfer.Destination,
                accountTransfer.Amount
            );

            _bus.SendCommand(createTransferCommand);
        }
    }
}