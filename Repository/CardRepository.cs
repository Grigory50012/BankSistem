using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<Card> GetCardAsync(Guid idAccount, Guid idCard, bool trackChanges)
            => await FindByCondition(card => card.IdAccount.Equals(idAccount) 
            && card.Id.Equals(idCard), trackChanges).SingleOrDefaultAsync();

        public async Task<PagedList<Card>> GetCardsAsync(Guid idAccount, CardParameters cardParameters, bool trackChanges)
        {
            List<Card> cards = await FindByCondition(card => card.IdAccount.Equals(idAccount), trackChanges)
                .OrderBy(cards => cards.Balance)
                .ToListAsync();

            return PagedList<Card>.ToPagedList(cards, cardParameters.PageNumber, cardParameters.PageSize);
        }
           
        public void CreateCard(Guid idAccount, Card card)
        {
            card.IdAccount = idAccount;
            Create(card);
        }

        public void DeleteCard(Card card) => Delete(card);
    }
}
