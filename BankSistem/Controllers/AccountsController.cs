using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
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
            var accounts = _repository.Account.GetAllAccounts(trackChenges: false);
            var accountsDto = _mapper.Map<IEnumerable<AccountDto>>(accounts);
            return Ok(accountsDto);
        }
    }
}
