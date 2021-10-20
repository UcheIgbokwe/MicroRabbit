using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transfer.Application.Interfaces;
using Transfer.Domain.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ILogger<TransferController> _logger;
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService, ILogger<TransferController> logger)
        {
            _transferService = transferService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            try
            {
                return Ok(_transferService.GetTransferLogs());
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
            
        }
    }
}