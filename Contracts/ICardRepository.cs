using Entities.Models;
using System;
using System.Collections.Generic;

namespace Contracts
{
    public interface ICardRepository
    {
        Card GetCard(Guid idAccount, Guid idCard, bool trackChenges);
        IEnumerable<Card> GetCards(Guid idAccount, bool trackChenges);
        void CreateCard(Guid idAccount, Card card);
        void DeleteCard(Card card);
    }
}
