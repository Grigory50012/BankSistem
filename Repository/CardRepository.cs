using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Card> GetCards(Guid idAccount, bool trackChenges)
            => FindByCondition(card => card.IdAccount.Equals(idAccount), trackChenges).ToList();

        public void CreateCard(Guid idAccount, Card card)
        {
            card.IdAccount = idAccount;
            Create(card);
        }

        public IEnumerable<Card> GetCardsByIds(IEnumerable<Guid> ids, bool trackChenges)
            => FindByCondition(card => ids.Contains(card.Id), trackChenges).ToList();
    }
}
