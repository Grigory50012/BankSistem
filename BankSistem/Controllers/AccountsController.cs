using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IActionResult GetAccounts()
        {
            IEnumerable<Account> accounts = _repository.Account.GetAllAccounts(trackChenges: false);
            IEnumerable<AccountDto> accountsDto = _mapper.Map<IEnumerable<AccountDto>>(accounts);
            return Ok(accountsDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(Guid id)
        {
            Account account = _repository.Account.GetAccount(id, trackChenges: false);
            if(account == null)
            {
                _logger.LogInfo("Account with id does't exist in the database.");
                return NotFound();
            }
            else
            {
                AccountDto accontDto = _mapper.Map<AccountDto>(account);
                return Ok(accontDto);
            }
        }
    }
}
