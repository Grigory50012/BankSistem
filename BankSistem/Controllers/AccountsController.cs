using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BankSistem.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public AccountsController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAccounts()
        {
            try
            {
                var accounts = _repository.Account.GetAllAccounts(trackChenges: false);
                var accountsDto = accounts.Select(account => new AccountDto { 
                    Id = account.Id,
                    Balance = account.Balance
                }).ToList();
                return Ok(accountsDto);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAccounts)} action {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
