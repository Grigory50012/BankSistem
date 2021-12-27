using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ForCreationDto;
using Entities.DataTransferObjects.ForUpdateDto;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetCard(Guid idAccount, Guid idCard)
        {
            Account account = await GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            Card card = await _repository.Card.GetCardAsync(idAccount, idCard, trackChenges: false);
            if (card == null)
            {
                _logger.LogError($"Card with id: {idCard} doesn't exist in the database.");
                return NotFound();
            }

            CardDto cardToReturn = _mapper.Map<CardDto>(card);
            return Ok(cardToReturn);
        }

        [HttpGet(Name = "CardsByAccountId")]
        public async Task<IActionResult> GetCards(Guid idAccount)
        {
            Account account = await GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            IEnumerable<Card> cards = await _repository.Card.GetCardsAsync(idAccount, trackChenges: false);
            IEnumerable<CardDto> cardsDto = _mapper.Map<IEnumerable<CardDto>>(cards);
            return Ok(cardsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(Guid idAccount, [FromBody] CardForCreationDto card)
        {
            if (card == null)
            {
                _logger.LogError("CardForCreationDto object sent from client is null.");
                return BadRequest("CardForCreationDto object is null.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            Account account = await GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            Card cardEntity = _mapper.Map<Card>(card);

            _repository.Card.CreateCard(idAccount, cardEntity);
            _repository.SaveAsync();

            CardDto cardToReturn = _mapper.Map<CardDto>(cardEntity);

            return CreatedAtRoute("CardsByAccountId", new { idAccount }, cardToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCardCollection(Guid idAccount, IEnumerable<CardForCreationDto> cardCollection)
        {
            if (cardCollection == null)
            {
                _logger.LogError("Card collection sent from client is null.");
                return BadRequest("Card collection is null");
            }

            Account account = await GetAccountById(idAccount);
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
            _repository.SaveAsync();

            IEnumerable<CardDto> cardCollectionsToReturn = _mapper.Map<IEnumerable<CardDto>>(cardEntities);

            return CreatedAtRoute("CardsByAccountId", new { idAccount }, cardCollectionsToReturn);
        }

        [HttpDelete("{idCard}")]
        public async Task<IActionResult> DeleteCard(Guid idAccount, Guid idCard)
        {
            Account account = await GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            Card card = await _repository.Card.GetCardAsync(idAccount, idCard, trackChenges: false);
            if (card == null)
            {
                _logger.LogError($"Card with id: {idCard} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Card.DeleteCard(card);
            _repository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{idCard}")]
        public async Task<IActionResult> PartiallyUpdateCardForAccount(Guid idAccount, Guid idCard, [FromBody] JsonPatchDocument<CardForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            Account account = await GetAccountById(idAccount);
            if (account == null)
            {
                _logger.LogInfo($"Account with id: {idAccount} does't exist in the database.");
                return NotFound();
            }

            Card cardEntity = await _repository.Card.GetCardAsync(idAccount, idCard, trackChenges: true);
            if (cardEntity == null)
            {
                _logger.LogError($"Card with id: {idCard} doesn't exist in the database.");
                return NotFound();
            }

            CardForUpdateDto cardToPatch = _mapper.Map<CardForUpdateDto>(cardEntity);

            patchDocument.ApplyTo(cardToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForCreationDto object");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(cardToPatch, cardEntity);

            _repository.SaveAsync();

            return NoContent();
        }

        private async Task<Account> GetAccountById(Guid idAccount) => await _repository.Account.GetAccountAsync(idAccount, trackChenges: false);
    }
}
