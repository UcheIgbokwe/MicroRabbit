using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Banking.Application.Interfaces;
using Banking.Domain.Models;
using Banking.Application.Models;

namespace Banking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly ILogger<BankingController> _logger;
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService, ILogger<BankingController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            try
            {
                return Ok(_accountService.GetAccounts());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}