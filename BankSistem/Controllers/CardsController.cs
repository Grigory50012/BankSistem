using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BankSistem.Controllers
{
    [Route("api/accounts/{idAccount}/cards")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CardsController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCards(Guid idAccount)
        {
            var account = _repository.Account.GetAccount(idAccount, trackChenges: false);
            if (account == null)
            {
                _logger.LogInfo("Account with id does't exist in the database.");
                return NotFound();
            }

            var cards = _repository.Card.GetCards(idAccount, trackChenges: false);
            var cardsDto = _mapper.Map<IEnumerable<CardDto>>(cards);
            return Ok(cardsDto);
        }
    }
}
