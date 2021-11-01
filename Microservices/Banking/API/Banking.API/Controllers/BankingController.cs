using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Banking.Application.Interfaces;
using Banking.Domain.Models;
using Banking.Application.Models;
using System.Threading.Tasks;
using Banking.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly ILogger<BankingController> _logger;
        private readonly IAccountService _accountService;
        private readonly IMediator _mediator;

        public BankingController(IMediator mediator, IAccountService accountService, ILogger<BankingController> logger)
        {
            _mediator = mediator;
            _accountService = accountService;
            _logger = logger;
        }

        //Implement changes to route Post method through mediator and disengage the accountservices interface.

        [HttpGet]
        public async Task<ActionResult<ApiResponse<GetAccountsResult>>> GetAllAccounts()
        {

            var accountResult = await _mediator.Send(new GetAccountsQuery());
            if(accountResult.Success)
            {
                return Ok(ApiResponse<GetAccountsResult>.FromData(accountResult.Accounts, accountResult.Message));
            }
            return StatusCode(StatusCodes.Status404NotFound, 
                    ApiResponse<GetAccountsResult>.WithError(accountResult.Message));
            
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<Account>> Get()
        // {
        //     try
        //     {
        //         return Ok(_accountService.GetAccounts());
        //     }
        //     catch (System.Exception ex)
        //     {
        //         _logger.LogError(ex.Message);
        //         return BadRequest();
        //     }
            
        // }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}