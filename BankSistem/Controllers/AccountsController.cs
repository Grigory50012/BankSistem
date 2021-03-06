using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankSistem.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AccountsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetAccounts()
        {
            IEnumerable<Account> accounts = await _repository.Account.GetAllAccountsAsync(trackChanges: false);
            IEnumerable<AccountDto> accountsDto = _mapper.Map<IEnumerable<AccountDto>>(accounts);
            return Ok(accountsDto);
        }

        [HttpGet("{idAccount}", Name = "GetAccounts")]
        [HttpHead("{idAccount}")]
        public async Task<IActionResult> GetAccount(Guid idAccount)
        {
            Account account = await _repository.Account.GetAccountAsync(idAccount, trackChanges: false);
            if(account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }
            AccountDto accontDto = _mapper.Map<AccountDto>(account);
            return Ok(accontDto);
        }

        [HttpGet("withoutCards")]
        [HttpHead("withoutCards")]
        public async Task<IActionResult> GetAccountsWithoutCards()
        {
            IEnumerable<Account> accounts = await _repository.Account.GetAccountsWithoutCardsAsync(trackChanges: false);
            IEnumerable<AccountDto> accountsDto = _mapper.Map<IEnumerable<AccountDto>>(accounts);
            return Ok(accountsDto);
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS");
            return Ok();
        }
    }
}
