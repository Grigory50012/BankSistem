using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ForCreationDto;
using Entities.Models;
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

        [HttpGet("{idCard}")]
        public IActionResult GetCard(Guid idAccount, Guid idCard)
        {
            Account account = GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            Card card = _repository.Card.GetCard(idAccount, idCard, trackChenges: false);
            if(card == null)
            {
                _logger.LogError($"Card with id: {idCard} doesn't exist in the database.");
                return NotFound();
            }

            CardDto cardToReturn = _mapper.Map<CardDto>(card);
            return Ok(cardToReturn);
        }

        [HttpGet(Name = "CardsByAccountId")]
        public IActionResult GetCards(Guid idAccount)
        {
            Account account = GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            IEnumerable<Card> cards = _repository.Card.GetCards(idAccount, trackChenges: false);
            IEnumerable<CardDto> cardsDto = _mapper.Map<IEnumerable<CardDto>>(cards);
            return Ok(cardsDto);
        }

        [HttpPost]
        public IActionResult CreateCard(Guid idAccount, [FromBody] CardForCreationDto card)
        {
            if (card == null)
            {
                _logger.LogError("CardForCreationDto object sent from client is null.");
                return BadRequest("CardForCreationDto object is null.");
            }

            Account account = GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            Card cardEntity = _mapper.Map<Card>(card);

            _repository.Card.CreateCard(idAccount, cardEntity);
            _repository.Save();

            CardDto cardToReturn = _mapper.Map<CardDto>(cardEntity);

            return CreatedAtRoute("CardsByAccountId", new { idAccount }, cardToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateCardCollection(Guid idAccount, IEnumerable<CardForCreationDto> cardCollection)
        {
            if(cardCollection == null)
            {
                _logger.LogError("Card collection sent from client is null.");
                return BadRequest("Card collection is null");
            }

            Account account = GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            IEnumerable<Card> cardEntities = _mapper.Map<IEnumerable<Card>>(cardCollection);
            foreach (Card card in cardEntities)
            {
                _repository.Card.CreateCard(idAccount, card);
            }
            _repository.Save();

            IEnumerable<CardDto> cardCollectionsToReturn = _mapper.Map<IEnumerable<CardDto>>(cardEntities);

            return CreatedAtRoute("CardsByAccountId", new { idAccount }, cardCollectionsToReturn);
        }

        [HttpDelete("{idCard}")]
        public IActionResult DeleteCard(Guid idAccount, Guid idCard)
        {
            Account account = GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            Card card = _repository.Card.GetCard(idAccount, idCard, trackChenges: false);
            if (card == null)
            {
                _logger.LogError($"Card with id: {idCard} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Card.DeleteCard(card);
            _repository.Save();

            return NoContent();
        }

        private Account GetAccountById(Guid idAccount) => _repository.Account.GetAccount(idAccount, trackChenges: false);
    }
}
