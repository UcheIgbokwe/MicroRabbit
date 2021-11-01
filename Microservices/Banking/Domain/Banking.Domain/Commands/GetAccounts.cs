using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Banking.Domain.Interfaces;
using Banking.Domain.Models;
using MediatR;

namespace Banking.Domain.Commands
{
    public class GetAccountsQuery : IRequest<GetAccountsResult>
    {
        
    }

    public class GetAccountsResult
    {
        public GetAccountsResult(bool success, string message, IEnumerable<Account> account)
        {
            Success = success;
            Message = message;
            Accounts = account;
        }

        public bool Success { get; }
        public string Message { get; }
        public IEnumerable<Account> Accounts { get ;}
    }

    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, GetAccountsResult>
    {
        private readonly IAccountRepository _accountRepository;
        public GetAccountsQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            
        }
        public Task<GetAccountsResult> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = _accountRepository.GetAccounts();

            if (!result.Any())
            {
                return Task.FromResult(new GetAccountsResult(false, "No Result", result));
            }

            return Task.FromResult(new GetAccountsResult(true, "Passed", result));
        }
    }
}