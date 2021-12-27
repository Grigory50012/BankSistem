using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<Card> GetCardAsync(Guid idAccount, Guid idCard, bool trackChenges)
            => await FindByCondition(card => card.IdAccount.Equals(idAccount) && card.Id.Equals(idCard), trackChenges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Card>> GetCardsAsync(Guid idAccount, bool trackChenges)
            => await FindByCondition(card => card.IdAccount.Equals(idAccount), trackChenges).ToListAsync();

        public void CreateCard(Guid idAccount, Card card)
        {
            card.IdAccount = idAccount;
            Create(card);
        }

        public void DeleteCard(Card card) => Delete(card);
    }
}
