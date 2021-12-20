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
    }
}
