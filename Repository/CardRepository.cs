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
        public CardRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public Card GetCard(Guid idAccount, Guid idCard, bool trackChenges)
            => FindByCondition(card => card.IdAccount.Equals(idAccount) && card.Id.Equals(idCard), trackChenges).SingleOrDefault();

        public IEnumerable<Card> GetCards(Guid idAccount, bool trackChenges)
            => FindByCondition(card => card.IdAccount.Equals(idAccount), trackChenges).ToList();

        public void CreateCard(Guid idAccount, Card card)
        {
            card.IdAccount = idAccount;
            Create(card);
        }

        public void DeleteCard(Card card) => Delete(card);
    }
}
