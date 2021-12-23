using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetCards(Guid idAccount, bool trackChenges);
        void CreateCard(Guid idAccount, Card card);
        IEnumerable<Card> GetCardsByIds(IEnumerable<Guid> ids, bool trackChenges);
    }
}
