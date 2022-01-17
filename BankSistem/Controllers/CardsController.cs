using AutoMapper;
using BankSistem.ActionFilters;
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
using Entities.RequestFeatures;
using Newtonsoft.Json;

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
        [HttpHead]
        [ServiceFilter(typeof(ValidateCardExistsAttribute))]
        public IActionResult GetCard(Guid idAccount, Guid idCard)
        {
            Card card = HttpContext.Items["card"] as Card;

            CardDto cardToReturn = _mapper.Map<CardDto>(card);
            return Ok(cardToReturn);
        }

        [HttpGet(Name = "CardsByAccountId")]
        [HttpHead]
        [ServiceFilter(typeof(ValidateAccountExistsAttribute))]
        public async Task<IActionResult> GetCardsForAccount(Guid idAccount, [FromQuery] CardParameters cardParameters)
        {
            Account account = HttpContext.Items["account"] as Account;

            PagedList<Card> cardsFromDb = await _repository.Card.GetCardsAsync(idAccount, cardParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(cardsFromDb.MetaData));

            IEnumerable<CardDto> cardsDto = _mapper.Map<IEnumerable<CardDto>>(cardsFromDb);
            return Ok(cardsDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateAccountExistsAttribute))]
        public async Task<IActionResult> CreateCard(Guid idAccount, [FromBody] CardForCreationDto card)
        {
            Account account = HttpContext.Items["account"] as Account;

            Card cardEntity = _mapper.Map<Card>(card);

            await CreateCard(idAccount, cardEntity);

            CardDto cardToReturn = _mapper.Map<CardDto>(cardEntity);

            return CreatedAtRoute("CardsByAccountId", new { idAccount }, cardToReturn);
        }

        [HttpPost("collection")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateAccountExistsAttribute))]
        public async Task<IActionResult> CreateCardCollection(Guid idAccount, IEnumerable<CardForCreationDto> cardCollection)
        {
            Account account = HttpContext.Items["account"] as Account;

            IEnumerable<Card> cardEntities = _mapper.Map<IEnumerable<Card>>(cardCollection);
            foreach (Card card in cardEntities)
            {
                _repository.Card.CreateCard(idAccount, card);
            }
            await _repository.SaveAsync();

            IEnumerable<CardDto> cardCollectionsToReturn = _mapper.Map<IEnumerable<CardDto>>(cardEntities);

            return CreatedAtRoute("CardsByAccountId", new { idAccount }, cardCollectionsToReturn);
        }

        private async Task CreateCard(Guid idAccount, Card cardEntity)
        {
            _repository.Card.CreateCard(idAccount, cardEntity);
            await _repository.SaveAsync();
        }

        [HttpDelete("{idCard}")]
        [ServiceFilter(typeof(ValidateCardExistsAttribute))]
        public async Task<IActionResult> DeleteCard(Guid idAccount, Guid idCard)
        {
            Card cardForAccount = HttpContext.Items["card"] as Card;

            await DeleteCardAsync(cardForAccount);

            return NoContent();
        }

        private async Task DeleteCardAsync(Card card)
        {
            _repository.Card.DeleteCard(card);
            await _repository.SaveAsync();
        }

        [HttpPatch("{idCard}")]
        [ServiceFilter(typeof(ValidateCardExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateCardForAccount(Guid idAccount, Guid idCard, [FromBody] JsonPatchDocument<CardForUpdateDto> patchDocument)
        {
            if(patchDocument == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            Card cardEntity = HttpContext.Items["card"] as Card;

            CardForUpdateDto cardToPatch = _mapper.Map<CardForUpdateDto>(cardEntity);

            patchDocument.ApplyTo(cardToPatch, ModelState);

            TryValidateModel(cardToPatch);

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }

            _mapper.Map(cardToPatch, cardEntity);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, DELETE, PATCH");
            return Ok();
        }
    }
}
